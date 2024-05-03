using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public GameObject text;

    private void Start()
    {
        text.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
         text.SetActive(true);
    }

    private void OnCollisionExit(Collision collision)
    {
        text.SetActive(false);
    }
}
