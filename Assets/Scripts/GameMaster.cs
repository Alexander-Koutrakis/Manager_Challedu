﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{
    public static GameMaster Instance;
    public Sprite achievementComplete_Sprite;
    public Dictionary<int, Offer> Offers = new Dictionary<int, Offer>();// toal amount of Offers
    [SerializeField]
    private List<Offer> Enviroment_Offers = new List<Offer>();// Offers belong to Strategy A; 
    [SerializeField]
    private List<Offer> Education_Offers = new List<Offer>();// Offers belong to Strategy B; 
    [SerializeField]
    private List<Offer> Quality_Of_Life_Offers = new List<Offer>();// Offers belong to Strategy C;
    [SerializeField]
    private List<Offer> Economy_Offers = new List<Offer>();// Offers belong to Strategy D;
    [SerializeField]
    private List<Offer> Health_Offers = new List<Offer>();// Offers belong to Strategy E; 
    [SerializeField]
    private List<Offer> Equality_Offers = new List<Offer>();// Offers belong to Strategy F; 
    private List<List<Offer>> OffersGrouped = new List<List<Offer>>();
    public Sprite[] SDG_Sprites = new Sprite[17];
    [SerializeField]
    private Image fadeImage;
    public float DelayedExp;
    public int[] CampaignStars = new int[6];//<---------add the stars/ players choice
    public int[] Campaign = new int[6];//<----------num of offers per campain
    public int MaxOffers=2;
    public int FalseOffers=1;
    [SerializeField]
    private int total = 0;
    [SerializeField]
    private Canvas[] canvases;

    public Sprite[] campaingReportSprites = new Sprite[2];
    public Sprite[] OfferResult_Text = new Sprite[4];
    public Sprite[] GP_Result_Sprites = new Sprite[6];
    public Sprite[] Total_Points_Sprites = new Sprite[2];
    private void Awake()
    {
        Instance = this;
        InitializeDictionaries();      
    }

  
    public void StartCampaign()
    {
       // MaxOffers = Player.Instance.Player_Level + 2*Player.Instance.Player_Level;      
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
            Campaign[i] =Mathf.RoundToInt(x * MaxOffers);
            if (x > 0&& Campaign[i]==0)
            {
                Campaign[i] = 1;
            }
        }

        total = 0;// total show how many "Correct" offers will be generted
        foreach (int campaingStat in Campaign)
        {
            total += campaingStat;
        }

        while (total < MaxOffers)
        {
            int x = Random.Range(0, 6);
            if (Campaign[x] > 0)
            {
                Campaign[x]++;
                total++;
            }
        }

        while (total > MaxOffers)
        {
            int x = Random.Range(0, 6);
            if (Campaign[x] > 0)
            {
                Campaign[x]--;
                total--;
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
        while (extraOffers < FalseOffers)
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
        Player.Instance.FillStrategyImages();
    }
    public void InitializeDictionaries()
    {



        //// Get All offers
        foreach (Offer offer in Resources.LoadAll<Offer>("Offers"))
        {
            Offers.Add(offer.OfferID, offer);
          
        }
 
        OffersGrouped.Add(Enviroment_Offers);
        OffersGrouped.Add(Education_Offers);
        OffersGrouped.Add(Quality_Of_Life_Offers);
        OffersGrouped.Add(Economy_Offers);
        OffersGrouped.Add(Health_Offers);
        OffersGrouped.Add(Equality_Offers);

        //for(int i = 0; i < OffersGrouped.Count; i++)
        //{
        //    for(int j = 0; j < OffersGrouped[i].Count; i++)
        //    {
        //        Offers.Add(OffersGrouped[i][j].OfferID, OffersGrouped[i][j]);
        //    }
        //}
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
        x = Player.Instance.offerARGCost * x;
        x = Mathf.Round(x / 100) * 100;
        offer.budgetCost = Mathf.RoundToInt(x);
        int y = Random.Range(1, 10)*5;
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
            if (Sdgs[i] > top1)
            {
                top3 = top2;
                offer.SDG3 = offer.SDG2;
                top2 = top1;
                offer.SDG2 = offer.SDG1;
                top1 = Sdgs[i];
                offer.SDG1 = SDG_Sprites[i];
            }
            else  if (Sdgs[i] > top2)
            {
                top3 = top2;
                offer.SDG3 = offer.SDG2;
                top2 = Sdgs[i];
                offer.SDG2 = SDG_Sprites[i];
            }
            else if (Sdgs[i] > top3)
            {

                top3 = Sdgs[i];
                offer.SDG3 = SDG_Sprites[i];
            }
            
        }

        if (offer.SDG1==null|| offer.SDG2==null|| offer.SDG3==null)
        {
            Debug.LogWarning("SDG error " + offer.title_Text);
            Debug.Log(top1 );
            Debug.Log(top2);
            Debug.Log(top3);
        }
    }
    public void LoadCanvas(Canvas targetCanvas)
    {

        foreach (Canvas canvas in canvases)
        {
            canvas.gameObject.SetActive(false);
        }
        targetCanvas.gameObject.SetActive(true);
        
        if (targetCanvas.GetComponent<IMiniGame>() != null)
        {
            targetCanvas.GetComponent<IMiniGame>().CloseMiniGame();
            targetCanvas.GetComponent<IMiniGame>().StartMiniGame();
        }
       
    }
   
    public void DelayedExpAdded()
    {
        Player.Instance.Expirience += DelayedExp;
        Debug.Log("Delayed Exp :" + DelayedExp);
        DelayedExp = 0;
        Player.Instance.Calculate_UI_Info();
        Level_Up_Panel.Instance.CheckForLevelUp();
    }

    

}
