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
    public int stars = 3;

    public Button StartCampaingButton;
    public Button HideButton;
    public Sprite ReadyToStartSprite;
    public Sprite WaitingForStarsSprite;
    public Panel_Control panel_Control;
    [SerializeField]
    private RectTransform CampainrectTransform=null;
    [SerializeField]
    private RectTransform StatsrectTransform=null;
    [SerializeField]
    private Button toStatsBTN=null;
    [SerializeField]
    private Button toCampainBTN=null;

    private void Start()
    {
        Instance = this;
        campaing_Strategies = GetComponentsInChildren<Campaing_Strategy>();
        panel_Control = GameObject.Find("Stats_Panel_Button").GetComponent<Panel_Control>();
        RemainingStars();
        HideButton.interactable = false;
    }
    public void ChangePlayerCampaing()
    {
        for(int i = 0; i < campaingStars.Length; i++)
        {
            GameMaster.Instance.CampaignStars[i] = campaingStars[i];
            PieGraph.Instance.AddStrategySprites();
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
            StartCampaingButton.interactable = true;           
        }
        else if(stars>0)
        {
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
        HideButton.interactable=true;
        toStatsBTN.interactable = true;
    }

    public void UnlockCampaing()
    {
        foreach (Button button in GetComponentsInChildren<Button>())
        {
            button.interactable = true;
        }
        StartCampaingButton.interactable = true;
        HideButton.interactable = false;
    }

    public void NewCampaing()
    {
       
        panel_Control.OpenPanel();
        UnlockCampaing();
    }

    public void ToStats()
    {
        LeanTween.moveLocalX(StatsrectTransform.gameObject,0, 0.5f);
        LeanTween.moveLocalX(CampainrectTransform.gameObject, -1920, 0.5f);
        toStatsBTN.interactable = false;
        toCampainBTN.interactable=true;
    }

    public void ToCampain()
    {
        LeanTween.moveLocalX(CampainrectTransform.gameObject, 0, 0.5f);
        LeanTween.moveLocalX(StatsrectTransform.gameObject, 1920, 0.5f);
        toStatsBTN.interactable=true;
        toCampainBTN.interactable=false;
    }
}
