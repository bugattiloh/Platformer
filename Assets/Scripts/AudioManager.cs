using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Random = System.Random;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance => _instance;
    private static AudioManager _instance;

    public AudioMixer audioMixer;

    private AudioSource _player;

    public List<AudioClip> tracks;
    

    private readonly Random _random = new Random(DateTime.Now.Millisecond);

    private void Awake()
    {
        _player = GetComponent<AudioSource>();
        SaveMusicPlay();
        NextTrack();
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
        
    }

    public void Sound()
    {
        AudioListener.pause = !AudioListener.pause;
    }

    private void SaveMusicPlay()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            NextTrack();
        }
    }

    private void NextTrack()
    {
        _player.Stop();
        _player.clip = tracks[_random.Next(0, tracks.Count)];
        _player.Play();
    }
}