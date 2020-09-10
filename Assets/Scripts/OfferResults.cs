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
    private Image Campaing_Support_Image;
    [SerializeField]
    private Image Offer_Info_Text;
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
    private float budget_Commit_Percent;
    private Offer readyOffer;
    private int claimedPaidBudget;
    private float Exp;
    private float Booster;
    private float[] GPs = new float[6];
    [SerializeField]
    private Image OfferStrategyImage = null;
    ActivatedOffer connectedActivatedOffer=null;
    [SerializeField]
    private Image Campaing_Bonus_text_Image=null;
    [SerializeField]
    private Image GP_Image=null;
    [SerializeField]
    private Image Total_Points_image=null;
    [SerializeField]
    private TMP_Text achievement_GP_text=null;
    public void InitializeOfferResults(Offer offer , int paidBudgert, bool canBeClaimed , bool claimed, int booster , float commitPercent, ActivatedOffer ConnectedAO,float[] gps,Sprite CampaingSprite)
    {
        Booster = booster;
        readyOffer = offer;
        claimedPaidBudget = paidBudgert;

        connectedActivatedOffer = ConnectedAO;
        GPs = gps;
        GetHighestGP_Sprite(gps);
        Offer_campaing_image.sprite = CampaingSprite;
        if (Booster > 0)
        {           
            Campaing_Support_Image.sprite = GameMaster.Instance.campaingReportSprites[0];
            Total_Points_image.sprite = GameMaster.Instance.Total_Points_Sprites[0];
            if (Booster == 1)
            {
                Offer_Info_Text.sprite = GameMaster.Instance.OfferResult_Text[1];
            }else if (Booster == 2)
            {
                Offer_Info_Text.sprite = GameMaster.Instance.OfferResult_Text[2];
            }
            else if (Booster == 3)
            {
                Offer_Info_Text.sprite = GameMaster.Instance.OfferResult_Text[3];
            }
        }
        else if(Booster==0)
        {
            Campaing_Support_Image.sprite = GameMaster.Instance.campaingReportSprites[1];
            Offer_Info_Text.sprite = GameMaster.Instance.OfferResult_Text[0];
            Total_Points_image.sprite = GameMaster.Instance.Total_Points_Sprites[1];
        }


        budget_Commit_Percent = commitPercent;
        GetOfferPoints();

      

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

    private void GetHighestGP_Sprite(float[] GPs)
    {
        float max=0;
        float GPScore=0;
        for(int i = 0; i < GPs.Length; i++)
        {
            if (GPs[i] > max)
            {
                max = GPs[i];
                GP_Image.sprite = GameMaster.Instance.GP_Result_Sprites[i];
                GPScore = Player.Instance.GPs[i];
            }
        }

        // check max to determine achievement

        if (GPScore >= 140)
        {
            achievement_GP_text.text = (GPScore+max).ToString() + " / 300";
        }
        else if (GPScore >= 60)
        {
            achievement_GP_text.text = (GPScore + max).ToString() + " / 140";
        }
        else if (GPScore >= 20)
        {
            achievement_GP_text.text = (GPScore + max).ToString() + " / 60";
        }
        else if (GPScore < 20)
        {
            achievement_GP_text.text = (GPScore + max).ToString() + " / 20";
        }
        else
        {
            achievement_GP_text.text = "0000";
        }


    }
    private void GetOfferPoints()
    {
        if (Booster == 3) {
           
            if (budget_Commit_Percent >= 1.2f)
            {
                Exp = 30;
            }else if(budget_Commit_Percent>=1.0f)
            {
                Exp = 27;
            }else if (budget_Commit_Percent >= 0.3f)
            {
                Exp = 18;
            }

        } else if (Booster == 2) {

            if (budget_Commit_Percent >= 1.2f)
            {
                Exp = 25;
            }
            else if (budget_Commit_Percent >= 1.0f)
            {
                Exp = 20;
            }
            else if (budget_Commit_Percent >= 0.3f)
            {
                Exp = 15;
            }

        } else if (Booster == 1)
        {
            if (budget_Commit_Percent >= 1.2f)
            {
                Exp = 20;
            }
            else if (budget_Commit_Percent >= 1.0f)
            {
                Exp = 18;
            }
            else if (budget_Commit_Percent >= 0.3f)
            {
                Exp = 10;
            }

        } else if (Booster == 0)
        {
            Exp = 0;
        }
        


       
    }
   
}
