using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
public class MeetingRoomController : MonoBehaviour , IMiniGame
{
    [SerializeField]
    private GameObject emptyMeetingRoom;
    [SerializeField]
    private List<Drag_n_Drop_Question> All_Questions=new List<Drag_n_Drop_Question>();
    [SerializeField]
    private List<Drag_n_Drop_Question> Usable_Questions = new List<Drag_n_Drop_Question>();
    public List<Drag_n_Drop_Question> Active_DnD_Questions=new List<Drag_n_Drop_Question>();
    public static MeetingRoomController Instance;

    public bool warning = false;
    [SerializeField]
    private RectTransform warningSign = null;
    [SerializeField]
    private Image fadeImage = null;
    [SerializeField]
    private RectTransform fadeTransform = null;
    private void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
    }

    
    public void StartMiniGame()
    {
        HideImage();
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
        if (Usable_Questions.Count <= 0)
        {
            foreach(Drag_n_Drop_Question DnD_question in All_Questions)
            {
                Usable_Questions.Add(DnD_question);
            }
        }

        int x = Random.Range(0, Usable_Questions.Count);
        Active_DnD_Questions.Add(Usable_Questions[x]);
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

    public void ShowImage()
    {
        Debug.Log("show");
        LeanTween.alpha(fadeTransform, 0.4f, 0.5f);
        fadeImage.raycastTarget = true;
    }

    public void HideImage()
    {
        Debug.Log("hide");
        LeanTween.alpha(fadeTransform, 0f, 0.5f);
        fadeImage.raycastTarget = false;
    }
}
