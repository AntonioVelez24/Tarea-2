using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeControl : MonoBehaviour
{
    public static VolumeControl Instance { get; private set; }
    public AudioMixer gameVolumeMixer;
    public float masterVolume = 1f;
    public float musicVolume = 1f;
    public float sfxVolume = 1f;
    private bool isMuted = false;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    public void SetMasterVolume(float volume)
    {
        gameVolumeMixer.SetFloat("Master", Mathf.Log10(volume) * 20);
    }
    public void SetMusicVolume(float volume)
    {        
        gameVolumeMixer.SetFloat("Music", Mathf.Log10(volume) * 20);
    }
    public void SetSfxVolume(float volume)
    {
        gameVolumeMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
    }

    public float GetMasterVolume()
    {
        return masterVolume;
    }

    public float GetMusicVolume()
    {
        return musicVolume;
    }

    public float GetSFXVolume()
    {
        return sfxVolume;
    }
    public void MuteGame()
    {
        if (isMuted == false)
        {
            isMuted = true;
            masterVolume = 0f;
            gameVolumeMixer.SetFloat("Master", Mathf.Log10(masterVolume) * 20);
        }
        else
        {
            isMuted = false;
            gameVolumeMixer.SetFloat("Master", Mathf.Log10(masterVolume) * 20);
        }
    }
}
