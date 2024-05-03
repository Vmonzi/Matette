using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedDestroy : MonoBehaviour
{
    //Casella, Maximiliano

    [SerializeField] GameObject _walls;
    [SerializeField] GameObject _particles;
    public AudioSource _audio;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == _walls)
        {

            Instantiate(_particles, transform.position, Quaternion.identity);
            Destroy(gameObject,0.5f);
            
        }
       
    }
}
