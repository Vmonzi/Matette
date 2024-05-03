using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement
{

    float _initialTime;
    float _time;
    float _timeToMove;
    Vector3 _dir;
    Transform _myTransform;
    Transform _initial;
  


    public WallMovement(Transform t, Vector3 dir, Transform initial, float time, float timeToMove, float initialTime)
    { 
        _myTransform = t;
        _dir = dir;
        _time = time;
        _timeToMove = timeToMove;
        _initialTime = initialTime;
        _initial = initial;
        
    }
    //Movimiento pared con pinches
    public void movement()
    {
        if (_time >= 0)
        {
            _myTransform.transform.position = _initial.position + _dir * _timeToMove * Time.deltaTime;
        }
        else
        {
            _myTransform.transform.position = _initial.position - _dir * _timeToMove * Time.deltaTime;
        }
    }
}
