using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ObjectDrag : MonoBehaviour , IDragHandler , IEndDragHandler  ,IBeginDragHandler
{
    public Transform oldparent;
    private RectTransform rectTransform;   
    private Canvas canvas;
    private CanvasGroup canvasGroup;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
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
            transform.SetParent(oldparent);
            rectTransform.anchoredPosition = new Vector3(0, 0, 0);

        }
        else
        {
            GetComponentInParent<DropSpot>().emptyslot = false;
        }

      
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        oldparent = transform.parent;
        GetComponentInParent<DropSpot>().emptyslot = true;
        canvasGroup.blocksRaycasts=false;
        transform.SetParent(canvas.transform);
        transform.SetAsLastSibling();

    }


    private bool IsMouseOverLayoutGroup()
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = Input.mousePosition;

        List<RaycastResult> raycastResultsList = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, raycastResultsList);
        for (int i=0; i < raycastResultsList.Count; i++){
            if (raycastResultsList[i].gameObject.GetComponent<DropSpot>() != null)
            {
                if (raycastResultsList[i].gameObject.GetComponent<DropSpot>().emptyslot)
                {
                    return true;
                }
            }
        }

        return false;
    }
}
