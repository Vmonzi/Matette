using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsRoom : MonoBehaviour
{
    //Victoria Monzi
    ParedesPlat        _paredes;
    public GameObject   pj;
    bool               _pressed;
    public GameObject luz;
    private void Start()
    {
        if(GetComponentInChildren<ParedesPlat>())
            _paredes = GetComponentInChildren<ParedesPlat>();
        _pressed = false;
        luz.SetActive (false);
    }

    private void Update()
    {
        if (_pressed == true)
        {
            if(_paredes)
                _paredes.Open();
            luz.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == pj)      //Solamente activa el movimiento si el Pj es el que esta pisando el trigger
        _pressed = true;
    }
}
