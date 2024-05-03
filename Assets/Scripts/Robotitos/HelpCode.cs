using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpCode : MonoBehaviour, IHelpRobots
{
    //Monzi Victoria
    public GameObject text;
    public GameObject helpText;

    [SerializeField] AudioSource _audio;

    private void Start()
    {
        ExitText();
        ExitHelpText();
    }

    public void Text()
    {
        text.SetActive(true);
    }

    public void HelpText()
    {
        _audio.Play();
        helpText.SetActive(true);
        ExitText();
    }

    public void ExitText()
    {
        text.SetActive(false);
    }

    public void ExitHelpText()
    {
        helpText.SetActive(false);
    }

}

