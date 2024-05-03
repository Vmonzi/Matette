using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSPike : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] float _dmg;
    [SerializeField] float _speed;
    [SerializeField] Transform _point1;
    [SerializeField] Transform _point2;
    [SerializeField] AudioSource _audio;
    //Transform _myTransform;
    //Transform _initialPos;
    //Vector3 _dir = new Vector3(1, 0, 0);
    WallMovement _movement;
    Transform _target;
   



    private void Start()
    {
        //Composicion con clase de movimiento de la pared

        //_movement = new wallmovement(_mytransform, _dir, _initialpos, _time, _timetomove, _initialtime);
        _target = _point1;
        
    }

    private void Update()
    {
        var distance = Vector3.Distance(transform.position, _target.position);

        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);


        if (distance == 0.00)
        {

            _audio.Play();

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


    //Colision con el area de pinches
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _player)
        {
            _player.GetComponent<BaseCharacter>().ReceiveDamage(_dmg);
        }
    }
    
     
}
