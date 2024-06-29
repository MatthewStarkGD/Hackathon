using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Slider volumeSlider;
    public void OpenSettings()
    {
        gameObject.SetActive(true); 
    }

    
    public void CloseSettings()
    {
        gameObject.SetActive(false); 
    }

    void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 0.75f);
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float volume)
    {
        AudioManager.instance.SetVolume(volume);
        PlayerPrefs.SetFloat("Volume", volume);
    }
}


