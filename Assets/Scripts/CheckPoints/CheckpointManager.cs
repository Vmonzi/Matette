using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager Instance;

    private float checkpointX, checkpointY, checkpointZ;

    private void Awake()
    {
        if (!Instance) Instance = this;
        else Destroy(this);
    }

    private void Start()
    {
        if(PlayerPrefs.HasKey("currentScene") && PlayerPrefs.HasKey("checkpointX") && PlayerPrefs.HasKey("checkpointY") && PlayerPrefs.HasKey("checkpointZ"))
        {
            this.transform.position = new Vector3(PlayerPrefs.GetFloat("checkpointX"), PlayerPrefs.GetFloat("checkpointY"), PlayerPrefs.GetFloat("checkpointZ"));
        }
    }

    public void NewCheck(Transform newCheck)
    {
        PlayerPrefs.SetFloat("checkpointX", newCheck.position.x);
        PlayerPrefs.SetFloat("checkpointY", newCheck.position.y);
        PlayerPrefs.SetFloat("checkpointZ", newCheck.position.z);
        PlayerPrefs.SetString("currentScene", SceneManager.GetActiveScene().name);
        PlayerPrefs.Save();
    }
}
