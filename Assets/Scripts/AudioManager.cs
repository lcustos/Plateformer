using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    
    public Sound[] MusicSounds, SFXSounds;
    public AudioSource MusicSource, SFXSource;
    
    private void Awake()
    {
        if (instance == null)
            instance = this;
            
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
    
    private void Start()
    {
        PlayMusic("hurry_up_and_run");
    }
    
    public void PlayMusic(string name)
    {
        Sound s = Array.Find(MusicSounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound: " + name + " not found!");
            return;
        }
        else
        {
            MusicSource.clip = s.clip;
            MusicSource.Play();
        }
    }
    public void PlaySFX(string name)
    {
        Sound s = Array.Find(SFXSounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound: " + name + " not found!");
            return;
        }
        else
        {
            SFXSource.clip = s.clip;
            SFXSource.Play();
        }
    }
    
    public void ToggleMusic()
    {
        MusicSource.mute = !MusicSource.mute;
    }
    
    public void ToggleSFX()
    {
        SFXSource.mute = !SFXSource.mute;
    }
    
    public void MusicVolume(float volume)
    {
        MusicSource.volume = volume;
    }
    
    public void SFXVolume(float volume)
    {
        SFXSource.volume = volume;
    }
}
