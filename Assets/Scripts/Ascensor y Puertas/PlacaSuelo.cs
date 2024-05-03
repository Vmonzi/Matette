using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacaSuelo : MonoBehaviour
{
    public Puerta               door;
    Camera                      _currentCamera;
    Camera                      _toChange;
    [SerializeField] AudioSource _audio;

    private void Start()
    {
        door = GetComponentInChildren<Puerta>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BaseCharacter>())
        {
            _audio.Play();
            door.DoorMovement();

        }
        if(this.name == "BotonPlataformas")
        {
            _currentCamera = GameObject.Find("CameraMain").GetComponent<Camera>();
            _toChange = GameObject.Find("CameraDoors").GetComponent<Camera>();
            _currentCamera.enabled = !enabled;
            _toChange.enabled = enabled;
            Invoke("ChangeCameras", 2.0f);
        }
    }

    private void ChangeCameras()
    {
        _currentCamera = GameObject.Find("CameraMain").GetComponent<Camera>();
        _toChange = GameObject.Find("CameraDoors").GetComponent<Camera>();
        _currentCamera.enabled = enabled;
        _toChange.enabled = !enabled;
    }

}
