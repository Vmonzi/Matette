using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSlider : MonoBehaviour
{
    Slider _soundSlider;

    private void Awake()
    {
        _soundSlider = GetComponent<Slider>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _soundSlider.value = SoundController.Instance.GetValue;
    }

    public void ChangeSound() 
    {
        SoundController.Instance.ChangeVolume(_soundSlider.value);
    }
}
