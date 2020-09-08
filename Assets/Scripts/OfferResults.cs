using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class OfferResults : MonoBehaviour
{
    [SerializeField]
    private TMP_Text MainText=null;
    [SerializeField]
    private TMP_Text SubText = null;
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
    private Button ClaimButton;
    private Offer readyOffer;
    private int claimedPaidBudget;
    private float Exp;
    private float Booster;
    ActivatedOffer connectedActivatedOffer;
    public void InitializeOfferResults(Offer offer , int paidBudgert, bool canBeClaimed , bool claimed, int booster , float commitPercent, ActivatedOffer ConnectedAO)
    {
        Booster = booster;
        readyOffer = offer;
        claimedPaidBudget = paidBudgert;
        ClaimButton = GetComponentInChildren<Button>();
        connectedActivatedOffer = ConnectedAO;

        if (Booster > 0)
        {
            MainText.text = "Η προταση που επέλεξες συμβαδίζει με \n τη στρατιγική της εταιρείας";
        }
        else if(Booster==0)
        {
            MainText.text = "Η προταση που επέλεξες δεν συμβαδίζει με \n τη στρατιγική της εταιρείας";
        }



        Booster = (Booster + 100) / 100;
        float x = (float)claimedPaidBudget / (float)readyOffer.budgetCost;
        float claimedExp = x * readyOffer.expiriencePoints;
        claimedExp = Mathf.RoundToInt(claimedExp * Booster);
        Exp = claimedExp;
        SubText.text = "Επέλεξες να υποστηρίξεις την πρόταση κατά " + commitPercent + "% \n Πήρες "+ Exp+" βαθμούς εμπειρίας";
        BudgetText.text =paidBudgert.ToString();
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
        if (canBeClaimed)
        {
            
            if (!claimed)
            {
                ClaimButton.interactable = true;
            }
            else
            {
                ClaimButton.interactable = false;
            }
        }

    }

    public void Claim_Offer()
    {

        MainText.color = Color.black;
        SubText.color = Color.black;
        GetComponent<Image>().sprite = Claimed_Sprite;
        connectedActivatedOffer.ClaimedOffer(SDG1.sprite,SDG2.sprite,SDG3.sprite, Exp);
        Player.Instance.Expirience += Exp;       
        ClaimButton.interactable = false;
        Player.Instance.GetSDG(readyOffer.SDGs);
        Player.Instance.Calculate_UI_Info();
        AchievementManager.Instance.CheckAchievements();
        PieGraph.Instance.RefreshGraph();
    }

    public void ShowReportButton()
    {
        LeanTween.alpha(CoverImage.rectTransform, 0, 0.5f);
        CoverImage.raycastTarget = false;
    }

   
}
