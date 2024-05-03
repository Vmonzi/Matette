using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    //Casella, Maximiliano - Monzi, Victoria

    float                           _velocity = 7;
    [SerializeField]Transform       _target;
    [SerializeField]Transform       _placa;
    [SerializeField] int            _activeButtons; /*Botones activados con las cajas*/
    [SerializeField] int            _buttonsRequired; /*Botones necesarios para abrir la puerta*/
    bool                            _mov;
    bool                            _puzzleMov;
    public PuzzleButtons []         _buttons;
    [SerializeField] AudioSource    _audio;
    [SerializeField] float          _play1;
    [SerializeField] float          _play2;


    public void Start()
    {
        _mov    = false;
        _target = _placa;

        for (int i = 0; i <_buttons.Length; i++)
        {
            _buttons[i].addButtons      += AddButton;
            _buttons[i].subtractButtons += SubtractButton;
        }
    }

    public void Update()
    {
        if (_mov)
        {
            transform.position = Vector3.MoveTowards(transform.position , _target.position, _velocity * Time.deltaTime);
        }

        ActivateDoor();
        if (_puzzleMov)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target.position, _velocity * Time.deltaTime);
        }
    }

    public void DoorMovement()
    {
        _mov = true;
        if(_play1 <1)
        {
            _audio.Play();
            _play1 = 1;
        }    
    }

    public void AddButton() { _activeButtons += 1; }

    public void SubtractButton() { _activeButtons -= 1; }

    public void ActivateDoor()
    {
        if (_activeButtons == _buttonsRequired)
        {   
            _puzzleMov = true;
            if (_play2 < 1)
            {
                _audio.Play();
                _play2 = 1;
            }
        }
    }
}
