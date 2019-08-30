using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MusicManager : MonoBehaviour
{
    public AudioSource musicAudioSource;
    public AudioSource soundsFXAudioSource;

    void Start()
    {	
        Events.OnMusic += OnMusic;
		Events.OnSoundFX += OnSoundFX;
	}
    void OnMusic(string soundName)
    {
        if(soundName == "")
        {
            musicAudioSource.Stop();
        }
        AudioClip ac = Resources.Load("music/" + soundName) as AudioClip;
        musicAudioSource.clip = ac;
        musicAudioSource.loop = true;
        musicAudioSource.Play();
    }
    void OnSoundFX(string soundName)
    {
        if (soundName == "")
        {
            soundsFXAudioSource.Stop();
        }
        AudioClip ac = Resources.Load("sounds/" + soundName) as AudioClip;
        soundsFXAudioSource.clip = ac;
        soundsFXAudioSource.loop = true;
        soundsFXAudioSource.Play();
    }
}
