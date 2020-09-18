using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StarDragNDrop : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler, IPointerDownHandler
{
    private Transform oldparent;
    private RectTransform rectTransform;
    private Canvas canvas;
    [SerializeField]
    private Transform UnusedBacket_transform;
    // private CanvasGroup canvasGroup;
    private Image image;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
        image = GetComponent<Image>();
 
    }

    public void OnDrag(PointerEventData eventData)
    {
       
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        image.color = new Color32(56, 181, 73, 255);
    }

    public void OnEndDrag(PointerEventData eventData)
    {

      //  canvasGroup.blocksRaycasts = true;
        if (!IsMouseOverLayoutGroup())
        {
            transform.SetParent(UnusedBacket_transform);
            rectTransform.anchoredPosition = new Vector3(0, 0, 0);
        }
        


    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Vector3 pos = new Vector3(Camera.main.ScreenToWorldPoint(eventData.position).x, Camera.main.ScreenToWorldPoint(eventData.position).y, 0);
        rectTransform.position = Input.mousePosition;
    }

  
    public void OnBeginDrag(PointerEventData eventData)
    {
        
      //  RectTransformUtility.ScreenPointToLocalPointInRectangle()<-------------------check this
        image.color = new Color32(56, 181, 73, 255);
        if (GetComponentInParent<StarDropSpot>() != null)
        {
            GetComponentInParent<StarDropSpot>().RemoveStar();
        }
        oldparent = transform.parent;
        transform.SetParent(canvas.transform);
        transform.SetAsLastSibling();

    }


    private bool IsMouseOverLayoutGroup()
    {
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.position = Input.mousePosition;

        List<RaycastResult> raycastResultsList = new List<RaycastResult>();
        EventSystem.current.RaycastAll(pointerEventData, raycastResultsList);
        for (int i = 0; i < raycastResultsList.Count; i++)
        {
            if (raycastResultsList[i].gameObject.GetComponent<StarDropSpot>() != null)
            {
                rectTransform.SetParent(raycastResultsList[i].gameObject.transform);
                image.color = new Color32(0, 0, 0, 0);
                raycastResultsList[i].gameObject.GetComponent<StarDropSpot>().AddStar();
                return true;
            }
            else
            {
                rectTransform.SetParent(UnusedBacket_transform);
            }
        }

        return false;
    }


    public void ResetStar(){
        transform.SetParent(UnusedBacket_transform);
        rectTransform.anchoredPosition = new Vector3(0, 0, 0);
        image.color = new Color32(56, 181, 73, 255);
        rectTransform.localScale = new Vector3(1, 1, 1);
    }
}
