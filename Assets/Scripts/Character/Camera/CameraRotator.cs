using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotator : MonoBehaviour
{
    //Ivo Aguilera
    public float        _speedRotation;

    private void Update()
    {
        if (Time.timeScale != 0)
        {
            float _rotar = Input.GetAxis("Mouse X");
            if (_rotar != 0)
            {
                this.transform.Rotate(0, _rotar * _speedRotation, 0);
            }
        }
    }
}
