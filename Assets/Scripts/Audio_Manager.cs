using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Manager : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] audioClips;

    public AudioSource SFXaudioSource;
    public static Audio_Manager Instance;
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
            Destroy(Audio_Manager.Instance.gameObject);
            Instance = this;
        }

        DontDestroyOnLoad(gameObject);
      
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

    

  

    
}
