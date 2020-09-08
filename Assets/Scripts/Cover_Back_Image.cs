using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cover_Back_Image : MonoBehaviour
{
    public static Cover_Back_Image Instance;

    private void Start()
    {
        Instance = this;
    }
    public void ShowImage() {
        LeanTween.alpha(GetComponent<RectTransform>(), 0.4f, 0.5f);
        GetComponent<Image>().raycastTarget = true;
    }

    public void HideImage()
    {
        LeanTween.alpha(GetComponent<RectTransform>(), 0f, 0.5f);
        GetComponent<Image>().raycastTarget = false;
    }
}
