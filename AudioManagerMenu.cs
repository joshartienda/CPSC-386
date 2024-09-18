using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerMenu : MonoBehaviour
{
    [Header("-Audio Source-")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("-Audio Clip-")]
    public AudioClip backgroundMenu;

    private void Start()
    {
        musicSource.clip = backgroundMenu;
        musicSource.Play();
      
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

}
