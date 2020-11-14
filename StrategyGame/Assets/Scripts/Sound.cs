using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public enum Type { Music, SFX};

[System.Serializable]
public class Sound
{
    public string name;
 
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume;
    [Range(0f, 5f)]

    public float pitch;
    public bool loop;

    public Type type;

    [HideInInspector]
    public AudioSource source;
}
