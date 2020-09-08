using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class OfferResults : MonoBehaviour
{
    [SerializeField]
    private Image Offer_campaing_image;
    [SerializeField]
    private Slider BudgetSlider;
    [SerializeField]
    private Image Campaing_Support_Image;
    [SerializeField]   
    private TMP_Text ExpText=null;
    [SerializeField]
    private TMP_Text BudgetText=null;
    [SerializeField]
    private Image SDG1=null;
    [SerializeField]
    private Image SDG2=null;
    [SerializeField]
    private Image SDG3=null;
    [SerializeField]
    private Image SliderFill_Image_1=null;
    [SerializeField]
    private Image SliderFill_Image_2=null;
    [SerializeField]
    private Image SliderFill_Image_3=null;
    [SerializeField]
    private Image CoverImage=null;
    [SerializeField]
    private Sprite Claimed_Sprite=null;

    private Offer readyOffer;
    private int claimedPaidBudget;
    private float Exp;
    private float Booster;
    private float[] GPs = new float[6];
    [SerializeField]
    private Image OfferStrategyImage = null;
    ActivatedOffer connectedActivatedOffer;
    [SerializeField]
    private Image Campaing_Bonus_text_Image;
    public void InitializeOfferResults(Offer offer , int paidBudgert, bool canBeClaimed , bool claimed, int booster , float commitPercent, ActivatedOffer ConnectedAO,float[] gps,Sprite CampaingSprite)
    {
        Booster = booster;
        readyOffer = offer;
        claimedPaidBudget = paidBudgert;

        connectedActivatedOffer = ConnectedAO;
        GPs = gps;

        Offer_campaing_image.sprite = CampaingSprite;
        if (Booster > 0)
        {
            // MainText.text = "Η προταση που επέλεξες συμβαδίζει με \n τη στρατιγική της εταιρείας";
            Campaing_Support_Image.sprite = GameMaster.Instance.campaingReportSprites[1];
        }
        else if(Booster==0)
        {
            //  MainText.text = "Η προταση που επέλεξες δεν συμβαδίζει με \n τη στρατιγική της εταιρείας";
            Campaing_Support_Image.sprite = GameMaster.Instance.campaingReportSprites[0];
        }



        Booster = (Booster + 100) / 100;
        float x = (float)claimedPaidBudget / (float)readyOffer.budgetCost;
        float claimedExp = x * readyOffer.expiriencePoints;
        claimedExp = Mathf.RoundToInt(claimedExp * Booster);
        BudgetSlider.value = commitPercent/100;
        Exp = claimedExp;
        //SubText.text = "Επέλεξες να υποστηρίξεις την πρόταση κατά " + commitPercent + "% \n Πήρες "+ Exp+" βαθμούς εμπειρίας";
        BudgetText.text =paidBudgert.ToString();
        Player.Instance.totalbudgetPaid += paidBudgert;// just for achievement checking
        ExpText.text = Exp.ToString();
        SDG1.sprite = offer.SDG1;
        SDG2.sprite = offer.SDG2;
        SDG3.sprite = offer.SDG3;
        // change slider collor according to SDG spite name(hex Color ID)
        Color sliderColor = new Color();
        if(ColorUtility.TryParseHtmlString("#" + offer.SDG1.name, out sliderColor))
        {
            SliderFill_Image_1.color = sliderColor;
        }

        if (ColorUtility.TryParseHtmlString("#" + offer.SDG2.name, out sliderColor))
        {
            SliderFill_Image_2.color = sliderColor;
        }

        if (ColorUtility.TryParseHtmlString("#" + offer.SDG3.name, out sliderColor))
        {
            SliderFill_Image_3.color = sliderColor;
        }



       // CoverImage.gameObject.SetActive(false); fade it in  a function
      

    }

    public void Claim_Offer()
    {

       
        GetComponent<Image>().sprite = Claimed_Sprite;
        connectedActivatedOffer.ClaimedOffer(SDG1.sprite,SDG2.sprite,SDG3.sprite, Exp);
        Player.Instance.Expirience += Exp;       
    
        Player.Instance.GetSDG(readyOffer.SDGs);
        Player.Instance.Calculate_UI_Info();
        Player.Instance.GetGPs(GPs);
        Player.Instance.offersAccepted++;
        
        AchievementManager.Instance.CheckAchievements();
        PieGraph.Instance.RefreshGraph();
    }

    public void ShowReportButton()
    {
        LeanTween.alpha(CoverImage.rectTransform, 0, 0.5f);
        CoverImage.raycastTarget = false;
    }

   
}
