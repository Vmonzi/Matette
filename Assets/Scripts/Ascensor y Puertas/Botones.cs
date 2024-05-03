using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botones : MonoBehaviour
{
    public Ascensor     myAscensor;
    public PuertasAsc[] doors;
    public AudioClip    ascensor;
    public AudioSource  myAudio;

    void Start()
    {
        myAudio.clip = ascensor;
        myAscensor.SetMove(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        myAudio.Play();
        if (other.gameObject.layer == 15 && !myAscensor.GetMove())
        {
            myAscensor.LetsMove += myAscensor.Movement;
            
            foreach (PuertasAsc door in doors)
            {
                myAscensor.LetsMove -= door.Open;
                myAscensor.LetsMove += door.Close;
            }
        }
    }
}
