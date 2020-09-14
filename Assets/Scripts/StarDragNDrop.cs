using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class StarDragNDrop : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
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
     //   canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        image.color = new Color32(255, 255, 255, 255);
    }

    public void OnEndDrag(PointerEventData eventData)
    {

      //  canvasGroup.blocksRaycasts = true;
        if (!IsMouseOverLayoutGroup())
        {
            transform.SetParent(UnusedBacket_transform);
            rectTransform.anchoredPosition = new Vector3(0, 0, 0);
        }
        else
        {
           // GetComponentInParent<DropSpot>().emptyslot = false;
        }


    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        image.color = new Color32(255, 255, 255, 255);
        oldparent = transform.parent;
     //   canvasGroup.blocksRaycasts = false;
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
                return true;
            }
            else
            {
                rectTransform.SetParent(UnusedBacket_transform);
            }
        }

        return false;
    }
}
