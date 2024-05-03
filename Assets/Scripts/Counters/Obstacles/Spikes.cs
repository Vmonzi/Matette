using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private float       _timeMoving = 1.0f;
    public float       _damage = 5;
    private bool        _isDown;
    public  GameObject  toHurt;
    private float       _toMove = 2.5f;
    private Transform   _initialPos;
    private Vector3     _direction = new Vector3(0, 1, 0);

    // Start is called before the first frame update
    void Start()
    {
        _isDown = true;
        _initialPos = this.transform;
    }

    // Update is called once per frame
    void Update()
    {
        _timeMoving -= Time.deltaTime;
        if (_timeMoving >= 0)
        {
            if (_isDown)
            {
                transform.position = _initialPos.position + _direction * _toMove * Time.deltaTime;
            }
            else
            {
                transform.position = _initialPos.position - _direction * _toMove * Time.deltaTime;
            }
        }
        else
        {
            if (_isDown)
            {
                _isDown = false;
            }
            else
            {
                _isDown = true;
            }
            _timeMoving = 1.0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == toHurt)
        {
            toHurt.GetComponent<BaseCharacter>().ReceiveDamage(_damage);
        }
    }
}
