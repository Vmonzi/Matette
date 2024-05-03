using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMov : MonoBehaviour
{
    public Transform trText;
    public Transform trPj;
    public Camera cam;

    void Update()
    {
        // transform.LookAt(trPj.transform);
        //transform.LookAt(transform.position + cam.transform.rotation * Vector3.forward);
        //Vector3 camRot  = new Vector3(cam.transform.rotation);

    }
}
