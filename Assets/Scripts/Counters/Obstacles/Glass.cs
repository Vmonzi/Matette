using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass : MonoBehaviour
{
    [SerializeField] int        _platform;
    public Rigidbody             rb;
    private bool                _active;
    [SerializeField] GameObject _player;

    private void Start()
    {
        if (_platform == 0)
        {
            _active = false;
        }

        else if (_platform == 1)
        {
            _active = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == _player)
        {
           if (_active == false)
         {
            rb.useGravity = true;
            rb.isKinematic = false;
            Destroy(this.gameObject, 1f);
         }
          else
         {
            rb.useGravity = false;
            rb.isKinematic = true;
         }
        }
        
    }




}
       
    
