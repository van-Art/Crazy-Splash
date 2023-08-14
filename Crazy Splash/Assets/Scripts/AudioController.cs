using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;

    [Header("Audio Sources")]
    public AudioSource audioSrc;
    public AudioSource musicSrc;
    public AudioClip[] clips;

    public bool isPlaying;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        isPlaying = true;
        PlayMusic(musicSrc);
    }
    void PlayMusic(AudioSource newMusicSrc)
    {
        if(isPlaying)
        {
            musicSrc.clip = clips[Random.Range(0, clips.Length)];
            musicSrc.Play();
        }
    }
    public void AudioPlay()
    {
        audioSrc.Play();
    }
}
