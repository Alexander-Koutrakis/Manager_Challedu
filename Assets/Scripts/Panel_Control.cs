using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Panel_Control : MonoBehaviour
{
    public RectTransform targetPanel;
    public Vector3 OpenPosition;
    public Vector3 ClosePosition;
    public Vector3 OpenScale;
    public Vector3 CloseScale;


    public void OpenPanel()
    {

        LeanTween.move(targetPanel, OpenPosition, 0.5f);
        LeanTween.scale(targetPanel, OpenScale, 0.5f).setOnComplete(Cover_Back_Image.Instance.ShowImage);       
    }

    public void ClosePanel()
    {
        LeanTween.move(targetPanel, ClosePosition, 0.5f);
        LeanTween.scale(targetPanel, CloseScale, 0.5f);
        Cover_Back_Image.Instance.HideImage();
    }

    private void DisableGO()
    {
        targetPanel.gameObject.SetActive(false);
    }
}
