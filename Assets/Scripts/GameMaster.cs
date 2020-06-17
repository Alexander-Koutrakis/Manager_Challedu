using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public static GameMaster Instance;
    public Dictionary<int, Offer> Offers = new Dictionary<int, Offer>();
    public List<Offer> Group_A_Offers = new List<Offer>();
    public List<Offer> Group_B_Offers = new List<Offer>();
    public List<Offer> Group_C_Offers = new List<Offer>();
    public List<Offer> Group_D_Offers = new List<Offer>();
    private List<List<Offer>> OffersGrouped = new List<List<Offer>>();
    public Dictionary<int, Offer> DeletedOffers= new Dictionary<int, Offer>();
    public int[] CampaignStars = new int[4];//<---------add the stars/ players choice
    public int[] Campaign = new int[4];//<----------num of offers per campain
    public int MaxOffers = 20;
    public int total = 0;

    private void Awake()
    {
        Instance = this;

        InitializeDictionaries();
        SelectCampaign(CampaignStars);

    }

   


    public void SelectCampaign(int[] campaingStats)
    {
        total = 0;
      // get the total amount of campain stars in order to find Group Percent
        foreach (int campaingStat in campaingStats)
        {
            total += campaingStat;
        }
       
        for (int i = 0; i < Campaign.Length; i++)
        {
            float x = (float)CampaignStars[i] / total;
            Campaign[i] =Mathf.RoundToInt(x *(float) MaxOffers);
        }

        total = 0;
        foreach (int campaingStat in Campaign)
        {
            total += campaingStat;
        }

        while (total > MaxOffers)
        {
            int x = Random.Range(0, Campaign.Length);
            if (Campaign[x] > 0)
            {
                Campaign[x] = Campaign[x] - 1;
                total--; ;
            }
        }

        while (total < MaxOffers)
        {
            int x = Random.Range(0, Campaign.Length);
            if (Campaign[x] > 0)
            {
                //  Campaign[x] = Campaign[x] + 1;
                total++; ;
            }
        }

        for (int i = 0; i < Campaign.Length; i++)
        {           
            int currentOffers=0;
          while(currentOffers< Campaign[i])
            {
                int x = Random.Range(0, OffersGrouped[i].Count);
                Offer_Tab_Controller.Instance.PreferedOffers.Add(OffersGrouped[i][x]);
                currentOffers++;
            }
        }       
    }




    private void InitializeDictionaries()
    {

        List<int> indexes = new List<int>();

        // Get All offers
        foreach (Offer offer in Resources.LoadAll<Offer>("Offers"))
        {
            Offers.Add(offer.OfferID, offer);
            indexes.Add(offer.OfferID);
        }

        // seperate the offers into groups
        foreach(int index in indexes)
        {
            if (Offers[index].OfferID < 2000)
            {
                Group_A_Offers.Add(Offers[index]);
            }else if(Offers[index].OfferID < 3000)
            {
                Group_B_Offers.Add(Offers[index]);
            }
            else if(Offers[index].OfferID < 4000)
            {
                Group_C_Offers.Add(Offers[index]);
            }
            else
            {
                Group_D_Offers.Add( Offers[index]);
            }
        }


        OffersGrouped.Add(Group_A_Offers);
        OffersGrouped.Add(Group_B_Offers);
        OffersGrouped.Add(Group_C_Offers);
        OffersGrouped.Add(Group_D_Offers);
    }
}
