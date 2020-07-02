using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Mathematics;
using Random = UnityEngine.Random;

public class Offer_Manager : MonoBehaviour
{
    public Offer offer;
    public TMP_Text title_Text;
 // public TMP_Text main_Text;
    public TMP_Text budget_Text;
    private Button budget50;
    private Button budget100;
    private Button budget130;
    private Button PayButton;
    private Offer_GPGraph offer_GPGraph;
    private int BudgetAmount;
    [SerializeField]
    private Sprite availableButton;
    [SerializeField]
    private Sprite unavailableButton;
    [SerializeField]
    private Sprite selectedButton;
    public bool offerClosed = false;
    private int Booster=0;
    private void Awake()
    {
        InitializeValues();
        offer_GPGraph = GetComponentInChildren<Offer_GPGraph>();
    }

    private void InitializeValues()
    {
        TMP_Text[] tMP_Texts = GetComponentsInChildren<TMP_Text>();
        title_Text = tMP_Texts[1];
       // main_Text= tMP_Texts[2];
        budget_Text= tMP_Texts[2]; 
    }

    public void SetOfferValues() {
        title_Text.text = offer.title_Text;
       // main_Text.text = offer.main_Text;
        budget_Text.text = offer.budgetCost.ToString();
        GetBooster();
    }
    private void GetBooster()
    {
        if (offer.OfferID < 2000 && GameMaster.Instance.CampaignStars[0] > 0)
        {
            Booster = GameMaster.Instance.CampaignStars[0] * 10;
        }
        else if (offer.OfferID < 3000 && GameMaster.Instance.CampaignStars[1] > 0)
        {
            Booster = GameMaster.Instance.CampaignStars[1] * 10;
        }
        if (offer.OfferID < 4000 && GameMaster.Instance.CampaignStars[2] > 0)
        {
            Booster = GameMaster.Instance.CampaignStars[2] * 10;
        }
        else if (offer.OfferID < 5000 && GameMaster.Instance.CampaignStars[3] > 0)
        {
            Booster = GameMaster.Instance.CampaignStars[3] * 10;
        }
        else if (offer.OfferID < 6000 && GameMaster.Instance.CampaignStars[4] > 0)
        {
            Booster = GameMaster.Instance.CampaignStars[4] * 10;
        }
        else if (offer.OfferID < 7000 && GameMaster.Instance.CampaignStars[5] > 0)
        {
            Booster = GameMaster.Instance.CampaignStars[5] * 10;
        }
    }

    public void OpenOfferTab()
    {
        offer_GPGraph.ShowGraph(offer.GP);
        gameObject.transform.localScale = new Vector3(1, 1, 1);
       
        if (!offerClosed)
        {
            GetButtons();
        }
    }

    public void CloseTab()
    {
        offer_GPGraph.HideGraph();
        gameObject.transform.localScale = new Vector3(0, 0, 0);
    }

 
    public void GetButtons()
    {

        budget50 = GetComponentsInChildren<Button>()[0];
        if (offer.budgetCost * 0.5f > Player.Instance.budget)
        {
            budget50.interactable = false;
            budget50.GetComponent<Image>().sprite = unavailableButton;
            //swap sprite
        }
        else if(offer.budgetCost * 0.5f <= Player.Instance.budget)
        {
            budget50.interactable = true;
            budget50.GetComponent<Image>().sprite = availableButton;
            //swap sprite
        }


        budget100 = GetComponentsInChildren<Button>()[1];
        if (offer.budgetCost * 1f > Player.Instance.budget)
        {
            budget100.interactable = false;
            budget100.GetComponent<Image>().sprite = unavailableButton;
            //swap sprite
        }
        else if(offer.budgetCost * 1f <= Player.Instance.budget)
        {
            budget100.interactable = true;
            budget100.GetComponent<Image>().sprite = availableButton;
            //swap sprite
        }


        budget130 = GetComponentsInChildren<Button>()[2];
        if (offer.budgetCost * 1.3f > Player.Instance.budget)
        {
            budget130.interactable = false;
            budget130.GetComponent<Image>().sprite = unavailableButton;
            //swap sprite
        }
        else if(offer.budgetCost * 1.3f <= Player.Instance.budget)
        {
            budget130.interactable = true;
            budget130.GetComponent<Image>().sprite = availableButton;
            //swap sprite
        }


        PayButton = GetComponentsInChildren<Button>()[3];


    }


    public void PayBudget50()
    {
        
        BudgetAmount = Mathf.RoundToInt(offer.budgetCost * 0.5f);
        budget50.GetComponent<Image>().sprite = selectedButton;



        budget100 = GetComponentsInChildren<Button>()[1];
        if (offer.budgetCost * 1f > Player.Instance.budget)
        {
            budget100.interactable = false;
            budget100.GetComponent<Image>().sprite = unavailableButton;
            //swap sprite
        }
        else if (offer.budgetCost * 1f <= Player.Instance.budget)
        {
            budget100.interactable = true;
            budget100.GetComponent<Image>().sprite = availableButton;
            //swap sprite
        }
        budget130 = GetComponentsInChildren<Button>()[2];
        if (offer.budgetCost * 1.3f > Player.Instance.budget)
        {
            budget130.interactable = false;
            budget130.GetComponent<Image>().sprite = unavailableButton;
            //swap sprite
        }
        else if (offer.budgetCost * 1.3f <= Player.Instance.budget)
        {
            budget130.interactable = true;
            budget130.GetComponent<Image>().sprite = availableButton;
            //swap sprite
        }

        // swap other buttons
        PayButton.interactable = true;
    }

    public void PayBudget100()
    {
        BudgetAmount = Mathf.RoundToInt(offer.budgetCost * 1.0f);
        budget100.GetComponent<Image>().sprite = selectedButton;

        budget50 = GetComponentsInChildren<Button>()[0];
        if (offer.budgetCost * 0.5f > Player.Instance.budget)
        {
            budget50.interactable = false;
            budget50.GetComponent<Image>().sprite = unavailableButton;
            //swap sprite
        }
        else if (offer.budgetCost * 0.5f <= Player.Instance.budget)
        {
            budget50.interactable = true;
            budget50.GetComponent<Image>().sprite = availableButton;
            //swap sprite
        }
        budget130 = GetComponentsInChildren<Button>()[2];
        if (offer.budgetCost * 1.3f > Player.Instance.budget)
        {
            budget130.interactable = false;
            budget130.GetComponent<Image>().sprite = unavailableButton;
            //swap sprite
        }
        else if (offer.budgetCost * 1.3f <= Player.Instance.budget)
        {
            budget130.interactable = true;
            budget130.GetComponent<Image>().sprite = availableButton;
            //swap sprite
        }

        // swap other buttons
        PayButton.interactable = true;
    }

    public void PayBudget130()
    {
        BudgetAmount = Mathf.RoundToInt(offer.budgetCost * 1.3f);
        budget130.GetComponent<Image>().sprite = selectedButton;

        budget50 = GetComponentsInChildren<Button>()[0];
        if (offer.budgetCost * 0.5f > Player.Instance.budget)
        {
            budget50.interactable = false;
            budget50.GetComponent<Image>().sprite = unavailableButton;
            //swap sprite
        }
        else if (offer.budgetCost * 0.5f <= Player.Instance.budget)
        {
            budget50.interactable = true;
            budget50.GetComponent<Image>().sprite = availableButton;
            //swap sprite
        }

        budget100 = GetComponentsInChildren<Button>()[1];
        if (offer.budgetCost * 1f > Player.Instance.budget)
        {
            budget100.interactable = false;
            budget100.GetComponent<Image>().sprite = unavailableButton;
            //swap sprite
        }
        else if (offer.budgetCost * 1f <= Player.Instance.budget)
        {
            budget100.interactable = true;
            budget100.GetComponent<Image>().sprite = availableButton;
            //swap sprite
        }


        // swap other buttons
        PayButton.interactable = true;
    }

 


    public void CloseOffer()
    {
        Player.Instance.budget -= BudgetAmount;
        PayButton.interactable = false;
        LogBookControl.Instance.AddOffer(offer.OfferID, BudgetAmount, true, false,Booster);
        foreach(Button button in GetComponentsInChildren<Button>())
        {
            button.interactable = false;
        }
        offerClosed = true;

        Player.Instance.Calculate_UI_Info();
        PieGraph.Instance.RefreshGraph();
    }

}
