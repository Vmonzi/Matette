using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Placa : RobotColor
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IPlayer>() != null)
        {
            ChangeColor();
            CheckpointManager.Instance.NewCheck(this.transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        TextOff();
    }
}
