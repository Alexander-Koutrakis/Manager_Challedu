using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Panel_Control : MonoBehaviour
{
    public RectTransform Panel;
    public Vector3 openPostion;
    public Vector3 closePosition;
    public Vector3 openScale;
    public Vector3 closeScale;

    private void Start()
    {
        closePosition = Panel.anchoredPosition;
        GameMaster.NextRound += ClosePanel;
    }


    public void OpenPanel()
    {
        
        Panel.gameObject.SetActive(true);
        LeanTween.move(Panel, openPostion, 0.5f);
        LeanTween.scale(Panel, openScale, 0.5f);
        
    }

    public void ClosePanel()
    {
        LeanTween.move(Panel, closePosition, 0.5f);
        LeanTween.scale(Panel, closeScale, 0.5f).setOnComplete(DisablePanel);
    }
    
    private void DisablePanel()
    {
       
        //  Panel.gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        GameMaster.NextRound -= ClosePanel;
    }
}
