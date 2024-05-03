using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerText : MonoBehaviour
{
    //Casella, Maximiliano

    [SerializeField] GameObject _txt;

    private void OnTriggerEnter(Collider other)
    {
        _txt.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        _txt.SetActive(false);
    }
}
