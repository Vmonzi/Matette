using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Ivo Joaquín Aguilera

public class Controller : Entity
{
    [Header("Sensors")]
    JumpSensor       _jumpSensor;
    GrubBox          _sensorBox;
    StandUpSensor    _canStand;

    public JumpSensor       GetJumpSensor       { get { return _jumpSensor; } }
    public GrubBox          GetBoxSensor        { get { return _sensorBox; } }
    public StandUpSensor    GetStandUpSensor    { get { return _canStand; } }

    BaseCharacter   _myChar;
    States          _myStates;
    ModelRotator    _myRotator;
    bool            _activeController;
    float           _verticalDir;
    float           _horizontalDir;

    public ModelRotator GetModelRotator { get { return _myRotator; } }

    public Controller(BaseCharacter myChar, JumpSensor jumpSensor, GrubBox boxSensor, StandUpSensor canStand)
    {
        _myChar     = myChar;
        _myStates   = new States(this, myChar);
        _myRotator  = new ModelRotator(myChar.GetRotator, myChar.GetCamera, myChar.transform);
        _jumpSensor = jumpSensor;
        _sensorBox  = boxSensor;
        _canStand   = canStand;

        SetSpeed(myChar.GetSpeed);
        SetState(state.IDLE);
    }

    // Update is called once per frame
    public void ControllerUpdate()
    {
        if (_activeController)
        {
            _verticalDir            = Input.GetAxis("Vertical");
            _horizontalDir          = Input.GetAxis("Horizontal");
            _myStates.SetRotation   = new Vector3(_horizontalDir, 0, _verticalDir).normalized;
            _myStates.SetDirection  = (_myChar.GetCamera.forward * _verticalDir + _myChar.GetCamera.right * _horizontalDir).normalized;

            if (Input.GetButtonDown("Jump") && _jumpSensor.IsOnFloor() && GetState() != state.Craw && GetState() != state.Grubbing && GetState() != state.Sneak)
            {
                _myStates.Jump();
            }
            else if ((_verticalDir != 0 || _horizontalDir != 0))
            {
                if (Input.GetKey(KeyCode.LeftShift) && GetState() != state.Grubbing && GetState() != state.Craw && GetState() != state.Sneak)
                {
                    _myStates.Run();
                }
                else if (Input.GetKey(KeyCode.C) && GetState() != state.Grubbing && GetState() != state.Craw) 
                {
                    _myStates.Sneak();
                }
                else
                {
                    _myStates.Walk();
                    if (GetState() == state.Craw)
                    {
                        _myChar.GetAnimator.SetBool("Walking", true);
                    }
                }
            }
            else if (_jumpSensor.IsOnFloor() && GetState() != state.Hurt && !_jumpSensor.IsFalling())
            {
                SetState(state.IDLE);
                _myChar.UpdateFeedback.StopSound();
            }

            _myStates.Move();

            if (_jumpSensor.IsOnFloor() && !_jumpSensor.IsFalling() && GetState() != state.Hurt && GetState() != state.Running && GetState() != state.Sneak)
            {
                if (_sensorBox.grubbed && Input.GetKeyDown("e"))
                {
                    _sensorBox.grubbed = false;
                    _sensorBox.directionBox = _sensorBox.rotator.forward;

                    _myChar.GetAnimator.SetBool("Grubbing", false);

                    _sensorBox.boxRb = null;
                    _myChar.UpdateFeedback.TextToDrop(false);
                }
                else if (Input.GetKeyDown("e") && !_sensorBox.grubbed && _sensorBox.canGrab && _sensorBox.isActiveAndEnabled)
                {
                    _sensorBox.grubbed = true;
                    _myChar.UpdateFeedback.TextToDrop(true);
                }
                if (_sensorBox.grubbed)
                {
                    _myStates.Grub();
                }
                else if(GetState() != state.Grubbing)
                {
                    if (Input.GetKey(KeyCode.LeftControl) && GetState() != state.Craw)
                    {
                        _myStates.Craw();
                    }
                    else if (!Input.GetKey(KeyCode.LeftControl) && _canStand.canStand)
                    {
                        _myChar.ColliderStand();

                        _myChar.GetCameraInteract.ChangePosToInitial();

                        _myChar.GetAnimator.SetBool("Crouch", false);
                        _sensorBox.enabled       = true;

                    }
                    else
                    {
                        _myStates.Craw();
                    }
                }
            }
        }
    }

    public void ControllerFixedUpdate()
    {
        if (_jumpSensor.IsOnFloor())
        {
            _myStates.AnimationUpdate();
        }
    }

    public void SetActiveController(bool active)
    {
        _activeController = active;
    }
}
