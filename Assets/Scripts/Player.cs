﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Security.Claims;

public class Player : MonoBehaviour
{
    public static Player Instance;
    public int budget;
    public int Player_Level=4;
    public float Expirience;
    public float[] SDGs=new float[17];
    [SerializeField]
    private TMP_Text budget_Text=null;
    [SerializeField]
    private Slider Expirience_Slider=null;
    [SerializeField]
    private Button claimLevel_Button=null;
    [SerializeField]
    private TMP_Text level_Text;
    public float Next_Level_Exp=0;
    public float expRate=100;
    public int budgetRegenerationRate = 20;
    IEnumerator expBarRoutine;
    private void Awake()
    {
        Instance = this;
    }

   
    private void Start()
    {
        Calculate_UI_Info();
        InvokeRepeating("BudgetRate", 1, 1f);
    }
    public void Calculate_UI_Info()
    {
        budget_Text.text = budget.ToString();

       
        if(Expirience >= Expirience_Slider.maxValue)
        {
            // level up button true
            //
            claimLevel_Button.interactable = true;
        }
        if (expBarRoutine != null){
            StopCoroutine(expBarRoutine);
        }
       
        expBarRoutine = changeSlider(Expirience);
        
        StartCoroutine(expBarRoutine);
        if(Training_Canvas_Control.Instance!=null)
        Training_Canvas_Control.Instance.CheckForTrainning();
    }


    public void Level_Up()
    {
        Campain_Plan.Instance.NewCampaing();

        Expirience -= Expirience_Slider.maxValue;
        Player_Level++;
        level_Text.text = Player_Level.ToString();

        expRate += expRate * Player_Level * 0.1f;
        Next_Level_Exp = Player_Level * expRate;
        Expirience_Slider.maxValue =Next_Level_Exp;       
               
        LogBookControl.Instance.panel_Control.ClosePanel();
        Offer_Tab_Controller.Instance.panel_Control.ClosePanel();
        AchievementManager.Instance.panel_Control.ClosePanel();
        Campain_Plan.Instance.panel_Control.OpenPanel();
        AchievementManager.Instance.CheckAchievements();
        Expirience_Slider.value = Expirience;
        claimLevel_Button.interactable = false;
    }

    private void BudgetRate()
    {
        if (budget < Player_Level * 3000)
        {
            budget += budgetRegenerationRate;
            budget_Text.text = budget.ToString();
            if (Offer_Tab_Controller.Instance.shown_Offer_Manager != null)
            {
                if (!Offer_Tab_Controller.Instance.shown_Offer_Manager.offerClosed)
                {
                    Offer_Tab_Controller.Instance.shown_Offer_Manager.GetButtons();
                }
            }
        }
    }


    public void GetSDG(float[] addedSDGs)
    {
        for(int i = 0; i < 17; i++)
        {
            SDGs[i] += addedSDGs[i];
        }

        SDG_Stats.instance.GetSDGStats();

    }



    private IEnumerator changeSlider(float value)
    {
        if(value> Expirience_Slider.maxValue)
        {
            value = Expirience_Slider.maxValue;
        }
        while (Mathf.Abs(Expirience_Slider.value - value) > 0.1f)
        {
            Expirience_Slider.value = Mathf.Lerp(Expirience_Slider.value, value, Time.deltaTime * 10);
            yield return null;

        }
    }
}
