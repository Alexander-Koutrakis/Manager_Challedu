using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Security.Claims;
using System.Configuration;

public class Player : MonoBehaviour
{
    public static Player Instance;
    public int budget;
    public int Player_Level=4;  
    public float Expirience;
    public float[] SDGs=new float[17];
    public float[] GPs = new float[6];
    public float totalbudgetPaid = 0;
    public int offersAccepted = 0;
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
    [SerializeField]
    List<Trainning_Info> trainnings = new List<Trainning_Info>();
    [SerializeField]
    float trainningTheshold_1;
    [SerializeField]
    float trainningTheshold_2;
    [SerializeField]
    float trainningTheshold_3;
    private void Awake()
    {
        Instance = this;
    }

   
    private void Start()
    {
        RestartTrainnings();
        Calculate_UI_Info();
        InvokeRepeating("BudgetRate", 1, 1f);
    }
    public void Calculate_UI_Info()
    {
        budget_Text.text = budget.ToString(); 
        if(Expirience >= Expirience_Slider.maxValue)
        {
            claimLevel_Button.interactable = true;
        }
        if (expBarRoutine != null){
            StopCoroutine(expBarRoutine);
        }       
        expBarRoutine = changeSlider(Expirience);        
        StartCoroutine(expBarRoutine);
        CheckTrainnings();
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
        MeetingRoomController.Instance.AddDnDQuestion();
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

    public void GetGPs(float[] gps)
    {
        for(int i = 0; i < 6; i++)
        {
            GPs[i] += gps[i];
        }
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


    private void CheckTrainnings()
    {
        for(int i = 0; i < trainnings.Count; i++)
        {
            if (SDGs[i] >= trainningTheshold_3)
            {
                if (trainnings[i].max_Level != 3)
                {
                    trainnings[i].max_Level = 3;
                    Warning_Panel.Instance.ShowMessege("Νέο trainning");
                    Training_Canvas_Control.Instance.ShowWarning();
                    break;
                }
            }else if(SDGs[i] >= trainningTheshold_2)
            {
                if (trainnings[i].max_Level != 2)
                {
                    trainnings[i].max_Level = 2;
                    Warning_Panel.Instance.ShowMessege("Νέο trainning");
                    Training_Canvas_Control.Instance.ShowWarning();
                    break;
                }
            }
            else if (SDGs[i] >= trainningTheshold_1)
            {
                if (trainnings[i].max_Level != 1)
                {
                    trainnings[i].max_Level = 1;
                    Warning_Panel.Instance.ShowMessege("Νέο trainning");
                    Training_Canvas_Control.Instance.ShowWarning();
                    break;
                }

            }
            else
            {
                trainnings[i].max_Level = 0;
            }
        
              
        }
    }

    private void RestartTrainnings()
    {
        foreach(Trainning_Info trainning in trainnings)
        {
            trainning.current_Level = 0;
            trainning.max_Level = 0;
        }
    }
}
