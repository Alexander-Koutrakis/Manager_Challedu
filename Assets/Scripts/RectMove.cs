using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RectMove : MonoBehaviour
{
    public Vector3 ClosePosition;
    public Vector3 OpenPosition;
    RectTransform rectTransform;
    public float time;
    private bool openItem = false;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void MoveObject_Button() {

        if (openItem)
        {
            LeanTween.move(rectTransform, ClosePosition, time);
            openItem = false;
        }
        else if (!openItem) {
            LeanTween.move(rectTransform, OpenPosition, time);
            openItem = true;
        }
    }


}
