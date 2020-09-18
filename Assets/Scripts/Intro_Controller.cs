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
    private GameObject HideOldExit;
    [SerializeField]
    private GameObject showExit;

    [SerializeField]
    private GameObject waringGameobject;
    
    [SerializeField]
    private GameObject final_Images;

    private bool first = false;
    private bool second = false;

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
        Time.timeScale = 1;
        waringGameobject.SetActive(true);
        Destroy(gameObject);
    }


    private void Update()
    {

        if (Player.Instance.offersAccepted > 0 && !first)
        {
            first = true;
            HideOldExit.SetActive(false);
            showExit.SetActive(true);
            // do stuff
        }
        
        
        if (Player.Instance.Player_Level > 1&& !second)
        {
            second = true;
            StartCoroutine(waitForLevelUpEnd());
        }


    }

    private IEnumerator waitForLevelUpEnd()
    {
        yield return new WaitForSeconds(0.4f);
        Time.timeScale = 0;
        final_Images.SetActive(true);
    }
}
