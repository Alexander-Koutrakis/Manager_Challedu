using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Training_Canvas_Control : MonoBehaviour, IMiniGame
{   
    [SerializeField]
    private List<TrainningButton> trainningButtons = new List<TrainningButton>();
    public bool warning = false;
    [SerializeField]
    private RectTransform warningSign = null;
    public static Training_Canvas_Control Instance;
    [SerializeField]
    private Panel_Control SDG_buttons_Panel;
    [SerializeField]
    private Panel_Control info_Panel_Control;
    [SerializeField]
    private Image fadeImage = null;
    [SerializeField]
    private RectTransform fadeTransform = null;
    private void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
    }
    
 
    public void ShowWarning()
    {
        if (Player.Instance.Player_Level > 1)
        {
            if (!warning)
            {
                warning = true;
                LeanTween.scale(warningSign.gameObject, new Vector3(1.0f, 1.0f, 1.0f), 0.5f).setOnComplete(WarningFollowUp);
            }
            Warning_Panel.Instance.ShowMessege("Νέα εκπαίδευση");
        }
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

    public void StartMiniGame()
    {
        HideWarning();
        SDG_buttons_Panel.OpenPanel();

        foreach (TrainningButton button in trainningButtons)
        {
            if (button.buttonInfo.current_Level < button.buttonInfo.max_Level&& button.buttonInfo.current_Level<= button.buttonInfo.level_Limit)
            {

                button.GetComponent<Button>().interactable = true;
            }
            else
            {
                button.GetComponent<Button>().interactable = false;
            }
        }


    }

    public void CloseMiniGame()
    {
        info_Panel_Control.OpenPanel();
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
