using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogBookControl : MonoBehaviour
{
   public Transform OfferList_log;
   public GameObject activatedOffer;
    int testcounter;
    public void AddOffer()
    {
        Debug.Log("here");
        GameObject activatedOffer_Clone = Instantiate(activatedOffer, OfferList_log);
        activatedOffer_Clone.transform.SetAsFirstSibling();
    }
}
