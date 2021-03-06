using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Dropdown resolutionDropDown;
    Resolution[] resolutions;
    void Awake()
    {
        resolutions = Screen.resolutions;
        resolutionDropDown.ClearOptions();

        int currentResolutionIndex = 0;
        List<string> options = new List<string>();
        for(int i = 0; i < resolutions.Length; i++) 
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            
                options.Add(option);
            
            

            if(resolutions[i].width == Screen.currentResolution.width
            && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
                
        }
        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = currentResolutionIndex;
        resolutionDropDown.RefreshShownValue();
    }
    // Start is called before the first frame update
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetFullscreen(bool isF)
    {
        Screen.fullScreen = isF;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
