using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    [SerializeField] AudioMixer mainMixer;

    [SerializeField] Slider masterVolumeSlider;
    [SerializeField] float masterVolumeCurrentValue = 0;
    bool noSound = false;
    [SerializeField] float masterVolumeSavedValue = 0;


    [SerializeField] Slider musicVolumeSlider;
    [SerializeField] float musicVolumeCurrentValue = 0;

    [SerializeField] Slider soundVolumeSlider;
    [SerializeField] float soundVolumeCurrentValue = 0;

    private void Start()
    {
        masterVolumeCurrentValue = -80 + (masterVolumeSlider.value * 2.5f);
        musicVolumeCurrentValue = -80 + (musicVolumeSlider.value * 2.5f);
        soundVolumeCurrentValue = -80 + (soundVolumeSlider.value * 2.5f);

        mainMixer.SetFloat("Master Volume", masterVolumeCurrentValue);
        mainMixer.SetFloat("Music Volume", musicVolumeCurrentValue);
        mainMixer.SetFloat("Sound Volume", soundVolumeCurrentValue);
    }

    public void SetMasterVolume()
    {
        if (!noSound) 
        {
            // The formula to transition 32 steps into the range from -80 to 0.
            float volumeToSet = -80 + (masterVolumeSlider.value * 2.5f);
            Debug.Log("SetMasterVolume: " + volumeToSet);
            mainMixer.SetFloat("Master Volume", volumeToSet);
            masterVolumeCurrentValue = volumeToSet;
        }
        else
        {
            mainMixer.SetFloat("Master Volume", -80f);
            masterVolumeCurrentValue = 0f;

            masterVolumeSlider.value = 0f;
        }
    }
    public void SetMusicVolume()
    {
        // The formula to transition 32 steps into the range from -80 to 0.
        float volumeToSet = -80 + (musicVolumeSlider.value * 2.5f);
        Debug.Log(volumeToSet);
        mainMixer.SetFloat("Music Volume", volumeToSet);
        musicVolumeCurrentValue = volumeToSet;
    }
    public void SetSoundVolume()
    {
        // The formula to transition 32 steps into the range from -80 to 0.
        float volumeToSet = -80 + (soundVolumeSlider.value * 2.5f);
        Debug.Log(volumeToSet);
        mainMixer.SetFloat("Sound Volume", volumeToSet);
        soundVolumeCurrentValue = volumeToSet;
    }
    public void SetNoSound(bool on)
    {
        Debug.Log("Toggle: " + on);
        if (on)
        {
            noSound = true;
            Debug.Log("SetNoSound, current value: " + masterVolumeCurrentValue);
            masterVolumeSavedValue = masterVolumeCurrentValue;
            mainMixer.SetFloat("Master Volume", -80f);
            Debug.Log("SetNoSound, saved value: " + masterVolumeSavedValue);
            masterVolumeSlider.value = 0;
        }
        else
        {
            noSound = false;
            mainMixer.SetFloat("Master Volume", masterVolumeSavedValue);
            masterVolumeSlider.value = (float)(0.4 * masterVolumeSavedValue + 32);
        }
    }
}
