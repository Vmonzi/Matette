using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokePuzzle : MonoBehaviour
{

    [SerializeField] GameObject _smoke;
    [SerializeField] AudioSource _smokeSound;
    [SerializeField] AudioSource _buttonSound;
    [SerializeField] Light _buttonLight;

    bool _isOn;

    void Start()
    {
        _isOn = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.E))
        {
            ActivateButton();
        }
    }

    void ActivateButton()
    {
        _isOn = true;
        _buttonSound.Play();
        _buttonLight.color = Color.green;
        Destroy(_smoke);
        _smokeSound.Play();
    }
}
