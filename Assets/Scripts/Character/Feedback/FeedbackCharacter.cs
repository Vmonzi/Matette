using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FeedbackCharacter : MonoBehaviour
{
    [Header("Feedback")]
    [SerializeField] AudioSource    _myAudio;
    [SerializeField] AudioClip      _soundDamage;
    [SerializeField] Image          _lifeBar;
    [SerializeField] AudioClip      _soundWalk;
    [SerializeField] Text           _toDrop;

    public void UpdateLife(float life) { _lifeBar.fillAmount = life; }
    public void ChangeColorBarLife(Color newColor) { _lifeBar.color = newColor; }
    public void TextToDrop(bool enabled) { _toDrop.enabled = enabled; }
    public void SoundDamage() { _myAudio.clip = _soundDamage; }
    public void ChangePitch(float newPitch) { _myAudio.pitch = newPitch; }
    public void PlaySound() { _myAudio.Play(); }
    public void StopSound() { _myAudio.Stop(); }

    public void SoundWalk()
    {
        _myAudio.clip = _soundWalk;
        ChangePitch(1.0f);
        PlaySound();
    }

    public void SoundRunning()
    {
        _myAudio.clip = _soundWalk;
        ChangePitch(1.35f);
        PlaySound();
    }
}
