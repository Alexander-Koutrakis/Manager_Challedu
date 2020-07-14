using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public static GameMaster Instance;
    public Dictionary<int, Offer> Offers = new Dictionary<int, Offer>();// toal amount of Offers
    [SerializeField]
    private List<Offer> Group_A_Offers = new List<Offer>();// Offers belong to Strategy A; 
    [SerializeField]
    private List<Offer> Group_B_Offers = new List<Offer>();// Offers belong to Strategy B; 
    [SerializeField]
    private List<Offer> Group_C_Offers = new List<Offer>();// Offers belong to Strategy C;
    [SerializeField]
    private List<Offer> Group_D_Offers = new List<Offer>();// Offers belong to Strategy D;
    [SerializeField]
    private List<Offer> Group_E_Offers = new List<Offer>();// Offers belong to Strategy E; 
    [SerializeField]
    private List<Offer> Group_F_Offers = new List<Offer>();// Offers belong to Strategy F; 
    private List<List<Offer>> OffersGrouped = new List<List<Offer>>();
    [SerializeField]
    private Sprite[] SDG_Sprites = new Sprite[17];
   // public Dictionary<int, Offer> DeletedOffers= new Dictionary<int, Offer>();// Offers already used by offer Tab Controller
    public int[] CampaignStars = new int[6];//<---------add the stars/ players choice
    public int[] Campaign = new int[6];//<----------num of offers per campain
    public int MaxOffers;
    [SerializeField]
    private int total = 0;

    private void Awake()
    {
        Instance = this;
        InitializeDictionaries();
       
    }

  



    public void StartCampaign()
    {
        Offer_Tab_Controller.Instance.PreferedOffers.Clear();
       
        
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
                extraOffers++;
            }
        }

        // randomize Gp points and budget cost for each offer
        foreach (Offer offer in Offer_Tab_Controller.Instance.PreferedOffers)
        {
            RandomizeOffer(offer);
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

    private float[] RandomizedGPpoints()
    {
        
        int totalPoints = Random.Range(15, 15+Player.Instance.Player_Level);
        float[] GPpoints=new float[6];

        while (totalPoints > 0)
        {
            int x = Random.Range(0, GPpoints.Length);
            if (GPpoints[x] < 5)
            {
                GPpoints[x]++;
                totalPoints--;
            }
        }
        return GPpoints;
    }




    private void RandomizeOffer(Offer offer)
    {
        offer.GP = RandomizedGPpoints();
        float x = Random.Range(1, 1.21f);
        x = Player.Instance.Player_Level * x * 1000;
        x = Mathf.Round(x / 100) * 100;
        offer.budgetCost = Mathf.RoundToInt(x);
        int y = Random.Range(1, 20)*10;
        offer.DurationInSec = y;
        offer.expiriencePoints =Mathf.RoundToInt(x / 10);
        GetTopSDGs(offer);
    }

    private void GetTopSDGs(Offer offer)
    {
        float[] Sdgs = offer.SDGs;
        float top1 = 0;
        float top2 = 0;
        float top3 = 0;

        for (int i = 0; i < Sdgs.Length; i++)
        {
            if (Sdgs[i] >= top1)
            {
                top1 = Sdgs[i];
                offer.SDG1 = SDG_Sprites[i];
            }
            else if (Sdgs[i] >= top2)
            {
                top2 = Sdgs[i];
                offer.SDG2 = SDG_Sprites[i];
            }
            else if (Sdgs[i] >= top3)
            {
                top3 = Sdgs[i];
                offer.SDG3 = SDG_Sprites[i];
            }
            
        }

        if (offer.SDG1==null|| offer.SDG2==null|| offer.SDG3==null)
        {
            Debug.LogWarning("SDG error " + offer.title_Text);
        }
    }
}
