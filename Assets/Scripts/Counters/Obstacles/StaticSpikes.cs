using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticSpikes : MonoBehaviour
{
    [SerializeField] GameObject _player;

    [SerializeField] float _dmg = 100;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _player)
        {
            _player.GetComponent<BaseCharacter>().ReceiveDamage(_dmg);
        }
    }
}
