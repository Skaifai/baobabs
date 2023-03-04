using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    [SerializeField] private string name;
    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    [SerializeField] private MixerEnum targetOutput;
    public MixerEnum TargetOutput
    {
        get { return this.targetOutput; }
        set { this.targetOutput = value; } 
    }
    
    [SerializeField] private AudioClip audioFile;
    public AudioClip AudioFile
    {
        get { return this.audioFile; }
        set { this.audioFile = value; }
    }

    [SerializeField] [Range(0f, 1f)] private float volume;
    public float Volume
    {
        get { return this.volume; }
        set { this.volume = value; }
    }

    [SerializeField] [Range(0.1f, 3f)] private float pitch;
    public float Pitch
    {
        get { return this.pitch; }
        set { this.pitch = value; }
    }

    [SerializeField] private bool loop;
    public bool Loop
    {
        get { return this.loop; }
        set { this.loop = value; }
    }

    [HideInInspector]
    public AudioSource source;
}
