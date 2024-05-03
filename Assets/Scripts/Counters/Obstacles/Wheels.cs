using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheels : MonoBehaviour, IRotateObject, IAudio
{

    //Casella, Maximiliano

    [SerializeField] Transform _point1;
    [SerializeField] Transform _point2;
    [SerializeField] GameObject _player;
    [SerializeField] float _speed;
    [SerializeField] float _rotZ;
    [SerializeField] float _dmg;
    [SerializeField] AudioSource _audio;
    Transform _target;

    [SerializeField] ActivatorWheels _audioEvent;
  
    BaseCharacter character;

    private void Start()
    {   
        _target = _point1;
        _audioEvent.audioEvent += PlaySound;
        character = GameObject.FindObjectOfType<BaseCharacter>();
    }
    private void Update()
    {
        var distance = Vector3.Distance(transform.position, _target.position);

        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
        Rotate();

        if (distance == 0.00)
        {

            if (_target == _point1)
            {
                _target = _point2;
                
            }
            else if (_target == _point2)
            {
                _target = _point1;
                
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _player)
        {
            character.ReceiveDamage(_dmg);
        }
    }

    public void PlaySound()
    {
        _audio.Play();
    }

    public void Rotate()
    {
        transform.Rotate(new Vector3(0f, 0f, _rotZ) * _speed * Time.deltaTime);
    }






}
