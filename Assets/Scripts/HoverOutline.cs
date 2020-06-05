using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class HoverOutline : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler
{
    public RectTransform outlineRect;
    public float scalingMultiplier;
    private Vector3 startingScale;


    private void Start()
    {
        startingScale = outlineRect.transform.localScale;
    }
   

    public void OnPointerEnter(PointerEventData eventData)
    {
        LeanTween.scale(outlineRect, startingScale * scalingMultiplier, 0.3f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        LeanTween.scale(outlineRect, startingScale, 0.5f);
    }
}
