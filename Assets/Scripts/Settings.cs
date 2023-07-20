using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{

    public AudioMixer audioMixer;
    Resolution[] resolutions;
    public TMP_Dropdown resDropdown;

    public void Start()
    {
        resolutions = Screen.resolutions;
        resDropdown.ClearOptions();

        List<string> options = new List<string>();
        int curResIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                curResIndex = i;
            }
        }

        resDropdown.AddOptions(options);
        resDropdown.value = curResIndex;
    }
    public void setRes(int resIndex)
    {
        Resolution resolution = resolutions[resIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void volumeSet(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
    }
    public void setQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }
    public void setFullscreen(bool isFull)
    {
        Screen.fullScreen = isFull;
    }
    public void Back()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
