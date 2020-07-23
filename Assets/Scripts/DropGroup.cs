using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropGroup : MonoBehaviour, IDropHandler
{
    public Transform layoutgroupTransform;
    [SerializeField]
    private Transform whenThisOneISFull_Parent;
    public int currentAnswers;
    public int maxAnswers;
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            if (currentAnswers < maxAnswers)
            {
                Debug.Log("on drop");
                eventData.pointerDrag.GetComponent<RectTransform>().SetParent(layoutgroupTransform);
                CheckNumOfAnswers();
            }
            else
            {
                eventData.pointerDrag.GetComponent<RectTransform>().SetParent(whenThisOneISFull_Parent);
            }
            
        }
        
    }



    public void CheckNumOfAnswers()
    {
        currentAnswers = GetComponentsInChildren<DnD_Answer>().Length;
    }

   
}
