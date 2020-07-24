using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropGroup : MonoBehaviour
{
    public Transform layoutgroupTransform;
    [SerializeField]
    private Transform whenThisOneISFull_Parent;
    public int currentAnswers;
    private DropSpot[] dropSpots = new DropSpot[3];





    public void CheckNumOfAnswers()
    {
        currentAnswers = GetComponentsInChildren<DnD_Answer>().Length;
    }

    public void restartAnswerPositions()
    {
        int i = 0;
        dropSpots = GetComponentsInChildren<DropSpot>();
        foreach(ObjectDrag answer in DnD_Controller.Instance.GetComponentsInChildren<ObjectDrag>())
        {
            answer.transform.SetParent(dropSpots[i].transform);
            answer.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);
            answer.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
            i++;
        }

        foreach(DropSpot ds in GetComponentsInChildren<DropSpot>())
        {
            ds.emptyslot = false;
        }
    }

    public void EmptyAnswerSlots()
    {
        foreach (DropSpot ds in GetComponentsInChildren<DropSpot>())
        {
            ds.emptyslot = true;
        }
    }

    
}
