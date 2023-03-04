using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    [SerializeField] private AudioMixer mainMixer;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.AudioFile;
            s.source.loop = s.Loop;
            s.source.volume = s.Volume;
            s.source.pitch = s.Pitch;
        }
    }
    void Start()
    {
        Play("mushroom");
        Debug.Log("musicccc!!!");
    }
    public void Play(string songName)
    {
        Sound s = Array.Find(sounds, sound => sound.Name == songName);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + songName + "not found.");
            return;
        }
        MixerEnum targetMixerGroup = s.TargetOutput;
        s.source.Play();
        s.source.outputAudioMixerGroup = mainMixer.FindMatchingGroups(targetMixerGroup.ToString())[0];
        s.source.volume = s.Volume;
        s.source.pitch = s.Pitch;
    }
}
