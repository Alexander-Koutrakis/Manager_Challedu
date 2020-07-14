using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using UnityEngine;

public class Offer_Tab_Controller : MonoBehaviour
{
    public List<Offer> PreferedOffers = new List<Offer>();
    private List<Offer_Manager> offer_Managers = new List<Offer_Manager>();
    public List<Offer_Manager> used_Managers = new List<Offer_Manager>();
    public static Offer_Tab_Controller Instance;
    public RectTransform groupTab;
    public Panel_Control panel_Control;
    int currentTabIndex=19;
    public Vector3 LeftPos;
    public Vector3 CentralPos;
    public Vector3 RightPos;
    public Offer_Manager shown_Offer_Manager;


    private void Awake()
    {
        Instance = this;
        foreach(Offer_Manager offer_Manager in GetComponentsInChildren<Offer_Manager>())
        {
            offer_Managers.Add(offer_Manager);
        }

    }

   

   

    public void FillOfferManagers()
    {
        PreferedOffers.Shuffle();
        for(int i = 0; i < PreferedOffers.Count; i++)
        {
            offer_Managers[i].offer = PreferedOffers[i];
            used_Managers.Add(offer_Managers[i]);
        }


        foreach (Offer_Manager offer_Manager in offer_Managers)
        {           
                offer_Manager.SetOfferValues();            
        }
    }

    public void NextOfferTab() {
      
        LeanTween.moveLocalX(used_Managers[currentTabIndex].gameObject, LeftPos.x, 0.5f);
       
        currentTabIndex++;
        if (currentTabIndex >= used_Managers.Count)
        {
            currentTabIndex = 0;
        }
        shown_Offer_Manager = used_Managers[currentTabIndex];
        used_Managers[currentTabIndex].gameObject.transform.localPosition = RightPos;
        used_Managers[currentTabIndex].gameObject.SetActive(true);
        LeanTween.moveLocalX(used_Managers[currentTabIndex].gameObject, CentralPos.x, 0.5f).setOnComplete(DisableAllOffers);
        shown_Offer_Manager.OpenOfferTab();
    }


    public void PrevOfferTab()
    {

        LeanTween.moveLocalX(used_Managers[currentTabIndex].gameObject, RightPos.x, 0.5f);

        currentTabIndex--;
        if (currentTabIndex < 0)
        {
            currentTabIndex = used_Managers.Count-1;
        }
        shown_Offer_Manager = used_Managers[currentTabIndex];
        used_Managers[currentTabIndex].gameObject.transform.localPosition = LeftPos;
        used_Managers[currentTabIndex].gameObject.SetActive(true);
        LeanTween.moveLocalX(used_Managers[currentTabIndex].gameObject, CentralPos.x, 0.5f).setOnComplete(DisableAllOffers);
        shown_Offer_Manager.OpenOfferTab();
        
    }


   private void DisableAllOffers()
    {
        Debug.Log("here");
        foreach(Offer_Manager offer_Manager in used_Managers)
        {           
             offer_Manager.gameObject.SetActive(false);           
        }
        shown_Offer_Manager.gameObject.SetActive(true);
    }



  
}

   
