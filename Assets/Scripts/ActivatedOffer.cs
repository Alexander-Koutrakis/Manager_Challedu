using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ActivatedOffer : MonoBehaviour
{    
    private string titleText;
    private string subtitleText;
    private int paidBudget;
    private int paidPeople;
    private int paidProducts;
    public float timer;
    public string resultText;
    private TMP_Text titlteTextComp;
    private TMP_Text subtitleTextComp;
    private Slider sliderTimer;
    private Button claimButton;
    public GameObject activatedResultsGO;
    bool canBeClaimed=false;
    bool Claimed = false;
    Offer offer;
  [SerializeField]
    private Sprite ClaimedOffer;// swap sprite if offer is claimed
   

    public void InitializeActivatedOffer(int INofferIDin,int budgetPaid, int peoplePaid , int productPaid,GameObject offerResult,bool INcanBeClaimed, bool INClaimed)
    {
        offer = GameMaster.Instance.Offers[INofferIDin];
        titleText = offer.title_Text;
        subtitleText = offer.main_Text;
        timer = offer.DurationInSec;
        activatedResultsGO = offerResult;
        canBeClaimed = INcanBeClaimed;
        Claimed = INClaimed;

        titlteTextComp = GetComponentsInChildren<TMP_Text>()[0];
        subtitleTextComp = GetComponentsInChildren<TMP_Text>()[1];
        sliderTimer = GetComponentInChildren<Slider>();
        claimButton = GetComponentsInChildren<Button>()[1];
        claimButton.interactable = false;
        titlteTextComp.text = titleText;
        subtitleTextComp.text = subtitleText;
        sliderTimer.maxValue = timer;
        sliderTimer.value = 0;
        // if can be claimed or Claimed sliderTimer.value=0.1f;
        StartCoroutine(startCooldown(budgetPaid, peoplePaid, productPaid));

    }

    IEnumerator startCooldown(int paidBudget,int paidPeople , int paidProducts)
    {
        while (sliderTimer.value < sliderTimer.maxValue)
        {
            sliderTimer.value += Time.deltaTime;
            yield return null;
        }

        Debug.Break();
        canBeClaimed = true;
        activatedResultsGO.GetComponent<OfferResults>().InitializeOfferResults(offer, paidBudget, paidPeople, paidProducts, canBeClaimed, Claimed);
        claimButton.interactable = true;
        yield return null;
    }

    public void ButtonPress()
    {
        activatedResultsGO.transform.SetAsLastSibling();
    }

}
