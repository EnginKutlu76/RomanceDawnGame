using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Sounds : MonoBehaviour
{
    public AudioMixer musicMixer;
    public AudioSource backgroundAs;
    public float masterVolume;

    void Start()
    {
        PlayAudio(backgroundAs); 
    }
    void Update()
    {
        MasterVolume();
    }
    public void PlayAudio(AudioSource audio)
    {
        audio.Play(); 
    }
    public void MasterVolume()
    {
        musicMixer.SetFloat("Background", masterVolume);
    }
}
