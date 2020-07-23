using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ObjectDrag : MonoBehaviour , IDragHandler , IEndDragHandler  ,IBeginDragHandler
{
    private Transform parent;
    private RectTransform rectTransform;   
    private Canvas canvas;
    private CanvasGroup canvasGroup;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        parent = transform.parent;
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();
    }


  
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta/canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        canvasGroup.blocksRaycasts = true;
        if (!IsMouseOverLayoutGroup())
        {
            Debug.Log("not over ui");
            transform.SetParent(parent);
          
            
        }
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        DropGroup dropgroup = GetComponentInParent<DropGroup>();
        canvasGroup.blocksRaycasts=false;

        transform.SetParent(canvas.transform);
        transform.SetAsLastSibling();
        dropgroup.CheckNumOfAnswers();
    }


    private bool IsMouseOverLayoutGroup()
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = Input.mousePosition;

        List<RaycastResult> raycastResultsList = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, raycastResultsList);
        for (int i=0; i < raycastResultsList.Count; i++){
            if (raycastResultsList[i].gameObject.GetComponent<DropGroup>() != null)
            {
                    return true;              
            }
        }

        return false;
    }
}
