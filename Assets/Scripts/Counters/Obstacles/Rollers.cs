using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rollers : MonoBehaviour, IRotateObject
{

    [SerializeField] float _speed;
    [SerializeField] float _dmg;
    [SerializeField] float _rotY;
    [SerializeField] GameObject _player;
   

    private void Update()
    {
        Rotate();

    }


    //Daño al player
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject == _player)
        {
            _player.GetComponent<BaseCharacter>().ReceiveDamage(_dmg);
        }
    }

    public void Rotate()
    {
        //Rotacion
        transform.Rotate(new Vector3(0f, _rotY, 0f) * _speed * Time.deltaTime);
    }
}
