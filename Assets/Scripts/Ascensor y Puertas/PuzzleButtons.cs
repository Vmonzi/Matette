using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PuzzleButtons : MonoBehaviour
{
    //Casella, Maximiliano
    public delegate void TouchButtons();

    public event TouchButtons addButtons;
    public event TouchButtons subtractButtons;

    [SerializeField] AudioSource _audioEnter;
    [SerializeField] AudioSource _audioExit;

    private void OnTriggerEnter(Collider collision)
    {

        //Sumar botones al entrar
       if(collision.name == ("BoxToGrub"))
        {
            _audioEnter.Play();
            addButtons();
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        //Restar botones al entrar
        if (collision.name == ("BoxToGrub"))
        {
            _audioExit.Play();
            subtractButtons();
        }
    }
}
