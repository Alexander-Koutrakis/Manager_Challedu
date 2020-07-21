using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class Offer_Tab_Controller : MonoBehaviour
{
    public List<Offer> PreferedOffers = new List<Offer>();
    private List<Offer_Manager> offer_Managers = new List<Offer_Manager>();
    public List<Offer_Manager> used_Managers = new List<Offer_Manager>();
    public static Offer_Tab_Controller Instance;
    public RectTransform groupTab;
    public Panel_Control panel_Control;
    int currentTabIndex = 19;
    public Vector3 LeftPos;
    public Vector3 CentralPos;
    public Vector3 RightPos;
    public Offer_Manager shown_Offer_Manager;
    private bool waitButtonBool;
    public bool warning = false;
    [SerializeField]
    private RectTransform warningSign;
    [SerializeField]
    private GameObject file_Up_Image;
    public bool noAvailableOffers;
    [SerializeField]
    private Image noOffersImage;
    private void Awake()
    {
        Instance = this;
        foreach (Offer_Manager offer_Manager in GetComponentsInChildren<Offer_Manager>())
        {
            offer_Managers.Add(offer_Manager);
        }

    }





    public void FillOfferManagers()
    {
        noAvailableOffers = false;
        LeanTween.alpha(noOffersImage.GetComponent<RectTransform>(), 0, 0.1f);
        noOffersImage.raycastTarget = false;
        PreferedOffers.Shuffle();
        for (int i = 0; i < PreferedOffers.Count; i++)
        {
            offer_Managers[i].offer = PreferedOffers[i];
            used_Managers.Add(offer_Managers[i]);
        }


        foreach (Offer_Manager offer_Manager in offer_Managers)
        {
            offer_Manager.SetOfferValues();
        }

        ShowWarning();
    }

    public void NextOfferTab() {
        if (!waitButtonBool)
        {
            LeanTween.moveLocalX(used_Managers[currentTabIndex].gameObject, LeftPos.x, 0.5f);

            if (!noAvailableOffers)
            {
                do
                {
                    currentTabIndex++;
                    if (currentTabIndex >= used_Managers.Count)
                    {
                        currentTabIndex = 0;
                    }

                } while (used_Managers[currentTabIndex].offerClosed);


                shown_Offer_Manager = used_Managers[currentTabIndex];
                used_Managers[currentTabIndex].gameObject.transform.localPosition = RightPos;
                used_Managers[currentTabIndex].gameObject.SetActive(true);
                LeanTween.moveLocalX(used_Managers[currentTabIndex].gameObject, CentralPos.x, 0.5f).setOnComplete(DisableAllOffers).setOnComplete(buttonReady);
                shown_Offer_Manager.OpenOfferTab();
                waitButtonBool = true;
            }
            else
            {
                NoOffersAvailable();
            }
        }
    }


    public void PrevOfferTab()
    {
        if (!waitButtonBool)
        {
            LeanTween.moveLocalX(used_Managers[currentTabIndex].gameObject, RightPos.x, 0.5f);

            if (!noAvailableOffers)
            {
                do
                {
                    currentTabIndex--;
                    if (currentTabIndex < 0)
                    {
                        currentTabIndex = used_Managers.Count - 1;
                    }

                } while (used_Managers[currentTabIndex].offerClosed);


                shown_Offer_Manager = used_Managers[currentTabIndex];
                used_Managers[currentTabIndex].gameObject.transform.localPosition = LeftPos;
                used_Managers[currentTabIndex].gameObject.SetActive(true);
                shown_Offer_Manager.OpenOfferTab();
                LeanTween.moveLocalX(used_Managers[currentTabIndex].gameObject, CentralPos.x, 0.5f).setOnComplete(DisableAllOffers).setOnComplete(buttonReady);
                waitButtonBool = true;
            }
            else
            {
                NoOffersAvailable();
            }
        }
    }


    private void DisableAllOffers()
    {
        foreach (Offer_Manager offer_Manager in used_Managers)
        {
            if (shown_Offer_Manager != offer_Manager)
                offer_Manager.gameObject.SetActive(false);
        }
        // shown_Offer_Manager.gameObject.SetActive(true);
    }


    public void ShowWarning()
    {
        if (!warning)
        {
            warning = true;
            LeanTween.scale(warningSign.gameObject, new Vector3(1.0f, 1.0f, 1.0f), 0.5f).setOnComplete(WarningFollowUp);
        }
    }


    private void WarningFollowUp() {
        LeanTween.scale(warningSign.gameObject, new Vector3(2.0f, 2.0f, 2.0f), 0.5f).setLoopPingPong();
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


    public void FileUP_Animation()
    {
        file_Up_Image.SetActive(true);
        file_Up_Image.GetComponent<Animator>().SetTrigger("File_Up");
    }

    public void checkForOtherOffers()
    {
        foreach (Offer_Manager OM in offer_Managers)
        {
            if (!OM.offerClosed)
            {
                noAvailableOffers = false;
            }
            else
            {
                noAvailableOffers = true;
            }
        }
    }

    public void NoOffersAvailable() {
        noOffersImage.raycastTarget = true;
        LeanTween.alpha(noOffersImage.rectTransform, 1, 0.5f);   
    }

}

   
