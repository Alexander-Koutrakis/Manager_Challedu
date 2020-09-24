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
    public float speed = 0.5f;

    public void OpenPanel()
    {

        LeanTween.move(targetPanel, OpenPosition, speed);
        LeanTween.scale(targetPanel, OpenScale, speed).setOnComplete(Cover_Back_Image.Instance.ShowImage);

        Audio_Manager.Instance.Play_Sound("Open_Panel");
    }

    public void ClosePanel()
    {
        LeanTween.move(targetPanel, ClosePosition, speed);
        LeanTween.scale(targetPanel, CloseScale, speed);
        Cover_Back_Image.Instance.HideImage();
    }

    private void DisableGO()
    {
        targetPanel.gameObject.SetActive(false);
    }
}
