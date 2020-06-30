using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Campain_Plan : MonoBehaviour
{
    public static Campain_Plan Instance;
    private int[] campaingStars = new int[6];
    private Campaing_Strategy[] campaing_Strategies;
    public int stars = 5;
    private int maxStars = 5;
    public Button StartCampaingButton;
    public Button HideButton;
    public Sprite ReadyToStartSprite;
    public Sprite WaitingForStarsSprite;
    public Panel_Control panel_Control;
    private void Start()
    {
        Instance = this;
        campaing_Strategies = GetComponentsInChildren<Campaing_Strategy>();
        panel_Control = GameObject.Find("Stats_Panel_Button").GetComponent<Panel_Control>();
        RemainingStars();
    }
    public void ChangePlayerCampaing()
    {
        for(int i = 0; i < campaingStars.Length; i++)
        {
            GameMaster.Instance.CampaignStars[i] = campaingStars[i];
        }
    }

    public void GetStars(Campaing_Strategy campaing_Strategy)
    {
        int index = System.Array.IndexOf(campaing_Strategies, campaing_Strategy);
        campaingStars[index]= campaing_Strategy.stars;
       // GameMaster.Instance.CampaignStars[index] = campaing_Strategy.stars;
    }


    public void RemainingStars()
    {

        if (stars <= 0)
        {
            StartCampaingButton.GetComponent<Image>().sprite = ReadyToStartSprite;
            StartCampaingButton.interactable = true;
            StartCampaingButton.GetComponentInChildren<TMP_Text>().text = "Start Campaing";
        }
        else if(stars>0)
        {
            StartCampaingButton.GetComponent<Image>().sprite = WaitingForStarsSprite;
            StartCampaingButton.GetComponentInChildren<TMP_Text>().text = "Place All Stars";
            StartCampaingButton.interactable = false;
        }
    }

    public void StartCampaing()
    {
        if(stars > 0)
        {
            Debug.Log("Use All the Stars first");
            // force the player to use all the stars
        }
        else
        {
            
            ChangePlayerCampaing();
            GameMaster.Instance.StartCampaign();
            LockCampaing();
        }
    }

    public void LockCampaing()
    {
        foreach(Button button in GetComponentsInChildren<Button>())
        {
            button.interactable = false;
        }
        StartCampaingButton.interactable = false;
        HideButton.gameObject.SetActive(true);
    }

    public void UnlockCampaing()
    {
        foreach (Button button in GetComponentsInChildren<Button>())
        {
            button.interactable = true;
        }
        StartCampaingButton.interactable = true;
        HideButton.gameObject.SetActive(false);
        //stars = maxStars;
    }

    public void NewCampaing()
    {
       
        panel_Control.OpenPanel();
        UnlockCampaing();
    }
}
