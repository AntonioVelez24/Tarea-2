using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SliderValue : MonoBehaviour
{
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;
    // Start is called before the first frame update
    void Start()
    {
        masterSlider.value = VolumeControl.Instance.GetMasterVolume();
        masterSlider.onValueChanged.AddListener(SetMasterVolume);

        musicSlider.value = VolumeControl.Instance.GetMusicVolume();
        musicSlider.onValueChanged.AddListener(SetMusicVolume);

        sfxSlider.value = VolumeControl.Instance.GetSFXVolume();
        sfxSlider.onValueChanged.AddListener(SetSfxVolume);
    }
    private void SetMasterVolume(float volume)
    {
        VolumeControl.Instance.masterVolume = volume;
        VolumeControl.Instance.SetMasterVolume(volume);
    }
    private void SetMusicVolume(float volume)
    {
        VolumeControl.Instance.musicVolume = volume;
        VolumeControl.Instance.SetMusicVolume(volume);
    }
    private void SetSfxVolume(float volume)
    {
        VolumeControl.Instance.musicVolume = volume;
        VolumeControl.Instance.SetSfxVolume(volume);
    }
}
