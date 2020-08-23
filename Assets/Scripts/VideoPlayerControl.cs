using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class VideoPlayerControl : MonoBehaviour
{
    [SerializeField]
    private List<VideoClip> videoList = new List<VideoClip>();
    [SerializeField]
    private VideoPlayer videoPlayer;

    private void OnEnable()
    {
        videoPlayer.Stop();
    }


    public void PlayVideo()
    {
        int x = Random.Range(0, videoList.Count);
        videoPlayer.clip = videoList[x];
        videoList.RemoveAt(x);
        videoPlayer.Play();
    }

    public void PauseVideo()
    {
        videoPlayer.Pause();
    }

    public void StopVideo()
    {
        videoPlayer.Stop();
    }

    public void ContinueVideo()
    {
        videoPlayer.Play();
    }
}
