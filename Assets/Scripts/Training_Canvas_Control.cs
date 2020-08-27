using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Training_Canvas_Control : MonoBehaviour
{   
    [SerializeField]
    private List<TrainningButton> trainningButtons = new List<TrainningButton>();
    public bool warning = false;
    [SerializeField]
    private RectTransform warningSign = null;
    public static Training_Canvas_Control Instance;

   
    private void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
    }
    
    
    private void OnEnable()
    {
       

        foreach (TrainningButton button in trainningButtons)
        {
            if(button.buttonInfo.current_Level< button.buttonInfo.max_Level)
            {
                
                button.GetComponent<Button>().interactable = true;
            }
            else
            {
                button.GetComponent<Button>().interactable = false;
            }
        }

     
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
        LeanTween.scale(warningSign.gameObject, new Vector3(2.0f, 2.0f, 2.0f), 0.5f).setLoopPingPong();
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
