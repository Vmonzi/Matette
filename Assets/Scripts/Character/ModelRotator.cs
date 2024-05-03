using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ivo Joaquín Aguilera

public class ModelRotator
{
    Transform   _relativeCameraForward;
    Transform   _relativeForward;
    Transform   _toRotate;

    public ModelRotator(Transform toRotate, Transform relativeCameraForward, Transform relativeForward)
    {
        _toRotate = toRotate;
        _relativeCameraForward = relativeCameraForward;
        _relativeForward = relativeForward;
    }

    // Update is called once per frame
    public void Rotar(Vector3 rotateInput)
    {
        Vector3 cameraForward   = _relativeCameraForward.transform.forward;
        cameraForward.y         = 0;

        //Rotación relativa
        Quaternion RelativeRotation = Quaternion.FromToRotation(_relativeForward.forward, cameraForward);
        Vector3 lookToward = RelativeRotation * rotateInput;

        //Rotar
        if (rotateInput.sqrMagnitude > 0)
        {
            Ray lookRay = new Ray(_toRotate.transform.position, lookToward);
            _toRotate.transform.LookAt(lookRay.GetPoint(1));
        }
    }
}
