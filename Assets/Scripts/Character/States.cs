using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ivo Joaquín Aguilera

public class States: IActions
{
    Vector3 _velocity;
    Vector3 _moveDirection;
    Vector3 _rotateDirection;
    
    public Vector3 GetVelocity  { get { return _velocity; } }
    public Vector3 SetVelocity  { set { _velocity = value; } }
    public Vector3 GetDirection { get { return _moveDirection; } }
    public Vector3 SetDirection { set { _moveDirection = value; } }
    public Vector3 GetRotation  { get { return _rotateDirection; } }
    public Vector3 SetRotation  { set { _rotateDirection = value; } }

    Controller          _myController;
    BaseCharacter       _myChar;
    ControlAnimation    _myAnimatorController;

    public States(Controller myController, BaseCharacter myChar)
    {
        _myController           = myController;
        _myChar                 = myChar;
        _myAnimatorController   = new ControlAnimation(_myChar.GetAnimator, myController);
    }

    public void Move()
    {
        _velocity = _moveDirection * _myController.GetSpeed();
        _myController.GetModelRotator.Rotar(_rotateDirection);

        if (_myController.GetState() == Entity.state.IDLE) _velocity = Vector3.zero;
        

        _velocity.y = _myChar.GetRigidbody.velocity.y;
        _myChar.GetRigidbody.velocity = _velocity;

        if (_myController.GetJumpSensor.IsOnFloor()) _myController.GetJumpSensor.SetIsFalling(false);
        else if (_myChar.GetRigidbody.velocity.y < -0.1f) _myController.GetJumpSensor.SetIsFalling(true);
    }

    public void Walk()
    {
        if (_myController.GetState() != Entity.state.Hurt)
        {
            _myController.SetState(Entity.state.Walking);
        }
        _myController.SetSpeed(_myChar.GetSpeed);
        _myController.GetJumpSensor.forceJump = _myController.GetJumpSensor.initialJumpForce + 2;
    }

    public void Run()
    {
        if (_myController.GetState() != Entity.state.Hurt)
        {
            _myController.SetState(Entity.state.Running);
        }
        _myController.SetSpeed(_myChar.GetSpeed + 10);
        _myController.GetJumpSensor.forceJump = _myController.GetJumpSensor.initialJumpForce - 2;
    }

    public void Craw()
    {
        _myChar.GetCameraInteract.ChangePosToCrouch();
        _myController.GetBoxSensor.enabled = false;

        _myController.SetState(Entity.state.Craw);
        _myChar.ColliderCrouch();
        //Crouch & Crawling
        if (_velocity != Vector3.zero)
        {
            _myChar.GetAnimator.SetBool("Walking", true);
        }
    }

    public void Jump()
    {
        _myChar.UpdateFeedback.StopSound();
        _myChar.GetRigidbody.AddForce(new Vector3(0, _myController.GetJumpSensor.forceJump, 0), ForceMode.Impulse);
        _myChar.GetAnimator.SetBool("OnFloor", false);
        _myController.GetJumpSensor.SetOnFloor(false);
    }

    public void Grub()
    {
        _myController.SetState(Entity.state.Grubbing);

        _myController.GetBoxSensor.canGrab = false;
        _myController.GetBoxSensor.boxRb.transform.position = _myController.GetBoxSensor.boxPos.position;
        _myController.GetBoxSensor.boxRb.rotation = _myController.GetBoxSensor.boxPos.rotation;
    }

    public void Sneak()
    {
        if (_myController.GetState() != Entity.state.Hurt)
        {
            _myController.SetState(Entity.state.Sneak);
            _myController.SetSpeed(_myChar.GetSpeed - 2);
        }
    }

    public virtual void AnimationUpdate()
    {
        _myAnimatorController.ArtificialUpdate();
    }
}
