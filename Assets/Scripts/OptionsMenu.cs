using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] TMPro.TMP_Dropdown resolutionDropdown;
    [SerializeField] TMPro.TMP_Dropdown qualityDropdown;
    [SerializeField] Toggle fullscreenToggle;
    [SerializeField] Toggle vSyncToggle;
    Resolution[] availableResolutions;
    [SerializeField] int savedVSyncCount;

    private void Start()
    {
        savedVSyncCount = QualitySettings.vSyncCount;

        if (savedVSyncCount == 0)
        {
            vSyncToggle.isOn = false;
        }
        else vSyncToggle.isOn = true;

        if (Screen.fullScreen)
        {
            fullscreenToggle.isOn = true;
        }
        else fullscreenToggle.isOn = false;

        availableResolutions = Screen.resolutions.Where(resolution => resolution.refreshRate == 60).ToArray();

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i = 0; i < availableResolutions.Length; i++)
        {
            string option = availableResolutions[i].width + " x " + availableResolutions[i].height;
            options.Add(option);

            if (availableResolutions[i].width == Screen.currentResolution.width &&
                availableResolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        int currentQualityIndex = QualitySettings.GetQualityLevel();
        qualityDropdown.value = currentQualityIndex;
        qualityDropdown.RefreshShownValue();
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Debug.Log("Application was set to full screen: " + isFullscreen);
        Screen.fullScreen = isFullscreen;
    }

    public void SetVSync(bool isOn)
    {
        if (!isOn) 
        {
            savedVSyncCount = QualitySettings.vSyncCount;
            QualitySettings.vSyncCount = 0;
        }
        else
        {
            QualitySettings.vSyncCount = savedVSyncCount;
        }
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolutionToSet = availableResolutions[resolutionIndex];
        Screen.SetResolution(resolutionToSet.width, resolutionToSet.height, Screen.fullScreen);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
