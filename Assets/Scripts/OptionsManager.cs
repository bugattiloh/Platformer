using System;
using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    public Toggle toggle;

    private void Awake()
    {
    }

    public void SetVolume(float volume)
    {
        AudioManager.Instance.SetVolume(volume);
    }

    public void Sound()
    {
        AudioManager.Instance.Sound();
    }
}