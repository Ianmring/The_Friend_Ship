using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]

public class Sound
{
    public string Name;
    public AudioClip Clip;

    public AudioClip[] Clips;

    [Range(0, 1)]
    public float Volume;

    [Range (0,1)]
    public float Pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source;

    public bool RandomSelction;
}
