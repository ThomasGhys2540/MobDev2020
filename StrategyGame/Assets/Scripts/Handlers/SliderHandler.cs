using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderHandler : MonoBehaviour
{
    public GameObject AudioMaster;
    public AudioManager audioManager;
    public Slider music;
    public Slider sfx;

    private void Awake()
    {
        audioManager = GameObject.Find("AudioMaster").GetComponent<AudioManager>();
        music = GameObject.Find("Music").GetComponent<Slider>();
        sfx = GameObject.Find("SFX").GetComponent<Slider>();
    }

    private void Start()
    {
        UpdateSlider();
    }

    public void UpdateSlider()
    {
        float tempVolume;

        audioManager.audioMixer.GetFloat("MusicVolume", out tempVolume);
        music.value = tempVolume;
        audioManager.audioMixer.GetFloat("SFXVolume", out tempVolume);
        sfx.value = tempVolume;
    }

    public void SetMusicVolume(float volume)
    {
        audioManager.SetMusicVolume(volume);
    }

    public void SetSFXVolume(float volume)
    {
        audioManager.SetSFXVolume(volume);
    }
}
