using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovNextLevel : MonoBehaviour
{
    public float rotZ = 50;
    private void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, rotZ) * Time.deltaTime);

    }

}
