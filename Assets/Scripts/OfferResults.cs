using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class OfferResults : MonoBehaviour
{
    private TMP_Text titleText;
    private TMP_Text subtitleText;
    private TMP_Text infoText;
    private Image SDG1;
    private Image SDG2;
    private Image SDG3;
    private Image CoverImage;
    private Button ClaimButton;
    private Offer readyOffer;
    private int claimedPaidBudget;
    private int ExtraExp;
    private float Booster;
    public void InitializeOfferResults(Offer offer , int paidBudgert, bool canBeClaimed , bool claimed, int booster)
    {
        Booster = booster;
        readyOffer = offer;
        claimedPaidBudget = paidBudgert;
        titleText = GetComponentsInChildren<TMP_Text>()[0];
        subtitleText = GetComponentsInChildren<TMP_Text>()[1];
        infoText = GetComponentsInChildren<TMP_Text>()[2];
        SDG1 = GetComponentsInChildren<Image>()[1];
        SDG2 = GetComponentsInChildren<Image>()[2];
        SDG3 = GetComponentsInChildren<Image>()[3];
        CoverImage= GetComponentsInChildren<Image>()[5];
        ClaimButton = GetComponentInChildren<Button>();
        titleText.text = offer.title_Text;
        subtitleText.text = offer.main_Text;
        subtitleText.text = "Paid Budget : " + paidBudgert.ToString();
        SDG1.sprite = offer.SDG1;
        SDG2.sprite = offer.SDG2;
        SDG3.sprite = offer.SDG3;
        CoverImage.gameObject.SetActive(false);
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
        Booster= (Booster + 100) / 100;
        float x = (float)claimedPaidBudget /(float) readyOffer.budgetCost;       
        float claimedExp =x* readyOffer.expiriencePoints;
        claimedExp = Mathf.RoundToInt(claimedExp * Booster);
        Debug.Log(claimedExp);
        Player.Instance.Expirience += claimedExp* readyOffer.expiriencePoints;
        Player.Instance.budget += Mathf.RoundToInt(readyOffer.budgetCost * 0.1f);        
        ClaimButton.interactable = false;
        Player.Instance.Calculate_UI_Info();
    }
}
