using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    public AudioClip GetScoreClip;
    public AudioClip DeathClip;
    public AudioClip GetCoinClip;
    private static AudioManager instance;
    public static AudioManager Instacne
    {
        get
        {
            return instance;
        }
    }

    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public void PlayGetScoreAudio()
    {
        AudioSource.PlayClipAtPoint(GetScoreClip, Camera.main.transform.position);
    }

    public void PlayDeathAudio()
    {
        AudioSource.PlayClipAtPoint(DeathClip, Camera.main.transform.position);
    }

    public void PlayCoinAudio()
    {
        AudioSource.PlayClipAtPoint(GetCoinClip, Camera.main.transform.position);
    }
}
