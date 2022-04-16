using System;
using UnityEngine;

public class OptionsManager : MonoBehaviour
{
    // TODO: Add toggle and slider + set initial values on start
    public void Awake()
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