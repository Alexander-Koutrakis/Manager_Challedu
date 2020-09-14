using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class VideoPlayerControl : MonoBehaviour
{
    [SerializeField]
    private List<VideoClip> videoList = new List<VideoClip>();
    public List<VideoClip> AllvideoList = new List<VideoClip>();
    [SerializeField]
    private VideoPlayer videoPlayer;
    public static VideoPlayerControl Instance;
    public bool warning = false;
    [SerializeField]
    private RectTransform warningSign = null;
    private void OnEnable()
    {
        videoPlayer.Stop();
    }

    private void Start()
    {
        videoPlayer.loopPointReached += EndOfVideo;
        Instance = this;
        gameObject.SetActive(false);

    }
    public void FillPlayer(int allVideos)
    {
        Debug.Log("here");
        for(int i = 0; i < allVideos; i++)
        {
            Debug.Log("here");
            int x = Random.Range(0, AllvideoList.Count);
            videoList.Add(AllvideoList[x]);
            AllvideoList.RemoveAt(x);
        }
    }





     void EndOfVideo(VideoPlayer vp)
    {
        // get new offers on same campaing
        GameMaster.Instance.StartCampaign();
        videoList.Remove(videoPlayer.clip);
    }

    public void PlayVideo()
    {
        int x = Random.Range(0, videoList.Count);
        videoPlayer.clip = videoList[x];       
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

    public void ShowWarning()
    {
        if (!warning)
        {
            warning = true;
            LeanTween.scale(warningSign.gameObject, new Vector3(1.0f, 1.0f, 1.0f), 0.5f).setOnComplete(WarningFollowUp);
        }
        Warning_Panel.Instance.ShowMessege("Νεες προτάσεις");
    }


    private void WarningFollowUp()
    {
        LeanTween.scale(warningSign.gameObject, new Vector3(1.2f, 1.2f, 1.2f), 0.5f).setLoopPingPong();
    }

    public void HideWarning()
    {
        if (warning)
        {
            warning = false;
            LeanTween.cancel(warningSign.gameObject);
            LeanTween.scale(warningSign.gameObject, Vector3.zero, 0.5f);
        }
    }

}
