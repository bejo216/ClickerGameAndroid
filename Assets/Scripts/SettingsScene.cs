using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;
using System;

public class SettingsScene : MonoBehaviour
{
    public AudioMixer mainMixer;

    public Slider masterSlider;
    public Slider SFXSlider;
    public Slider musicSlider;

    public void Awake()
    {
        masterSlider.value = PlayerData.Instance.masterVolume;
        SFXSlider.value = PlayerData.Instance.sfxVolume;
        musicSlider.value = PlayerData.Instance.musicVolume;
    }
    // For Master Volume
    public void SetMasterVolume(float volume)
    {
        mainMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
        PlayerData.Instance.masterVolume = volume;
    }

    // For SFX Volume
    public void SetSFXVolume(float volume)
    {
        mainMixer.SetFloat("SFXVolume", Mathf.Log10(volume) * 20);
        PlayerData.Instance.sfxVolume = volume;
    }

    // For Music Volume
    public void SetMusicVolume(float volume)
    {
        mainMixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
        PlayerData.Instance.musicVolume = volume;
    }

    
}
