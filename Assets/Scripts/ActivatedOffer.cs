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

    private Slider sliderTimer;
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
    [SerializeField]
    private Sprite NonSelected_Sprite = null;
    [SerializeField]
    private Image SDG1_Image = null;
    [SerializeField]
    private Image SDG2_Image = null;
    [SerializeField]
    private Image SDG3_Image = null;
    private int Booster;
    float commitPercentMain;
    [SerializeField]
    Button reportButton;
    public void InitializeActivatedOffer(int INofferIDin,int budgetPaid,GameObject offerResult,bool INcanBeClaimed, bool INClaimed,int booster, float commitPercent)
    {

        offer = GameMaster.Instance.Offers[INofferIDin];
        titleText = offer.title_Text;
        subtitleText = offer.main_Text;
        timer = offer.DurationInSec;
        activatedResultsGO = offerResult;
        canBeClaimed = false;
        Claimed = INClaimed;
        Booster = booster;
        commitPercentMain = commitPercent;
        titlteTextComp = GetComponentInChildren<TMP_Text>();
        sliderTimer = GetComponentInChildren<Slider>();
        titlteTextComp.text = titleText;

        sliderTimer.maxValue = timer;
        sliderTimer.value = 0;
        Main_Image.sprite = ProccessingOffer_Sprite;

        
        reportButton.interactable = false;
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
        activatedResultsGO.GetComponent<OfferResults>().InitializeOfferResults(offer, paidBudget, canBeClaimed, Claimed, Booster, commitPercentMain,this);
        reportButton.interactable = true;
        gameObject.transform.SetAsFirstSibling();
        yield return null;
    }

    public void ButtonPress()
    {
        LogBookControl.Instance.DeselectOffers();
        Main_Image.sprite = SelectedOffer_Sprite;
        activatedResultsGO.transform.SetAsLastSibling();
    }


    public void ReportPress()
    {
        activatedResultsGO.GetComponent<OfferResults>().ShowReportButton();
        reportButton.interactable = false;
    }

    public void DeselectActivatedOffer()
    {
        if (canBeClaimed&&!Claimed)
        {
            Main_Image.sprite = ReadyToBeClaimedOffer_Sprite;
        }else if (Claimed)
        {
            Main_Image.sprite = ProccessingOffer_Sprite;
        }else 
        {
            Main_Image.sprite = ProccessingOffer_Sprite;
        }
    }

    public void ClaimedOffer(Sprite SDG1, Sprite SDG2, Sprite SDG3) {
        Main_Image.sprite = ClaimedOffer_Sprite;
        Claimed = true;

        SDG1_Image.gameObject.SetActive(true);
        SDG1_Image.sprite = SDG1;

        SDG2_Image.gameObject.SetActive(true);
        SDG2_Image.sprite = SDG2;

        SDG3_Image.gameObject.SetActive(true);
        SDG3_Image.sprite = SDG3;
        reportButton.interactable = false;
        sliderTimer.gameObject.SetActive(false);
        transform.SetAsLastSibling();
        
    }

}
