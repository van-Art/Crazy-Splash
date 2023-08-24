using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public GameObject Audio;
    public GameObject Music;

    [Header("Audio Effect")]
    public GameObject AudioOn;
    public GameObject AudioOff;

    [Header("Music Effect")]
    public GameObject MusicOn;
    public GameObject MusicOff;

    public bool soundMuted = false;
    public bool muted = false;

    void Start()
    {
        audioEffect();
        musicEffect();
    }
    void audioEffect()
    {
        if(!PlayerPrefs.HasKey("soundMuted"))
        {
            PlayerPrefs.SetInt("soundMuted", 0);
            LoadAudioInfo();
        }
        else
        {
            LoadAudioInfo();
        }
        UpdateSoundButtonIcon();
    }
    void musicEffect()
    {
        if(!PlayerPrefs.HasKey("muted"))
        {
            PlayerPrefs.SetInt("muted", 0);
            LoadMusicInfo();
        }
        else
        {
            LoadMusicInfo();
        }
        UpdateMusicButtonIcon();
    }
    public void SettingsButtonOn()
    {
        if (!Audio.activeInHierarchy && !Music.activeInHierarchy)
        {
            Audio.SetActive(true);
            Music.SetActive(true);
        }
        else
        {
            Audio.SetActive(false);
            Music.SetActive(false);
        }
    }

    public void AudioButtonDown()
    {
        if (soundMuted == false)
        {
            soundMuted = true;
            AudioController.instance.audioSrc.volume = 0;
        }
        else
        {
            soundMuted = false;
            AudioController.instance.audioSrc.volume = 100;
        }
        UpdateSoundButtonIcon();
        SaveAudioInfo();
    }
    void UpdateSoundButtonIcon()
    {
        if (soundMuted == false)
        {
            AudioOn.SetActive(true);
            AudioOff.SetActive(false);
            AudioController.instance.audioSrc.volume = 100;
        }
        else
        {
            AudioOn.SetActive(false);
            AudioOff.SetActive(true);
            AudioController.instance.audioSrc.volume = 0;
        }
    }
    public void MusicButtonDown()
    {
        if (muted == false)
        {
            muted = true;
            AudioController.instance.musicSrc.volume = 0;
        }
        else
        {
            muted = false;
            AudioController.instance.musicSrc.volume = 100;
        }
        UpdateMusicButtonIcon();
        SaveMusicInfo();
    }
    void UpdateMusicButtonIcon()
    {
        if (muted == false)
        {
            MusicOn.SetActive(true);
            MusicOff.SetActive(false);
            AudioController.instance.musicSrc.volume = 100;
        }
        else
        {
            MusicOn.SetActive(false);
            MusicOff.SetActive(true);
            AudioController.instance.musicSrc.volume = 0;
        }
    }
    void LoadAudioInfo()
    {
        soundMuted = PlayerPrefs.GetInt("soundMuted") == 1;
        float audioVolume = PlayerPrefs.GetFloat("AudioVolume");
        AudioController.instance.audioSrc.volume = audioVolume;
    }
    void SaveAudioInfo()
    {
        float audioVolume = AudioController.instance.audioSrc.volume;
        PlayerPrefs.SetInt("soundMuted", soundMuted ? 1 : 0);
        PlayerPrefs.GetFloat("AudioVolume", audioVolume);
    }
    void LoadMusicInfo()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
        float musicVolume = PlayerPrefs.GetFloat("MusicVolume");
        AudioController.instance.musicSrc.volume = musicVolume;
    }
    void SaveMusicInfo()
    {
        float musicVolume = AudioController.instance.musicSrc.volume;
        PlayerPrefs.SetInt("muted", muted ? 1 : 0);
        PlayerPrefs.GetFloat("MusicVolume", musicVolume);
    }
}
