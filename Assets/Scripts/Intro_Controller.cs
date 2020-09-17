using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Intro_Controller : MonoBehaviour
{

    [SerializeField]
    private GameObject nextImage;
    [SerializeField]
    private GameObject currentImage;
    [SerializeField]
    private Panel_Control campaing_Panel_control;

    [SerializeField]
    private GameObject secondNextImage;
    [SerializeField]
    private GameObject secondCurrentImage;
    [SerializeField]
    private Panel_Control offer_Panel_Control;

    [SerializeField]
    private GameObject final_Images;

    public void IntroStartCampaing()
    {
      if(NewCampaing_Panel.Instance.StartCampaingButton.interactable)
        {
            currentImage.SetActive(false);
            nextImage.SetActive(true);
            campaing_Panel_control.ClosePanel();
            NewCampaing_Panel.Instance.StartCampaing();
        }
    }

    public void OfferPayButton()
    {
        if (Offer_Tab_Controller.Instance.shown_Offer_Manager.PayButton.interactable)
        {
            secondCurrentImage.SetActive(false);
            secondNextImage.SetActive(true);
            Offer_Tab_Controller.Instance.shown_Offer_Manager.CloseOffer();
        }


    }

    public void DestroyIntro()
    {
        Destroy(gameObject);
    }


    private void Update()
    {
        if (Player.Instance.Player_Level > 1)
        {
            final_Images.SetActive(true);
        }
    }
}
