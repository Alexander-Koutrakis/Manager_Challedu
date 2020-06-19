using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public static GameMaster Instance;
    private Dictionary<int, Offer> Offers = new Dictionary<int, Offer>();// toal amount of Offers
    private List<Offer> Group_A_Offers = new List<Offer>();// Offers belong to Strategy A; 
    private List<Offer> Group_B_Offers = new List<Offer>();// Offers belong to Strategy B; 
    private List<Offer> Group_C_Offers = new List<Offer>();// Offers belong to Strategy C; 
    private List<Offer> Group_D_Offers = new List<Offer>();// Offers belong to Strategy D; 
    private List<Offer> Group_E_Offers = new List<Offer>();// Offers belong to Strategy E; 
    private List<Offer> Group_F_Offers = new List<Offer>();// Offers belong to Strategy F; 
    private List<List<Offer>> OffersGrouped = new List<List<Offer>>();
    public Dictionary<int, Offer> DeletedOffers= new Dictionary<int, Offer>();// Offers already used by offer Tab Controller
    public int[] CampaignStars = new int[6];//<---------add the stars/ players choice
    public int[] Campaign = new int[6];//<----------num of offers per campain
    public int MaxOffers;
    private int total = 0;

    private void Awake()
    {
        Instance = this;

       InitializeDictionaries();
     //  SelectCampaign(CampaignStars);

    }

   


    public void StartCampaign()
    {
        total = 0;
      // get the total amount of campain stars in order to find Group Percent
        foreach (int campaingStar in CampaignStars)
        {
            total += campaingStar;
        }

        // get the int number of Offers according to starr %
        for (int i = 0; i < CampaignStars.Length; i++)
        {
            float x = (float)CampaignStars[i] / total;
            Campaign[i] =Mathf.RoundToInt(x *(float) MaxOffers);
        }
        Debug.Log("here");
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
                total--;
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

        // Add number of offers according to Campain index
        for (int i = 0; i < Campaign.Length; i++)
        {           
                for (int j = 0; j < Campaign[i]; j++)
                {
                    int x = Random.Range(0, OffersGrouped[i].Count);

                    Offer_Tab_Controller.Instance.PreferedOffers.Add(OffersGrouped[i][x]);
                    OffersGrouped[i].RemoveAt(x);
                }
        }


        // Fill the extra Offers with random "Non strategic" Offers
        int extraOffers = 0;
        while (extraOffers < 8)
        {
            int r1 = Random.Range(0, CampaignStars.Length);
            if (CampaignStars[r1] == 0)
            {
                int r2 = Random.Range(0, OffersGrouped[r1].Count);
                Offer_Tab_Controller.Instance.PreferedOffers.Add(OffersGrouped[r1][r2]);
                OffersGrouped[r1].RemoveAt(r2);
                extraOffers++;
            }
        }



        Offer_Tab_Controller.Instance.FillOfferManagers();

    }




    public void InitializeDictionaries()
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
            else if (Offers[index].OfferID < 5000)
            {
                Group_D_Offers.Add(Offers[index]);
            }
            else if (Offers[index].OfferID < 6000)
            {
                Group_E_Offers.Add(Offers[index]);
            }
            else
            {
                Group_F_Offers.Add( Offers[index]);
            }
        }


        OffersGrouped.Add(Group_A_Offers);
        OffersGrouped.Add(Group_B_Offers);
        OffersGrouped.Add(Group_C_Offers);
        OffersGrouped.Add(Group_D_Offers);
        OffersGrouped.Add(Group_E_Offers);
        OffersGrouped.Add(Group_F_Offers);
    }
}
