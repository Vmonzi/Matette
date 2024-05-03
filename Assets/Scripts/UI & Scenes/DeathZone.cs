using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IPlayer>() != null)
        {
            GameManager.InstanceGameManager.LoadLevel("Lose");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<IPlayer>() != null)
        {
            GameManager.InstanceGameManager.LoadLevel("Lose");
        }
    }
}
