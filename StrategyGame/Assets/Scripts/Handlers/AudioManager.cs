using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public AudioMixer audioMixer;

    private void Awake()
    {
        if (GlobalVariables.audioManager == null)
        {
            GlobalVariables.audioManager = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent <AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            
            if ((int)s.type == 0)
            {
                s.source.outputAudioMixerGroup = audioMixer.FindMatchingGroups("Music")[0];
            }
            else if ((int)s.type == 1)
            {
                s.source.outputAudioMixerGroup = audioMixer.FindMatchingGroups("SFX")[0];
            }
            else
            {
                s.source.outputAudioMixerGroup = audioMixer.FindMatchingGroups("Master")[0];
            }
        }
    }

    private void Start()
    {
        Play("Theme");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + "does not exist in soundlist");
            return;
        }
        s.source.Play();
    }

    public void SetMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);
    }

    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", volume);
    }
}
