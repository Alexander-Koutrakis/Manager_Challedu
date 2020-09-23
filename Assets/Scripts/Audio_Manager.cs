using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Manager : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] audioClips;

    public AudioSource SFXaudioSource;
    public AudioSource BackMusicSource;
    public static Audio_Manager Instance;
    public float BackgroundVolume;
    public void Awake()
    {
        if (Instance == null)
        {
            Debug.Log("first audio");
            Instance = this;
        }else if (Instance != null)
        {
            Debug.Log("second audio");
            this.SFXaudioSource.volume = Audio_Manager.Instance.SFXaudioSource.volume;
            this.BackMusicSource.volume = Audio_Manager.Instance.BackgroundVolume;
            this.BackgroundVolume = Audio_Manager.Instance.BackgroundVolume;
            Destroy(Audio_Manager.Instance.gameObject);
            Instance = this;
        }

        DontDestroyOnLoad(gameObject);
      
    }


    private void Start()
    {
       
        BackMusicSource.Play();
    }



    public void FadeoutSound()
    {
        StartCoroutine(FadeBackgroundTrack());
    }

    public void Play_Sound(string audioclip)
    {
        AudioClip currentClip=null;
        foreach(AudioClip clip in audioClips)
        {
            if (clip.name == audioclip)
            {
                currentClip = clip;
            }
        }

        if(currentClip != null)
            SFXaudioSource.PlayOneShot(currentClip);
    }

    public void MuteSFX()
    {
        if (SFXaudioSource.volume > 0)
        {
            SFXaudioSource.volume = 0;
        }
        else
        {
            SFXaudioSource.volume = 1;
        }
    }

    public void MuteBackMusic()
    {
        if (BackMusicSource.volume > 0)
        {
            BackMusicSource.volume = 0;
        }
        else
        {
            BackMusicSource.volume = 1;
        }
    }

    private IEnumerator FadeBackgroundTrack()
    {
        while (BackMusicSource.volume > 0)
        {
            BackMusicSource.volume--;
            yield return new WaitForSeconds(0.05f);
        }
    }

    
}
