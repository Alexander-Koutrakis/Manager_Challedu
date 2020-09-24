using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChangeCampaingPanel : MonoBehaviour
{
    [SerializeField]
    private Image fadeImage = null;
    [SerializeField]
    private GameObject questionPanel;
    [SerializeField]
    private Panel_Control campaing_Panel_Control;
    [SerializeField]
    private Button[] buttons;
    delegate void questionAnswer();
    questionAnswer answer;


   
    public void StartQuestion()
    {
        GetComponent<Image>().enabled = true;
        foreach (Button button in buttons)
        {
            button.gameObject.SetActive(true);
        }
        LeanTween.moveLocalX(fadeImage.gameObject, 100, 0.5f).setOnComplete(ShowQuestion);
        Audio_Manager.Instance.Play_Sound("Fade");
    }
    
    private void ShowQuestion()
    {        
        LeanTween.moveLocalX(fadeImage.gameObject, -2500, 0.5f);
        gameObject.SetActive(true);
    }

    public void CloseQuestion()
    {
        LeanTween.moveLocalX(fadeImage.gameObject, 100, 0.5f).setOnComplete(CloseCompletly);
    }

    private void CloseCompletly()
    {
       
        LeanTween.moveLocalX(fadeImage.gameObject, -2500, 0.5f).setOnComplete(CloseGameobject);
        GetComponent<Image>().enabled = false;
        foreach (Button button in buttons)
        {
            button.gameObject.SetActive(false);
        }
    }

    private void CloseGameobject()
    {
        Debug.Log("here");
        if (answer != null)
        {
            answer();
        }
        gameObject.SetActive(false);

    }

    public void OpenCampaing()
    {
        answer += campaing_Panel_Control.OpenPanel;
    }

    private void OnDisable()
    {
        if (answer != null)
        {
            answer-= campaing_Panel_Control.OpenPanel;
        }
    }



}
