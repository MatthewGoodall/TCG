using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour {

    public AudioMixer Master;

    public Dropdown resolutionDropDown;

    Resolution[] resolution;

    private void Start()
    {
        resolution = Screen.resolutions;
        resolutionDropDown.ClearOptions();
        

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for(int i = 0; i < resolution.Length; i++)
        {
            string option = resolution[i].width + " x " + resolution[i].height;
            options.Add(option);

            if(resolution[i].width == Screen.currentResolution.width &&
                resolution[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = currentResolutionIndex;
        resolutionDropDown.RefreshShownValue();
    }

    public void SetVolume(float volume)
    {
        Master.SetFloat("volume", volume);
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullsceen)
    {
        Screen.fullScreen = isFullsceen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution res = resolution[resolutionIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }
}
