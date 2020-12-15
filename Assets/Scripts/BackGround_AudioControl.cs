using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround_AudioControl : MonoBehaviour
{
    public static BackGround_AudioControl Instance;
    public AudioSource BackMusicSource;
    private bool muted;
    [SerializeField]
    private AudioSource OfficeClip;
    [SerializeField]
    private AudioSource OtherClip;
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
            muted = true;
        }
        else
        {
            BackMusicSource.volume = 1;
            muted = false;
        }
    }


    public void FadeOutMusic(AudioClip newClip)
    {
        if(!muted)
        StartCoroutine(fadeOut(newClip));
    }


    private IEnumerator fadeOut(AudioClip newClip)
    {
        while(BackMusicSource.volume > 0.01f)
        {
            Debug.Log("fade out");
            BackMusicSource.volume = Mathf.Lerp(BackMusicSource.volume, 0, Time.deltaTime * 5);
            yield return null;
        }
     
        BackMusicSource.clip = newClip;
        BackMusicSource.Play();
        while (BackMusicSource.volume < 0.95f)
        {
            Debug.Log("fade in");
            BackMusicSource.volume = Mathf.Lerp(BackMusicSource.volume, 1, Time.deltaTime * 5);
            yield return null;
        }

    }


}
