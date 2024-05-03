using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smoke : MonoBehaviour
{
    //Casella, Maximiliano
    [SerializeField] float _damage;
    [SerializeField] GameObject _playerTarget;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == _playerTarget)
        {

            _playerTarget.GetComponent<BaseCharacter>().ReceiveDamage(_damage);
        }
    }
}
