using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotColor : MonoBehaviour
{
    public Material    eye;
    public GameObject  text;
    float             _destroy;
    public GameObject  red;
    public GameObject  green;


    private void Start()
    {
        red.SetActive(true);
        green.SetActive(false);
       eye.color = new Color(0.78f, 0, 0, 1);
        text.SetActive(false);
        _destroy = 0;
    }

    public void ChangeColor()
    { 
        if (_destroy == 0)
        {
           eye.color = new Color (0.2147561f, 0.8962264f, 0.5246739f, 1);
           text.SetActive(true);
            red.SetActive(false);
            green.SetActive(true);
            _destroy = 1;
        }
       
    }

    public void TextOff()
    {
        text.SetActive(false);
    }


}
