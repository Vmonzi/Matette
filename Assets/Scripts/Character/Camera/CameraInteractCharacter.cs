using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInteractCharacter : MonoBehaviour
{
    [Header("Camera Config")]
    [SerializeField] float      _angle = 40;
    [SerializeField] Transform  _crouchPosCam;
    [SerializeField] Transform  _currentPos;
    [SerializeField] Transform  _standPosCam;

    public Transform GetCurrentPosCamera { get { return _currentPos; } }
    public Transform GetInitialPosCamera { get { return _standPosCam; } }

    private float _speedToMove          = 1200;
    private float _sensibilityRotation  = 600;

    private float _mouseX;
    private float _mouseY;
    private float _rotY = 0;
    private float _rotX = 0;

    private void Start()
    {
        _standPosCam        = _currentPos;
        transform.position  = _currentPos.position;
        Vector3 rot         = transform.localRotation.eulerAngles;
        _rotY               = rot.y;
        _rotX               = rot.z;
    }

    // Update is called once per frame
    void Update()
    {
        _mouseX = Input.GetAxis("Mouse X");
        _mouseY = Input.GetAxis("Mouse Y");

        _rotY += _mouseX * _sensibilityRotation * Time.deltaTime;
        _rotX -= _mouseY * _sensibilityRotation * Time.deltaTime;

        _rotX = Mathf.Clamp(_rotX, -_angle, _angle);

        transform.rotation = Quaternion.Euler(_rotX, _rotY, 0);
    }

    private void LateUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, _currentPos.position, _speedToMove * Time.deltaTime);
    }

    public void ChangePosToCrouch()
    {
        _currentPos = _crouchPosCam;
        _angle = 10;
    }
    
    public void ChangePosToInitial()
    {
        _currentPos = _standPosCam;
        _angle = 40;
    }
}
