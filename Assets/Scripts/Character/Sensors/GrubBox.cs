using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Ivo Joaquín Aguilera

public class GrubBox : MonoBehaviour
{
    public Text         pressE;
    public Transform    boxPos;
    public Transform    rotator;
    public float        releaseForce;
    public bool         grubbed;
    public bool         canGrab;
    public Rigidbody    boxRb;
    public Vector3      directionBox;

    // Start is called before the first frame update
    void Start()
    {
        grubbed = false;
        canGrab = false;
        pressE.enabled = !enabled;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 22 && !grubbed)
        {
            canGrab = true;
            boxRb = other.GetComponent<Rigidbody>();
            pressE.enabled = enabled;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 22)
        {
            canGrab = false;
            pressE.enabled = !enabled;
        }
    }
}
