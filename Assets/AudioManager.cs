using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("------- Audio Source -------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [Header("------- Audio Clip -------")]
    public AudioClip Music;
    public AudioClip Swim;
    public AudioClip PickUp;

    private void Start()
    {
        musicSource.clip = Music;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip != null)
        {
           SFXSource.PlayOneShot(clip);
        }
    }
}
