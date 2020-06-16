using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using UnityEngine;

public class Offer_Tab_Controller : MonoBehaviour
{
    public List<Offer> PreferedOffers = new List<Offer>();
    private List<Offer_Manager> offer_Managers = new List<Offer_Manager>();
    private List<Offer_Tab_Group> offer_Tab_Groups = new List<Offer_Tab_Group>();
    public static Offer_Tab_Controller Instance;
    public RectTransform groupTab;
    int tweenID;
    
    private void Awake()
    {
        Instance = this;
        foreach(Offer_Manager offer_Manager in GetComponentsInChildren<Offer_Manager>())
        {
            offer_Managers.Add(offer_Manager);
        }

        foreach(Offer_Tab_Group offer_Tab_Group in GetComponentsInChildren<Offer_Tab_Group>())
        {
            offer_Tab_Groups.Add(offer_Tab_Group);
        }
    }

    private void Start()
    {
        FillOfferManagers();
        LookForEmptyTabs();
        
               
        foreach (Offer_Manager offer_Manager in offer_Managers)
        {
            if (offer_Manager.offer != null)
            {
                offer_Manager.SetOfferValues();
            }
        }

        foreach (Offer_Tab_Group offer_Tab_Group in offer_Tab_Groups)
        {
            offer_Tab_Group.CheckChildrent();
        }
    }

    public void LookForEmptyTabs()
    {
        foreach(Offer_Manager offer_Manager in offer_Managers)
        {
            if (offer_Manager.offer == null)
            {
                offer_Manager.gameObject.SetActive(false);
            }
           
        }
    }

    public void FillOfferManagers()
    {
        for(int i = 0; i < PreferedOffers.Count; i++)
        {
            offer_Managers[i].offer = PreferedOffers[i];
        }
    }

    public void MoveGroupTabs(bool left) {

        Vector3 pos = groupTab.position;
        if (tweenID != 0)
        {
            LeanTween.pause(tweenID);
        }
        if (left)
        {
            if (pos.x < 0)
            {
                pos.x = groupTab.localPosition.x + 1920;
                if (pos.x >= 0)
                {
                    pos.x = 0;
                }
            }  
        }
        else
        {
            if (pos.x > -3839)
            {
                pos.x = groupTab.localPosition.x - 1920;
                if (pos.x < -3839)
                {
                    pos.x = -3840;
                }
            }
        }

         tweenID = LeanTween.moveLocalX(groupTab.gameObject, pos.x, 0.5f).id;
        LeanTween.resume(tweenID);

        }
    }

   
