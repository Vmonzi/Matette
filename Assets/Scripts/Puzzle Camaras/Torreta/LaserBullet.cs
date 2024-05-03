using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LaserBullet : MonoBehaviour
{
    [SerializeField] float _maxSpeed;
    [SerializeField] float _dmg;
    [SerializeField] float _timeToDestroy;

    Vector3 _speed;
    BaseCharacter _target;

    void Start()
    {
        _target = FindObjectOfType<BaseCharacter>();
    }

    void Update()
    {
        AddForce(Shoot(_target.transform.position));
        transform.position += _speed * Time.deltaTime;
        transform.forward = _speed;
        Destroy(gameObject, _timeToDestroy);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<BaseCharacter>())
        {
            _target.ReceiveDamage(_dmg);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void AddForce(Vector3 force)
    {
        _speed = Vector3.ClampMagnitude(_speed + force, _maxSpeed);
    }

    Vector3 Shoot(Vector3 target)
    {
        Vector3 desired = target - transform.position;
        desired.Normalize();

        return desired;
    }
}


