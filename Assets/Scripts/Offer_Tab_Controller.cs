using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Offer_Tab_Controller : MonoBehaviour
{
    public List<Offer> offer_list = new List<Offer>();
    public List<Offer_Manager> offer_manager_list = new List<Offer_Manager>();
    public List<Offer> used_offer_list = new List<Offer>();
    private int counter=0;
    public static Offer_Tab_Controller Instance;

    private void Awake()
    {
        Instance = this;
        Offer[] offers_pool = Resources.LoadAll<Offer>("Offers");
        foreach(Offer offer in offers_pool)
        {
            offer_list.Add(offer);
        }

        Offer_Manager[] offer_manager_pool = GetComponentsInChildren<Offer_Manager>();
        foreach(Offer_Manager OM in offer_manager_pool)
        {
            offer_manager_list.Add(OM);
        }
        GameMaster.NextRound += Start_Select_Offers;
    }


    private void Start()
    {
        GameMaster.gameMaster.LoadGame();
    }


    private void Select_Offers()
    {// select X number of offers from the total list and add them to the used list

        if (counter < offer_manager_list.Count)
        {
            int x = Random.Range(0, offer_list.Count);
            if (used_offer_list.Contains(offer_list[x]))
            {
                Select_Offers();
            }
            else
            {
                used_offer_list.Add(offer_list[x]);
                counter++;
                Select_Offers();
            }
        }
        else
        {// use the offers from the used list we just created and add them to each offerTab
           for(int i=0;i< offer_manager_list.Count; i++)
            {               
                offer_manager_list[i].GetOfferData(used_offer_list[i]);                             
            }   
        }

        foreach (Offer offer in used_offer_list)
        {
            offer_list.Remove(offer);
        }

        used_offer_list.Clear();
        //GameMaster.NextRound -= Start_Select_Offers;
    }

    private void OnDisable()
    {
        GameMaster.NextRound -= Start_Select_Offers;
    }

    private void Start_Select_Offers() {    
        counter = 0;
        Select_Offers();
    }

    public void LoadData(int[] activeOffers_ID,int[,] offerIDs)
    { 
        OfferManagerOffers(offerIDs);
        RemoveUsedOffers(activeOffers_ID);
    }
   
    private void RemoveUsedOffers(int[] activeOffers_IDs)
    {
        offer_list.Clear();
        for(int i = 0; i < activeOffers_IDs.Length; i++)
        {
            foreach(Offer offer in Resources.LoadAll<Offer>("Offers"))
            {
                if (offer.OfferID == activeOffers_IDs[i])
                {
                    offer_list.Add(offer);
                }
            }
        }          
    }

    private void OfferManagerOffers(int[,] offerIDs) {

        for(int i = 0; i < offerIDs.GetLength(0); i++)
        {
            foreach (Offer offer in Resources.LoadAll<Offer>("Offers"))
            {
                if (offer.OfferID == offerIDs[i,0])
                {
                    offer_manager_list[i].GetOfferData(offer);
                    offer_manager_list[i].budgetSlider.value = offerIDs[i,1];
                    offer_manager_list[i].peopleSlider.value = offerIDs[i,2];
                    offer_manager_list[i].productSlider.value = offerIDs[i,3];
                    offer_manager_list[i].CheckForApproved();
                }
            }
        }    
    }

    public void SaveOfferData() {
        GameMaster.gameMaster.activeOffersIDs = new int[offer_list.Count];
        GameMaster.gameMaster.offerManagerIDs = new int[offer_manager_list.Count,4];
        for (int i = 0; i < offer_list.Count; i++)
        {
            GameMaster.gameMaster.activeOffersIDs[i] = offer_list[i].OfferID;
        }

        for (int i = 0; i < offer_manager_list.Count; i++)
        {            
            GameMaster.gameMaster.offerManagerIDs[i,0] = offer_manager_list[i].offer.OfferID;
            if (offer_manager_list[i].closedoffer)
            {
                GameMaster.gameMaster.offerManagerIDs[i, 1] = Mathf.RoundToInt(offer_manager_list[i].budgetSlider.value);
                GameMaster.gameMaster.offerManagerIDs[i, 2] = Mathf.RoundToInt(offer_manager_list[i].peopleSlider.value);
                GameMaster.gameMaster.offerManagerIDs[i, 3] = Mathf.RoundToInt(offer_manager_list[i].productSlider.value);
            }
            else
            {
                GameMaster.gameMaster.offerManagerIDs[i, 1] = 0;
                GameMaster.gameMaster.offerManagerIDs[i, 2] = 0;
                GameMaster.gameMaster.offerManagerIDs[i, 3] = 0;
            }
        }
    }


}
