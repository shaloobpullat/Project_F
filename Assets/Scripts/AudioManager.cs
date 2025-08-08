using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource audioSource;

    public AudioClip buttonClick;
    public AudioClip matchSound;
    public AudioClip winSound;
    public AudioClip failSound;
    public AudioClip CardFlip;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // persist between scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    public void PlayButtonClick()
    {
        PlaySound(buttonClick);
    }
    public void PlayMatchSound() 
    { 
        PlaySound(matchSound); 
    }
    public void PlayWinSound()
    { 
        PlaySound(winSound); 
    }
    public void PlayFailSound()
    {
        PlaySound(failSound);
    }
    public void PlayCardFlip()
    {
        PlaySound(CardFlip);
    }
}
