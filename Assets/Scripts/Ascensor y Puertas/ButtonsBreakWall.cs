using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ButtonsBreakWall : MonoBehaviour
{

    public event Action activateWall = delegate { };
    [SerializeField] AudioSource _audio;
    [SerializeField] AudioSource _audioBreak;
    [SerializeField] float _play;

    private void OnTriggerEnter(Collider collision)
    {

        //Activar movimiento pared
        if (collision.name == ("BoxToGrub"))
        {
            _audio.Play();
            activateWall();
            if(_play<1)
            {
                _audioBreak.Play();
                _play = 1;
            }
        }
    }
}
