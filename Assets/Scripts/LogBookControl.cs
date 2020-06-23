using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogBookControl : MonoBehaviour
{
    public static LogBookControl Instance;
    public Transform OfferList_log;
    public Transform OfferResults_Log; 
    public GameObject activatedOfferGO;
    public GameObject OfferResultsGO;
    public Dictionary<int, ActivatedOffer> LogOffers = new Dictionary<int, ActivatedOffer>();

    private void Start()
    {
        Instance = this;
    }
    public void AddOffer(int offerID,int paidBudget,int paidPeople,int paidProducts, bool canBeClaimed, bool Claimed)
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
        activatedOffer.InitializeActivatedOffer(offerID, paidBudget, paidPeople, paidProducts, OfferResults_Clone, canBeClaimed,Claimed);
    }

}
