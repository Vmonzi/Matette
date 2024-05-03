using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandUpSensor : MonoBehaviour
{
    public bool canStand;
    [SerializeField] BaseCharacter _myChar;

    // Start is called before the first frame update
    void Start()
    {
        canStand = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (_myChar.GetController.GetState() == Entity.state.Craw)
        {
            canStand = false;
            if (other.GetComponent<IHelpRobots>() != null) canStand = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        canStand = true;
    }
}
