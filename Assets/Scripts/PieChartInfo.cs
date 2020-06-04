using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PieChartInfo : MonoBehaviour , IPointerEnterHandler , IPointerExitHandler
{
    public bool isOver = false;
    private void OnMouseOver()
    {
        LeanTween.scale(gameObject, new Vector3(2, 2, 1), 0.5f);
        Debug.Log("here");
    }

    private void OnMouseExit()
    {
        LeanTween.scale(gameObject, new Vector3(1, 1, 1), 0.5f);
    }


   


    public void OnPointerEnter(PointerEventData eventData)
    {
        isOver = true;
        LeanTween.scale(gameObject, new Vector3(2, 2, 1), 0.5f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isOver = false;
        LeanTween.scale(gameObject, new Vector3(1, 1, 1), 0.5f);
    }
}
