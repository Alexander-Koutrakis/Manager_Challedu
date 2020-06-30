using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogBookControl : MonoBehaviour
{
    public static LogBookControl Instance;
    public Transform OfferList_log;
    public Transform OfferResults_Log; 
    public GameObject activatedOfferGO;
    public GameObject OfferResultsGO;
    public Panel_Control panel_Control;
    private ScrollRect scrollRect;
    public RectTransform scrollRectContent;
    // public Dictionary<int, ActivatedOffer> LogOffers = new Dictionary<int, ActivatedOffer>(); //<----changed to list , since we repeat the same offers
    public List<ActivatedOffer> LogOffers = new List<ActivatedOffer>();
    private void Start()
    {
        Instance = this;
        scrollRectContent = GetComponentInChildren<ScrollRect>().content;
    }
    public void AddOffer(int offerID,int paidBudget, bool canBeClaimed, bool Claimed, int booster)
    {
        //create 2 gameobjects 
        // one is for the list area and one for the info area
        // both objects are connected through the ActivatedOffer script

        ActivatedOffer activatedOffer;
        Debug.Log("here");
        GameObject activatedOfferGO_Clone = Instantiate(activatedOfferGO, OfferList_log);
        GameObject OfferResults_Clone = Instantiate(OfferResultsGO, OfferResults_Log);
        activatedOfferGO_Clone.transform.SetAsFirstSibling();
        activatedOffer = activatedOfferGO_Clone.GetComponent<ActivatedOffer>();        
        activatedOffer.InitializeActivatedOffer(offerID, paidBudget, OfferResults_Clone, canBeClaimed,Claimed,booster);
        Debug.Log(scrollRectContent.position.y);
       //scrollRectContent.position = new Vector2(scrollRectContent.anchoredPosition.x, 0);

        //scrollRect.content.gameObject.transform.position = new Vector3(scrollRect.content.gameObject.transform.position.x, 0, scrollRect.content.gameObject.transform.position.z);
    }

    public void CorrentScrollPos()
    {
        scrollRectContent.position = new Vector2(scrollRectContent.anchoredPosition.x, 0);
    }

}
