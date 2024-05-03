using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTarget : MonoBehaviour
{

    public delegate void ActivateWall();

    public event ActivateWall audioEvent;
    public event ActivateWall updateRange;

    [SerializeField] GameObject _player;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _player)
        {
            audioEvent();
            updateRange();
        }

    }
}
