using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{   
    public delegate void nextRound();
    public static nextRound NextRound;

    public PieGraph pieGraph_Small;
    public static GameMaster gameMaster;

    public Panel_Control[] panel_controls;

    public GameObject testingPanel;
    public Active_Offer_Panel[] activeOfferPanels;
    public List<Active_Offer> active_Offer_List = new List<Active_Offer>();



    public List<Offer> offer_list_gm;
    public List<Offer_Manager> offer_manager_gm;
    public int[] activeOffersIDs;
    public int[,] offerManagerIDs=new int[5,4];

    private void Awake()
    {


        if (gameMaster == null)
        {
            gameMaster = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        DontDestroyOnLoad(gameMaster);

    }



    public void NextRoundButton()
    {
        StopAllCoroutines();
        LeanTween.cancelAll();
        if (NextRound != null)
        {
            NextRound();
            Player_Controller.player_Controller.RenewResources();
        }
        Debug.Log("nextRound");
    }

    public void Avtivate_Offers()
    {
        for(int i=0;i< active_Offer_List.Count; i++)
        {
            foreach (Active_Offer_Panel AOP in activeOfferPanels)
            {
                if (!AOP.ActivePanel)
                {
                    Active_Offer active_Offer = AOP.gameObject.AddComponent<Active_Offer>();
                    active_Offer.offer = active_Offer_List[i].offer;
                    active_Offer.SDGscore = active_Offer_List[i].SDGscore;
                    active_Offer.ReputationScore = active_Offer_List[i].ReputationScore;
                    active_Offer.Duration = active_Offer_List[i].Duration;
                    active_Offer.StartTimer();
                    break;
                }
            }
        }

        foreach(Active_Offer AO in GetComponents<Active_Offer>())
        {
            Destroy(AO);           
        }
        active_Offer_List.Clear();
    }

    public void SaveGame() {
        Debug.Log("Save game");
        Offer_Tab_Controller.Instance.SaveOfferData();
        SaveSystem.SaveGame();
    }

    public void LoadGame() {
        Debug.Log("Load Game");
       GameData gamedata= SaveSystem.LoadGame();
        if (gamedata != null)
        {
            activeOffersIDs = gamedata.ActiveOffersIDs;
            for(int i=0;i< gamedata.OfferManagerIDs.Length; i++)
            {
                offerManagerIDs[i, 0] = gamedata.OfferManagerIDs[i];
                offerManagerIDs[i, 1] = gamedata.OfferManagerIDsBudget[i];
                offerManagerIDs[i, 2] = gamedata.OfferManagerIDsPeople[i];
                offerManagerIDs[i, 3] = gamedata.OfferManagerIDsProduct[i];
            }

            Player_Controller.player_Controller.budget = gamedata.PlayerBudget;
            Player_Controller.player_Controller.people = gamedata.PlayerPeople;
            Player_Controller.player_Controller.products = gamedata.PlayerProduct;
            Player_Controller.player_Controller.Reputation = gamedata.PlayerReputation;
            Offer_Tab_Controller.Instance.LoadData(activeOffersIDs, offerManagerIDs);            
        }
        UI_Controller.ui_Controller.RefreshResourcesText();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) {
            SaveGame();

        }
        
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadGame();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            SaveSystem.DeleteSave();
            Debug.Log("Delete game");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            testingPanel.SetActive(true);
        }

    }

}
