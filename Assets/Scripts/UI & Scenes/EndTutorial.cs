using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTutorial : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            GameManager.InstanceGameManager.LoadLevel("Menu");
        }
    }
}
