using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disable_Gameobject : MonoBehaviour
{
   public void DisableGO() {
        
        gameObject.SetActive(false);   
    }

    public void ShowNextOffer()
    {
        Offer_Tab_Controller.Instance.NextOfferTab();
    }

}
