using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Player : MonoBehaviour
{
    public static Player Instance;
    public int budget;
    //public int people;
    //public int products;
    public int Player_Level=1;
    public float Expirience;
    public float[] SDGs=new float[17];
    [SerializeField]
    private TMP_Text budget_Text;
    [SerializeField]
    private Slider Expirience_Slider;
    [SerializeField]
    private Button claimLevel_Button;
    private float Next_Level_Exp=500;
    public int budgetRegenerationRate = 20;
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
        Expirience_Slider.maxValue = Player_Level * Next_Level_Exp;
       
        if (Player_Level > 1)
        {
            Expirience_Slider.value = Expirience - Player_Level * Next_Level_Exp;
        }
        else
        {
            Expirience_Slider.value = Expirience;
        }
        if(Expirience_Slider.value>= Player_Level * Next_Level_Exp)
        {
            // level up button true
            //
            claimLevel_Button.interactable = true;
        }
    }


    public void Level_Up()
    {
        Campain_Plan.Instance.NewCampaing();

        Expirience -= Expirience_Slider.maxValue;
        Expirience_Slider.maxValue = Player_Level * Next_Level_Exp;       
        Expirience_Slider.value = Expirience;
        LogBookControl.Instance.panel_Control.ClosePanel();
        Offer_Tab_Controller.Instance.panel_Control.ClosePanel();
        AchievementManager.Instance.panel_Control.ClosePanel();
        Campain_Plan.Instance.panel_Control.OpenPanel();
    }

    private void BudgetRate()
    {
        if (budget < Player_Level * 3000)
        {
            budget += budgetRegenerationRate;
            budget_Text.text = budget.ToString();

           if(!Offer_Tab_Controller.Instance.shown_Offer_Manager.offerClosed)
            {
                Offer_Tab_Controller.Instance.shown_Offer_Manager.GetButtons();
            }
        }
    }


    public void GetSDG(float[] addedSDGs)
    {
        for(int i = 0; i < 17; i++)
        {
            Debug.Log(i);
            SDGs[i] += addedSDGs[i];
        }

        SDG_Stats.instance.GetSDGStats();

    }

}
