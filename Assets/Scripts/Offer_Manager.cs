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
    public int offerBudget;
    public TMP_Text budget_Text;
    private Button budget30;
    private Button budget100;
    private Button budget120;
    private Button PayButton;
    private Offer_GPGraph offer_GPGraph;
    private int BudgetAmount;
    [SerializeField]
    private TMP_Text Duration_text=null;   
    [SerializeField]
    private Sprite availableButton30=null;
    [SerializeField]
    private Sprite unavailableButton30=null;
    [SerializeField]
    private Sprite selectedButton30=null;
    [SerializeField]
    private Sprite availableButton100=null;
    [SerializeField]
    private Sprite unavailableButton100=null;
    [SerializeField]
    private Sprite selectedButton100=null;
    [SerializeField]
    private Sprite availableButton120=null;
    [SerializeField]
    private Sprite unavailableButton120=null;
    [SerializeField]
    private Sprite selectedButton120=null;
    [SerializeField]
    private Sprite BudgetImageEmpty = null;
    [SerializeField]
    private Sprite BudgetImage30 = null;
    [SerializeField]
    private Sprite BudgetImage100 = null;
    [SerializeField]
    private Sprite BudgetImage120 = null;
    [SerializeField]
    private Slider BudgetSlider = null;
    IEnumerator sliderCoRoutine;
    public bool offerClosed = false;
    private int Booster;
    private float commitPercent;

    private Color32 minimumGreen=new Color32(41,120,51,255);
    private Color32 mediumGreen= new Color32(57,181,74,255);
    private Color32 fullGreen=new Color32(75,236,97,255);
    private void Awake()
    {
        InitializeValues();
        offer_GPGraph = GetComponentInChildren<Offer_GPGraph>();
    }

    private void InitializeValues()
    {
        TMP_Text[] tMP_Texts = GetComponentsInChildren<TMP_Text>();
        title_Text = tMP_Texts[0];
        budget_Text= tMP_Texts[1]; 
    }

    public void SetOfferValues() {
        title_Text.text = offer.title_Text;
        BudgetAmount = 0;
        budget_Text.text = BudgetAmount.ToString() + "/" + offer.budgetCost.ToString();
       
        BudgetSlider.value = 0;
        BudgetSlider.GetComponentsInChildren<Image>()[2].color = minimumGreen;
       
        offerBudget = offer.budgetCost;
        Duration_text.text = "Report: " + offer.DurationInSec + "\"";
        budget30 = GetComponentsInChildren<Button>()[0];
        budget30.GetComponent<Image>().sprite = availableButton30;
        budget30.interactable = true;
        budget100 = GetComponentsInChildren<Button>()[1];
        budget100.GetComponent<Image>().sprite = availableButton100;
        budget100.interactable = true;
        budget120 = GetComponentsInChildren<Button>()[2];
        budget120.GetComponent<Image>().sprite = availableButton120;
        budget120.interactable = true;
        GetButtons();
        offerClosed = false;
    }
    private void GetBooster()
    {
        if (offer.OfferID < 2000)
        {
            //Booster = GameMaster.Instance.CampaignStars[0]*10;
            Booster = GameMaster.Instance.CampaignStars[0];
        }
        else if (offer.OfferID < 3000)
        {
            // Booster = GameMaster.Instance.CampaignStars[1] * 10;
            Booster = GameMaster.Instance.CampaignStars[1];
        }
        else if (offer.OfferID < 4000)
        {
            // Booster = GameMaster.Instance.CampaignStars[2] * 10;
            Booster = GameMaster.Instance.CampaignStars[2];
        }
        else if (offer.OfferID < 5000)
        {
            // Booster = GameMaster.Instance.CampaignStars[3] * 10;
            Booster = GameMaster.Instance.CampaignStars[3];
        }
        else if (offer.OfferID < 6000)
        {
            // Booster = GameMaster.Instance.CampaignStars[4] * 10;
            Booster = GameMaster.Instance.CampaignStars[4];
        }
        else if (offer.OfferID < 7000)
        {
            //  Booster = GameMaster.Instance.CampaignStars[5] * 10;
            Booster = GameMaster.Instance.CampaignStars[5];
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

    public void GetButtons()
    {
        if (Player.Instance.budget < BudgetAmount)
        {
            BudgetAmount = 0;
            PayButton.interactable = false;
        }
        budget30 = GetComponentsInChildren<Button>()[0];
        if (offer.budgetCost * 0.3f > Player.Instance.budget)
        {
            budget30.interactable = false;
            budget30.GetComponent<Image>().sprite = unavailableButton30;
            //swap sprite
        }
        else if(offer.budgetCost * 0.3f <= Player.Instance.budget)
        {
            budget30.interactable = true;
            if(budget30.GetComponent<Image>().sprite != selectedButton30)
            {
                budget30.GetComponent<Image>().sprite = availableButton30;
            }
        }


        budget100 = GetComponentsInChildren<Button>()[1];
        if (offer.budgetCost * 1f > Player.Instance.budget)
        {
            budget100.interactable = false;
            budget100.GetComponent<Image>().sprite = unavailableButton100;
            //swap sprite
        }
        else if(offer.budgetCost * 1f <= Player.Instance.budget)
        {
            budget100.interactable = true;
            if (budget100.GetComponent<Image>().sprite != selectedButton100)
            {
                budget100.GetComponent<Image>().sprite = availableButton100;
            }

        }


        budget120 = GetComponentsInChildren<Button>()[2];
        if (offer.budgetCost * 1.3f > Player.Instance.budget)
        {
            budget120.interactable = false;
            budget120.GetComponent<Image>().sprite = unavailableButton120;
            //swap sprite
        }
        else if(offer.budgetCost * 1.3f <= Player.Instance.budget)
        {
            budget120.interactable = true;
            if (budget120.GetComponent<Image>().sprite != selectedButton120)
            {
              budget120.GetComponent<Image>().sprite = availableButton120;
            }

        }


        PayButton = GetComponentsInChildren<Button>()[3];


    }

    public void PayBudget30()
    {
        
        BudgetAmount = Mathf.RoundToInt(offer.budgetCost * 0.3f);
        budget30.GetComponent<Image>().sprite = selectedButton30;
        commitPercent = 30;
        if (sliderCoRoutine != null)
            StopCoroutine(sliderCoRoutine);
        sliderCoRoutine = MoveBudgetSlider(30);
        StartCoroutine(sliderCoRoutine);

        if (Player.Instance.budget >= offerBudget * 1.2f)
        {
            budget120.GetComponent<Image>().sprite = availableButton120;
        }
        else
        {
            budget120.GetComponent<Image>().sprite = unavailableButton120;
        }

        if (Player.Instance.budget >= offerBudget)
        {           
            budget100.GetComponent<Image>().sprite = availableButton100;
        }
        else
        {
            budget100.GetComponent<Image>().sprite = unavailableButton100;
        }


        budget_Text.text = BudgetAmount.ToString() + "/" + offer.budgetCost.ToString();
        PayButton.interactable = true;
    }

    public void PayBudget100()
    {
        BudgetAmount = Mathf.RoundToInt(offer.budgetCost * 1.0f);
        budget100.GetComponent<Image>().sprite = selectedButton100;
        commitPercent = 100;
        if (sliderCoRoutine != null)
            StopCoroutine(sliderCoRoutine);
        sliderCoRoutine = MoveBudgetSlider(100);
        StartCoroutine(sliderCoRoutine);


        if (Player.Instance.budget >= offerBudget * 0.3f)
        {
            budget30.GetComponent<Image>().sprite = availableButton30;
        }
        else
        {
            budget30.GetComponent<Image>().sprite = unavailableButton30;
        }

        if (Player.Instance.budget >= offerBudget*1.2f)
        {
            budget120.GetComponent<Image>().sprite = availableButton120;
        }
        else
        {
            budget120.GetComponent<Image>().sprite = unavailableButton120;
        }




        budget_Text.text = BudgetAmount.ToString() + "/" + offer.budgetCost.ToString();
        // swap other buttons
        PayButton.interactable = true;
    }

    public void PayBudget120()
    {
        BudgetAmount = Mathf.RoundToInt(offer.budgetCost * 1.2f);
        budget120.GetComponent<Image>().sprite = selectedButton120;
        commitPercent = 120;
        if (sliderCoRoutine!=null)
            StopCoroutine(sliderCoRoutine);
        sliderCoRoutine = MoveBudgetSlider(120);
        StartCoroutine(sliderCoRoutine);


        if (Player.Instance.budget >= offerBudget * 0.3f)
        {
            budget30.GetComponent<Image>().sprite = availableButton30;
        }
        else
        {
            budget30.GetComponent<Image>().sprite = unavailableButton30;
        }

        if (Player.Instance.budget >= offerBudget)
        {
            budget100.GetComponent<Image>().sprite = availableButton100;
        }
        else
        {
            budget100.GetComponent<Image>().sprite = unavailableButton100;
        }





        budget_Text.text = BudgetAmount.ToString() + "/" + offer.budgetCost.ToString();
        // swap other buttons
        PayButton.interactable = true;
    }


    public void CloseOffer()
    {
        GetBooster();
        Player.Instance.budget -= BudgetAmount;
        PayButton.interactable = false;
        // add campaing sprite here
        //--
        //--
        //--
        //--
        //---------------------
        LogBookControl.Instance.AddOffer(offer.OfferID, BudgetAmount, true, false,Booster,commitPercent,offer.GP,GetCampaingSprite());

        
        if (budget30.GetComponent<Image>().sprite!=selectedButton30)
        budget30.GetComponent<Image>().sprite = unavailableButton30;
        budget30.interactable = false;
        
        if (budget100.GetComponent<Image>().sprite != selectedButton100)           
        budget100.GetComponent<Image>().sprite = unavailableButton100;
        budget100.interactable = false;

        if(budget120.GetComponent<Image>().sprite!=selectedButton120)
        budget120.GetComponent<Image>().sprite = unavailableButton120;
        budget120.interactable = false;
       

        offerClosed = true;
        Offer_Tab_Controller.Instance.FileUP_Animation();
        Offer_Tab_Controller.Instance.checkForOtherOffers();
        Player.Instance.Calculate_UI_Info();
    }

    private IEnumerator  MoveBudgetSlider(float target)
    {
        while (Mathf.Abs(BudgetSlider.value - target) > 0.1f)
        {
            BudgetSlider.value = Mathf.Lerp(BudgetSlider.value, target, 5 * Time.deltaTime);
            if (BudgetSlider.value > 103)
            {
                BudgetSlider.GetComponentsInChildren<Image>()[2].color = fullGreen;
            }
            else if(BudgetSlider.value<=103&& BudgetSlider.value>31)
            {
                BudgetSlider.GetComponentsInChildren<Image>()[2].color = mediumGreen;
            }
            else
            {
                BudgetSlider.GetComponentsInChildren<Image>()[2].color = minimumGreen;
            }
            yield return null;
        }
       
    }

    private Sprite GetCampaingSprite()
    {

        if (offer.OfferID < 2000)
        {
            return Player.Instance.ActiveStrategySprites[0];
        }
        else if (offer.OfferID < 3000)
        {
            return Player.Instance.ActiveStrategySprites[1];
        }
        else if (offer.OfferID < 4000)
        {
            return Player.Instance.ActiveStrategySprites[2];
        }
        else if (offer.OfferID < 5000)
        {
            return Player.Instance.ActiveStrategySprites[3];
        }
        else if (offer.OfferID < 6000)
        {
            return Player.Instance.ActiveStrategySprites[4];
        }
        else if (offer.OfferID < 7000)
        {
            return Player.Instance.ActiveStrategySprites[5];
        }
        else
        {
            return null;
        }


        
    }
}
