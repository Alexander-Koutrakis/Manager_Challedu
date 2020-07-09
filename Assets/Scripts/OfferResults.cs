using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class OfferResults : MonoBehaviour
{
    [SerializeField]
    private TMP_Text titleText=null;
    [SerializeField]
    private TMP_Text subtitleText=null;
    [SerializeField]
    private TMP_Text infoText=null;
    [SerializeField]
    private Image SDG1=null;
    [SerializeField]
    private Image SDG2=null;
    [SerializeField]
    private Image SDG3=null;
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
        subtitleText = GetComponentsInChildren<TMP_Text>()[1];// probably removed
        infoText = GetComponentsInChildren<TMP_Text>()[2];// probably removed
        SDG1 = GetComponentsInChildren<Image>()[1];
        SDG2 = GetComponentsInChildren<Image>()[2];
        SDG3 = GetComponentsInChildren<Image>()[3];
        CoverImage= GetComponentsInChildren<Image>()[5];
        ClaimButton = GetComponentInChildren<Button>();
        titleText.text = offer.title_Text;
        subtitleText.text = offer.main_Text;
        subtitleText.text = "Paid Budget : " + paidBudgert.ToString();
        SDG1.sprite = offer.SDG1;
        Debug.Log(offer.SDG1.name);
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
        Player.Instance.Expirience += claimedExp;
        Player.Instance.budget += Mathf.RoundToInt(readyOffer.budgetCost * 0.1f);        
        ClaimButton.interactable = false;
        Player.Instance.GetSDG(readyOffer.SDGs);
        Player.Instance.Calculate_UI_Info();
    }
}
