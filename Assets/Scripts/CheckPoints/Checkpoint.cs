using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] AudioSource _audio;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<IPlayer>() != null)
        {
            _audio.Play();
        }
    }
}
