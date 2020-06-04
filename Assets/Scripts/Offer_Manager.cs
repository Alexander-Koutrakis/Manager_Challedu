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
    private int maxBudgetCost;
    private int maxPeopleCost;
    private int maxProductCost;   
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI mainText;

    public Slider budgetSlider;
    public Slider peopleSlider;
    public Slider productSlider;
    public TextMeshProUGUI Budget_Text;
    public TextMeshProUGUI People_Text;
    public TextMeshProUGUI Product_Text;
    public TextMeshProUGUI BudgetPaying_Text;
    public TextMeshProUGUI PeoplePaying_Text;
    public TextMeshProUGUI ProductPaying_Text;
    private float total;
    public float[] SDGscore ;
    private float paidAmount;
    private float fractal;
    public bool ActiveOffer = false;

    public bool closedoffer = false;


    Offer_GPGraph offer_GPGraph;
    // public Item item
    public RectTransform ApprovedImage;
    public RectTransform HideImage;
    public Color GrayOutColor;
    public Transform parentTab;
    private Color[] startingcolors;
    
    public void GetOfferData(Offer offerDT) {
        ResetColors(startingcolors);
        HideImage.GetComponent<Image>().raycastTarget = false;
        offer = offerDT;
        maxBudgetCost = offerDT.budgetCost;
        maxPeopleCost = offerDT.peopleCost;
        maxProductCost = offerDT.productCost;
        SDGscore = new float[17];

        titleText.text = offerDT.title_Text;
        mainText.text = offerDT.main_Text;

        budgetSlider.maxValue = maxBudgetCost;
        peopleSlider.maxValue = maxPeopleCost;
        productSlider.maxValue = maxProductCost;

       budgetSlider.value = 0;
       peopleSlider.value = 0;
       productSlider.value = 0;

        Budget_Text.text =maxBudgetCost.ToString();
        People_Text.text =maxPeopleCost.ToString();
        Product_Text.text =maxProductCost.ToString();
      
        total= offerDT.budgetCost + offerDT.peopleCost*100 + offerDT.productCost*10; // total cost

        offer_GPGraph = GetComponentInChildren<Offer_GPGraph>();
       

    }

    private void Awake()
    {
        startingcolors = GetTabColors();
    }
  
    public void CheckSliders()
    {


        if (budgetSlider.value > Player_Controller.player_Controller.budget)
        {
            budgetSlider.value = Player_Controller.player_Controller.budget;
        }

        if (peopleSlider.value > Player_Controller.player_Controller.people)
        {
            
            peopleSlider.value = Player_Controller.player_Controller.people;
        }

        if (productSlider.value > Player_Controller.player_Controller.products)
        {
            productSlider.value = Player_Controller.player_Controller.products;
        }

        BudgetPaying_Text.text = budgetSlider.value.ToString();
        PeoplePaying_Text.text = peopleSlider.value.ToString();
        ProductPaying_Text.text = productSlider.value.ToString();

    }

    public void PayOffer()
    {
        PayBudgetCost();
        PayPeopleCost();
        PayProductCost();
   
        UI_Controller.ui_Controller.RefreshResourcesText();
        fractal=(budgetSlider.value + peopleSlider.value * 100 + productSlider.value * 10)/ total;
        Debug.Log(fractal);
        if (fractal != 0)
        {
            CheckForApproved();
            Activate_Offer();
            closedoffer = true;
        }
    }

    private void PayBudgetCost() {
        int payingAmount = 0; ;
        if (budgetSlider.value > Player_Controller.player_Controller.budget)
        {
            payingAmount = Player_Controller.player_Controller.budget;
        }
        else
        {
            payingAmount = (int)budgetSlider.value;
        }

        Player_Controller.player_Controller.budget -= payingAmount;      
    }

    private void PayPeopleCost()
    {
        int payingAmount = 0; ;
        if (peopleSlider.value > Player_Controller.player_Controller.people)
        {
            payingAmount = Player_Controller.player_Controller.people;
        }
        else
        {
            payingAmount = (int)peopleSlider.value;
        }
        Player_Controller.player_Controller.people -= payingAmount;
    }

    private void PayProductCost()
    {
        int payingAmount=0;
        if (productSlider.value > Player_Controller.player_Controller.products)
        {
            payingAmount = Player_Controller.player_Controller.products;
        }
        else
        {
            payingAmount = (int)productSlider.value;
        }

        Player_Controller.player_Controller.products -= payingAmount;

    }


    private void GetSDGscore()
    {
        for (int i = 0; i < offer.SDGs.Length; i++)
        {
             SDGscore[i] = offer.SDGs[i] * fractal;                    
        }
    }

    public void ActivateOffer() {

        List<Offer_Manager> offer_manager_list = GetComponentInParent<Offer_Tab_Controller>().offer_manager_list;
        foreach(Offer_Manager OM in offer_manager_list)
        {
            OM.ActiveOffer = false;
            Offer_GPGraph om_GPGraph = OM.GetComponentInChildren<Offer_GPGraph>();
            om_GPGraph.HideGraph();
        }
        ActiveOffer = true;
        Offer_GPGraph offer_GPGraph = GetComponentInChildren<Offer_GPGraph>();
        offer_GPGraph.ShowGraph(offer.GP);

    }

    private float SuccessRate()
    {
        float x = GetExpPoints( offer.GP[1]) ;// calculate expirience points;
        float y = offer.GP[2] * Random.Range(0.5f, 1.6f);// calculate impact
        float z = offer.GP[4] *Random.Range(0.5f,2.6f); // calculate innovation
        float o = (int)offer.GP[3]; // calculate specialty
        float w = (x + y + z + o);
        w= GetSuccessRate(w)/137.5f;//<----------Temporary till AI        
        return (w); 
    }

    private float PublicityRate()
    {
        float x = offer.GP[0] *2;           // calculate publicity poinys
        float y = offer.GP[5] * 4;          // calculate Exclucity points
        float z = offer.GP[4];              // calculate innovation points
        float o = offer.GP[2];              // calculate impact points
        float w = (x + y + z + o)/40;

        return(w) ;
    }

    private float GetExpPoints(float i)
    {
        float x;
        if (i == 1) {
            x = Random.Range(0, 2.1f);
        }else if (i == 2)
        {
            x = Random.Range(2, 4.1f);
        }else if (i == 3)
        {
            x = Random.Range(4, 6.1f);
        }else if (i == 4)
        {
            x = Random.Range(6, 8.1f);
        }else if (i == 5)
        {
            x = Random.Range(8, 10.1f);
        }
        else
        {
            x = 0;
        }

        return x;
    }

    //temporary solution to AI
    private float GetSuccessRate(float x)
    {
        float rate;
        if (x <= 7)
        {
            rate = x * 0.5f;
        }else if (x <= 12)
        {
            rate = x * 0.7f;
        }else if (x <= 17)
        {
            rate = x * 0.9f;
        }else if (x <= 22)
        {
            rate = x;
        }else if (x <= 27)
        {
            rate = x * 1.1f;
        }else 
        {
            rate = x * 1.2f;
        }


        return rate;
    }

    public void CheckForApproved()
    {        
         if (budgetSlider.value != 0 || peopleSlider.value != 0 || productSlider.value != 0) {

            foreach (Image image in parentTab.GetComponentsInChildren<Image>()) {
                if (image.transform.name != "Approved" && image.transform.name != "Hide")
                {
                    StartCoroutine(ChangeColor(image, GrayOutColor));
                }
            }     
            if (budgetSlider.value == maxBudgetCost && peopleSlider.value == maxPeopleCost && productSlider.value == maxProductCost) {
                LeanTween.alpha(ApprovedImage, 1, 1f);
            }
            closedoffer = true;
            HideImage.GetComponent<Image>().raycastTarget = true;
        }
        else
        {
            HideImage.GetComponent<Image>().raycastTarget = false;
           // LeanTween.alpha(ApprovedImage, 0, 0.1f);
            ApprovedImage.GetComponent<Image>().color = new Color(0, 0, 0, 0);
        }      
    }

    private Color[] GetTabColors() {
        Color[] colors = new Color[parentTab.GetComponentsInChildren<Image>().Length];
        Image[] images = parentTab.GetComponentsInChildren<Image>();
        for (int i = 0; i < colors.Length; i++) {
            colors[i] = images[i].color;
        }
        return colors;
    }

    private void ResetColors(Color[] colors) {
        Image[] images = parentTab.GetComponentsInChildren<Image>();
        for (int i = 0; i < colors.Length; i++) {
            images[i].color = colors[i];        
        }

    }

    private IEnumerator ChangeColor(Image image,Color color) {
        while (image.color != color)
        {
            image.color = Color.Lerp(image.color, color, Time.deltaTime*2);
            yield return null;
        }
    
    }


    public void Activate_Offer() {
      
        GetSDGscore();
        Active_Offer active_Offer = GameMaster.gameMaster.gameObject.AddComponent<Active_Offer>();
        active_Offer.SDGscore = SDGscore;
        active_Offer.offer = offer;       
        active_Offer.ReputationScore = SuccessRate() + PublicityRate();
        active_Offer.ReputationScore = active_Offer.ReputationScore * fractal;
        active_Offer.Duration = offer.DurationInSec;
        GameMaster.gameMaster.active_Offer_List.Add(active_Offer);
       // GameMaster.NextRound -= Activate_Offer;
        GameMaster.gameMaster.Avtivate_Offers();
    }

    public void GetOfferManagerData(Offer_Manager OM) {
        offer = OM.offer;
        maxBudgetCost = OM.maxBudgetCost;
        maxPeopleCost = OM.maxPeopleCost;
        maxProductCost = OM.maxProductCost;
    }

    private void ResetSliderValues()
    {       
            budgetSlider.value = 0;
            peopleSlider.value = 0;
            productSlider.value = 0;       
    }

    private void OnDisable()
    {
        GameMaster.NextRound -= Activate_Offer;
    }

}
