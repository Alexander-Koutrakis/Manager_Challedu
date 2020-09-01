using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MeetingRoomController : MonoBehaviour , IMiniGame
{
    [SerializeField]
    private GameObject emptyMeetingRoom;
    [SerializeField]
    private List<Drag_n_Drop_Question> All_Questions=new List<Drag_n_Drop_Question>();
    public List<Drag_n_Drop_Question> Active_DnD_Questions=new List<Drag_n_Drop_Question>();
    public static MeetingRoomController Instance;

    public bool warning = false;
    [SerializeField]
    private RectTransform warningSign = null;

    private void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
    }

    
    public void StartMiniGame()
    {
        if (Active_DnD_Questions.Count > 0)
        {
            int x = Random.Range(0, Active_DnD_Questions.Count);
            DnD_Controller.Instance.ResetController(Active_DnD_Questions[x]);
            emptyMeetingRoom.SetActive(false);
           // Active_DnD_Questions.RemoveAt(x);
        }
        else
        {
            NoMeeting();
        }
    }

   

    public void CloseMiniGame()
    {
        foreach (Panel_Control panel_control in GetComponentsInChildren<Panel_Control>())
        {
            panel_control.ClosePanel();
        }
    }


    private void NoMeeting()
    {
        emptyMeetingRoom.SetActive(true);
    }

    public void AddDnDQuestion()
    {
        int x = Random.Range(0, All_Questions.Count);
        Active_DnD_Questions.Add(All_Questions[x]);
        All_Questions.RemoveAt(x);
        Warning_Panel.Instance.ShowMessege("Νεα Παρουσίαση");
        ShowWarning();
    }

    public void ShowWarning()
    {
        if (!warning)
        {
            warning = true;
            LeanTween.scale(warningSign.gameObject, new Vector3(1.0f, 1.0f, 1.0f), 0.5f).setOnComplete(WarningFollowUp);
        }
        Warning_Panel.Instance.ShowMessege("Νεες προσφορές");
    }


    private void WarningFollowUp()
    {
        LeanTween.scale(warningSign.gameObject, new Vector3(1.5f, 1.5f, 1.5f), 0.5f).setLoopPingPong();
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
