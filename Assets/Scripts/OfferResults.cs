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

    public void InitializeOfferResults(Offer offer , int paidBudgert, int paidPeople, int paidProducts, bool canBeClaimed , bool claimed)
    {
        Debug.Log("Here");
        titleText = GetComponentsInChildren<TMP_Text>()[0];
        subtitleText = GetComponentsInChildren<TMP_Text>()[1];
        infoText = GetComponentsInChildren<TMP_Text>()[2];
        SDG1 = GetComponentsInChildren<Image>()[1];
        SDG2 = GetComponentsInChildren<Image>()[2];
        SDG3 = GetComponentsInChildren<Image>()[3];
        CoverImage= GetComponentsInChildren<Image>()[5];

        titleText.text = offer.title_Text;
        subtitleText.text = offer.main_Text;
        subtitleText.text = "Paid Budget : " + paidBudgert.ToString() + "\\n Paid People : " + paidPeople.ToString() + "\\n Paid Poducts : " + paidProducts.ToString();
        SDG1.sprite = offer.SDG1;
        SDG2.sprite = offer.SDG2;
        SDG3.sprite = offer.SDG3;

        if (canBeClaimed)
        {
            CoverImage.gameObject.SetActive(false);
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
}
