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
    private Image Main_Image = null;
    [SerializeField]
    private Sprite ClaimedOffer_Sprite=null;// swap sprite if offer is claimed
    [SerializeField]
    private Sprite ReadyToBeClaimedOffer_Sprite=null;// swap sprite if offer is claimed
    [SerializeField]
    private Sprite ProccessingOffer_Sprite=null;// swap sprite if offer is claimed
    [SerializeField]
    private Sprite SelectedOffer_Sprite = null;// swap sprite if offer is claimed
    private int Booster;

    public void InitializeActivatedOffer(int INofferIDin,int budgetPaid,GameObject offerResult,bool INcanBeClaimed, bool INClaimed,int booster)
    {
        offer = GameMaster.Instance.Offers[INofferIDin];
        titleText = offer.title_Text;
        subtitleText = offer.main_Text;
        timer = offer.DurationInSec;
        activatedResultsGO = offerResult;
        canBeClaimed = INcanBeClaimed;
        Claimed = INClaimed;
        Booster = booster;

        titlteTextComp = GetComponentsInChildren<TMP_Text>()[0];
        subtitleTextComp = GetComponentsInChildren<TMP_Text>()[1];
        sliderTimer = GetComponentInChildren<Slider>();
        claimButton = GetComponentsInChildren<Button>()[1];
        claimButton.interactable = false;
        titlteTextComp.text = titleText;
        subtitleTextComp.text = subtitleText;
        sliderTimer.maxValue = timer;
        sliderTimer.value = 0;
        Main_Image.sprite = ProccessingOffer_Sprite;


        GetComponentInParent<LogBookControl>().LogOffers.Add(this);
        StartCoroutine(startCooldown(budgetPaid));

    }

    IEnumerator startCooldown(int paidBudget)
    {
        while (sliderTimer.value < sliderTimer.maxValue)
        {
            sliderTimer.value += Time.deltaTime;
            yield return null;
        }

       Main_Image.sprite = ReadyToBeClaimedOffer_Sprite;
       canBeClaimed = true;
        activatedResultsGO.GetComponent<OfferResults>().InitializeOfferResults(offer, paidBudget, canBeClaimed, Claimed, Booster);
        claimButton.interactable = true;
        yield return null;
    }

    public void ButtonPress()
    {
        LogBookControl.Instance.DeselectOffers();
        Main_Image.sprite = SelectedOffer_Sprite;
        activatedResultsGO.transform.SetAsLastSibling();
    }

    public void DeselectActivatedOffer()
    {
        if (canBeClaimed)
        {
            Main_Image.sprite = ReadyToBeClaimedOffer_Sprite;
        }else if (Claimed)
        {
            Main_Image.sprite = ClaimedOffer_Sprite;
        }else
        {
            Main_Image.sprite = ProccessingOffer_Sprite;
        }
    }
}
