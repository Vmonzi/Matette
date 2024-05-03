using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    public static SoundController Instance;
    public float _currentValue;

    public float GetValue { get { return _currentValue; } }

    void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            ChangeVolume(1);
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    public void ChangeVolume(float value)
    {
        _currentValue = value;
        PlayerPrefs.SetFloat("musicVolume", _currentValue);
        PlayerPrefs.Save();
        LoadChanges();
    }

    void LoadChanges()
    {
        _currentValue = PlayerPrefs.GetFloat("musicVolume");
        AudioListener.volume = PlayerPrefs.GetFloat("musicVolume");
    }
}
