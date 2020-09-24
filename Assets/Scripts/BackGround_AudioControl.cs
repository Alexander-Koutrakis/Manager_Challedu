using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround_AudioControl : MonoBehaviour
{
    public static BackGround_AudioControl Instance;
    public AudioSource BackMusicSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        BackMusicSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
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
}
