using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSound : MonoBehaviour
{
    public AudioSource myAudio;

    public void ClickSound()
    {
        myAudio.Play();
    }
}
