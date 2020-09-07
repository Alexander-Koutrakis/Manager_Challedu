using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LogBookControl : MonoBehaviour
{
    public static LogBookControl Instance;
    public Transform OfferList_log;
    public Transform OfferResults_Log; 
    public GameObject activatedOfferGO;
    public GameObject OfferResultsGO;
    public Panel_Control panel_Control;  
    public List<ActivatedOffer> LogOffers = new List<ActivatedOffer>();
    [SerializeField]
    private RectTransform LogBookRect=null;
    private int currentPage=1;
    private int totalPages=0;
    [SerializeField]
    private TMP_Text page_Text=null;
    public bool warning = false;
    [SerializeField]
    private RectTransform warningSign;
    private bool waitButtonBool;
    private void Start()
    {
        Instance = this;
    }
    public void AddOffer(int offerID,int paidBudget, bool canBeClaimed, bool Claimed, int booster, float commitPercent, float[] gps,Sprite CampaingSprite)
    {
        //create 2 gameobjects 
        // one is for the list area and one for the info area
        // both objects are connected through the ActivatedOffer script

        ActivatedOffer activatedOffer;
        GameObject activatedOfferGO_Clone = Instantiate(activatedOfferGO, OfferList_log);
        GameObject OfferResults_Clone = Instantiate(OfferResultsGO, OfferResults_Log);
        activatedOfferGO_Clone.transform.SetAsFirstSibling();
        activatedOffer = activatedOfferGO_Clone.GetComponent<ActivatedOffer>();        
        activatedOffer.InitializeActivatedOffer(offerID, paidBudget, OfferResults_Clone, canBeClaimed,Claimed,booster,commitPercent,gps, CampaingSprite);
        OrganiseActivatedOffers();

        int x = Mathf.FloorToInt(LogOffers.Count / 4);
        if (LogOffers.Count % 4 == 0)
        {
            x--;
        }       
        totalPages = x+1;

        page_Text.text = currentPage.ToString() + " / " + totalPages.ToString();
    }

    public void DeselectOffers()
    {
        foreach(ActivatedOffer AO in LogOffers)
        {
            AO.DeselectActivatedOffer();
        }
    }

    
    public void NextPage()
    {       
       int x = (totalPages-1) * -588;
        if (LogBookRect.anchoredPosition.x > x&&!waitButtonBool)
        {
            LeanTween.moveLocalX(LogBookRect.gameObject, LogBookRect.anchoredPosition.x - 598, 0.5f).setOnComplete(buttonReady);
            currentPage++;
            page_Text.text = currentPage.ToString() + " / " + totalPages.ToString();
            waitButtonBool = true;
            
        }
    }

    public void PrevPage()
    {
        if (LogBookRect.anchoredPosition.x < 0&&!waitButtonBool)
        {
            LeanTween.moveLocalX(LogBookRect.gameObject, LogBookRect.anchoredPosition.x + 598, 0.5f).setOnComplete(buttonReady);
            currentPage--;
            page_Text.text = currentPage.ToString() + " / " + totalPages.ToString();
            waitButtonBool = true;
        }
    }


    public void OpenLogBook()
    {
        LogBookRect.anchoredPosition=new Vector3(0,0,0);
        currentPage = 1;
        page_Text.text = currentPage.ToString() + " / " + totalPages.ToString();
    }

    public void OrganiseActivatedOffers()
    {
        foreach(ActivatedOffer AO in LogOffers)
        {
            if (AO.canBeClaimed)
            {
                AO.transform.SetAsFirstSibling();
            }

            if (AO.Claimed)
            {
                AO.transform.SetAsLastSibling();
            }
        }
    }

    public void ShowWarning()
    {
        if (!warning)
        {
            warning = true;
            LeanTween.scale(warningSign.gameObject, new Vector3(1f, 1f, 1f), 0.5f).setOnComplete(WarningFollowUp);
        }
        Warning_Panel.Instance.ShowMessege("το Έργο ολοκληρώθηκε");
    }


    private void WarningFollowUp()
    {
        LeanTween.scale(warningSign.gameObject, new Vector3(1.5f, 1.5f, 1.5f), 0.5f).setLoopPingPong();
    }

    public void HideWarning()
    {
        if (warning)
        {
            warning = false;
            LeanTween.cancel(warningSign.gameObject);
            LeanTween.scale(warningSign.gameObject, Vector3.zero, 0.5f);
        }
    }



    private void buttonReady()
    {
        waitButtonBool = false;
    }

}
