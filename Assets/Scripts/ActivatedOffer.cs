using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class ActivatedOffer : MonoBehaviour
{    
    private string titleText;
    private int paidBudget;
    public float timer;
    public string resultText;
    private TMP_Text titlteTextComp;

    private Slider sliderTimer;
    public GameObject activatedResultsGO;
   public bool canBeClaimed=false;
   public bool Claimed = false;
    Offer offer;
    [SerializeField]
    private Image Main_Image = null;
    [SerializeField]
    private Image Selected_Image = null;
    [SerializeField]
    private Sprite ClaimedOffer_Sprite=null;// swap sprite if offer is claimed
    [SerializeField]
    private Sprite ReadyToBeClaimedOffer_Sprite=null;// swap sprite if offer is claimed
    [SerializeField]
    private Sprite ProccessingOffer_Sprite=null;// swap sprite if offer is claimed   
    [SerializeField]
    private Image SDG1_Image = null;
    [SerializeField]
    private Image SDG2_Image = null;
    [SerializeField]
    private Image SDG3_Image = null;
    [SerializeField]
    private TMP_Text points_Text = null;
    private int Booster;
    float commitPercentMain;
    [SerializeField]
    private Button reportButton=null;
    [SerializeField]
    Sprite PlayerCampaingSprite;
    float[] gps=new float[6];

    public void InitializeActivatedOffer(int INofferIDin,int budgetPaid,GameObject offerResult,bool INcanBeClaimed, bool INClaimed,int booster, float commitPercent, float[] GPs, Sprite CampaingSprite)
    {
        PlayerCampaingSprite = CampaingSprite;
        gps = GPs;
        offer = GameMaster.Instance.Offers[INofferIDin];
        titleText = offer.title_Text;
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
            //sliderTimer.value += Time.deltaTime;
            //yield return null;
            sliderTimer.value++;
            yield return new WaitForSeconds(1);
        }

        Main_Image.sprite = ReadyToBeClaimedOffer_Sprite;
        canBeClaimed = true;
        activatedResultsGO.GetComponent<OfferResults>().InitializeOfferResults(offer, paidBudget, canBeClaimed, Claimed, Booster, commitPercentMain,this,gps, PlayerCampaingSprite);
        reportButton.interactable = true;
        LogBookControl.Instance.ShowWarning();
        yield return null;
    }

    public void ButtonPress()
    {
        LogBookControl.Instance.DeselectOffers();
        Selected_Image.gameObject.SetActive(true);
        activatedResultsGO.transform.SetAsLastSibling();
        if (reportButton.interactable == true)
        {
            ReportPress();
        }
    }


    public void ReportPress()
    {
        activatedResultsGO.GetComponent<OfferResults>().ShowReportButton();
        activatedResultsGO.transform.SetAsLastSibling();
        activatedResultsGO.GetComponent<OfferResults>().Claim_Offer();
        LogBookControl.Instance.DeselectOffers();
        Selected_Image.gameObject.SetActive(true);
        reportButton.interactable = false;

    }

    public void DeselectActivatedOffer()
    {
        Selected_Image.gameObject.SetActive(false);
    }

    public void ClaimedOffer(Sprite SDG1, Sprite SDG2, Sprite SDG3,float points) {
        Main_Image.sprite = ClaimedOffer_Sprite;
        Claimed = true;
        canBeClaimed = true;
        SDG1_Image.gameObject.SetActive(true);
        SDG1_Image.sprite = SDG1;

        SDG2_Image.gameObject.SetActive(true);
        SDG2_Image.sprite = SDG2;

        SDG3_Image.gameObject.SetActive(true);
        SDG3_Image.sprite = SDG3;
        points_Text.text = points.ToString();
        points_Text.gameObject.SetActive(true);
        Destroy(reportButton.gameObject);
        Destroy(sliderTimer.gameObject);
        LogBookControl.Instance.HideWarning();     
    }

}
