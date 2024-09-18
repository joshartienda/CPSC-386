using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("-Audio Source-")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("-Audio Clip-")]
    public AudioClip backgroundMenu;
    public AudioClip backgroundLevel1;
    public AudioClip death;
    public AudioClip jump;

    private void Start()
    {
        musicSource.clip = backgroundLevel1;
        musicSource.Play();
      
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

}
