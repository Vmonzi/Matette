using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ActivatorWheels : MonoBehaviour, IAudio
{
    public delegate void Audio();

    public event Action audioEvent = delegate { };

    [SerializeField] AudioSource _audio;

    private void OnTriggerEnter(Collider other)
    {
        audioEvent += PlaySound;
    }

    public void PlaySound()
    {
        _audio.Play();
    }
}
