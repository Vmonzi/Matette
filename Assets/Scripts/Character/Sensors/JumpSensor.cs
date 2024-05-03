using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JumpSensor : MonoBehaviour
{
    public float        forceJump;
    public float        initialJumpForce;
    public bool        _isFalling;
    public bool        _onFloor;

    private void Start()
    {
        _onFloor = true;
        _isFalling = false;
        forceJump = initialJumpForce;
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.layer == 8 || other.gameObject.layer == 22) && _isFalling)
        {
            _onFloor = true;
            _isFalling = false;
        }
    }

    public void SetOnFloor(bool onFloor) { _onFloor = onFloor; }

    public bool IsOnFloor() { return _onFloor; }

    public void SetIsFalling(bool isFalling) { _isFalling = isFalling; }

    public bool IsFalling() { return _isFalling; }
}
