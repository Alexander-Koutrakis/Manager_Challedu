using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
public class DropSpot : MonoBehaviour, IDropHandler
{
    public bool emptyslot = true;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null&&emptyslot)
        {
                eventData.pointerDrag.transform.SetParent(transform);
                eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition=new Vector3(0,0,0);
                GetComponentInParent<DnD_Controller>().CheckIFreadyForPresentation();
        }
    }
}
