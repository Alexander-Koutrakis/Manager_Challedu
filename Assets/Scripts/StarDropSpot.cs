using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StarDropSpot : MonoBehaviour, IDropHandler
{

    [SerializeField]
    private GameObject[] starImages;
    public int StarNum=0;
   
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {           
            eventData.pointerDrag.transform.SetParent(transform);
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);            
        }     
    }

    public void AddStar()
    {
        StarNum++;

        for (int i = 0; i < 3; i++)
        {
            if (i < StarNum)
            {
                starImages[i].SetActive(true);
            }
            else
            {
                starImages[i].SetActive(false);
            }
        }

        NewCampaing_Panel.Instance.GetStars();
    }

    public void RemoveStar()
    {
        StarNum--;

        for (int i = 0; i < 3; i++)
        {
            if (i < StarNum)
            {
                starImages[i].SetActive(true);
            }
            else
            {
                starImages[i].SetActive(false);
            }
        }
    }


    public void ResetDropSpot()
    {
        StarNum = 0;

        for (int i = 0; i < 3; i++)
        {
          
           starImages[i].SetActive(false);
            
        }
    }


}
