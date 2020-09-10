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
    [SerializeField]
    private TMP_Text income_text;
    public float Next_Level_Exp=0;
    public float expRate=100;
    public int budgetRegenerationRate = 100;
    public int incomeRate;
    public int successfulPresentation = 0;
    public int successfulSDGTrainings = 0;
    public int netWorks = 0;
    IEnumerator expBarRoutine;
    [SerializeField]
    List<Trainning_Info> trainnings = new List<Trainning_Info>();
    [SerializeField]
    float trainningTheshold_1=0;
    [SerializeField]
    float trainningTheshold_2=0;
    [SerializeField]
    float trainningTheshold_3=0;
    [SerializeField]
    float trainningTheshold_4=0;
    [SerializeField]
    float trainningTheshold_5=0;
    [SerializeField]
    float trainningTheshold_6=0;
    [SerializeField]
    private Level_Up_Panel level_Up_Panel = null;
    private Sprite[,] StrategySprites = new Sprite[6, 4];
    [SerializeField]
    private Sprite[] initialStrategySprites = null;
    private int maxBudget=4000;
    public Sprite[] ActiveStrategySprites=new Sprite[6];
   private bool lvlUp = false;
    private void Awake()
    {
        Instance = this;
    }

   
    private void Start()
    {
        RestartTrainnings();
       
        InvokeRepeating("BudgetRate", 1, 1f);
       
        foreach (Trainning_Info TI in trainnings)
        {
            TI.current_Level = 0;
            TI.max_Level = 0;
        }
        Calculate_UI_Info();
    }
    public void Calculate_UI_Info()
    {
        budget_Text.text = budget.ToString();
        income_text.text = budgetRegenerationRate.ToString()+" / δ";
        bool lvlUp = false;
        if(Expirience >= Expirience_Slider.maxValue&& !lvlUp)
        {
            //claimLevel_Button.interactable = true;
            level_Up_Panel.LevelUP_Start();
            lvlUp = true;
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
        lvlUp = false;
        

        Expirience -= Expirience_Slider.maxValue;
        Player_Level++;
        level_Text.text = Player_Level.ToString();

        NewLevelInfo();   
        Campain_Plan.Instance.NewCampaing();
        LogBookControl.Instance.panel_Control.ClosePanel();
        Offer_Tab_Controller.Instance.panel_Control.ClosePanel();
        AchievementManager.Instance.panel_Control.ClosePanel();
        Campain_Plan.Instance.panel_Control.OpenPanel();
        Expirience_Slider.value = Expirience;
        claimLevel_Button.interactable = false;
        Calculate_UI_Info();
        AchievementManager.Instance.CheckAchievements();
    }

    private void BudgetRate()
    {

        if (budget < maxBudget)
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
            Expirience_Slider.value = Mathf.Lerp(Expirience_Slider.value, value, Time.deltaTime);
            yield return null;
        }
    }


    private void CheckTrainnings()
    {
        for(int i = 0; i < trainnings.Count; i++)
        {
            if (SDGs[i] >= trainningTheshold_6 && trainnings[i].level_Limit>=6&& trainnings[i].max_Level < 6)
            {        
                
                    trainnings[i].max_Level = 6;
                    Warning_Panel.Instance.ShowMessege("Νέο trainning");
                    Training_Canvas_Control.Instance.ShowWarning();                             
            }else if(SDGs[i] >= trainningTheshold_5 && trainnings[i].level_Limit >= 5 && trainnings[i].max_Level < 5)
            {
                    trainnings[i].max_Level = 5;
                    Warning_Panel.Instance.ShowMessege("Νέο trainning");
                    Training_Canvas_Control.Instance.ShowWarning();
            }
            else if (SDGs[i] >= trainningTheshold_4 && trainnings[i].level_Limit >= 4 && trainnings[i].max_Level < 4)
            {
                    trainnings[i].max_Level = 4;
                    Warning_Panel.Instance.ShowMessege("Νέο trainning");
                    Training_Canvas_Control.Instance.ShowWarning();
            }
            else if (SDGs[i] >= trainningTheshold_3 && trainnings[i].level_Limit >= 3 && trainnings[i].max_Level < 3)
            {
                    trainnings[i].max_Level = 3;
                    Warning_Panel.Instance.ShowMessege("Νέο trainning");
                    Training_Canvas_Control.Instance.ShowWarning();

            }
            else if (SDGs[i] >= trainningTheshold_2 && trainnings[i].max_Level < 2)
            {
                    trainnings[i].max_Level = 2;
                    Warning_Panel.Instance.ShowMessege("Νέο trainning");
                    Training_Canvas_Control.Instance.ShowWarning();
            }
            else if (SDGs[i] >= trainningTheshold_1 && trainnings[i].max_Level < 1)
            {
                    trainnings[i].max_Level = 1;
                    Warning_Panel.Instance.ShowMessege("Νέο trainning");
                    Training_Canvas_Control.Instance.ShowWarning();
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

   public void FillStrategyImages()
    {
        int counter = 0;
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                StrategySprites[i, j] = initialStrategySprites[counter];
                counter++;
            }

        }
        counter = 0;

        for(int i = 0; i < 6; i++)
        {
            ActiveStrategySprites[i] = StrategySprites[i, GameMaster.Instance.CampaignStars[i]];
        }

    }


private void NewLevelInfo()
    {
        if (Player_Level == 2)
        {
            GameMaster.Instance.MaxOffers = 4;
            GameMaster.Instance.FalseOffers = 2;
            budgetRegenerationRate = 150;
            maxBudget = 10000;
            Next_Level_Exp = 60;
            Expirience_Slider.maxValue =Next_Level_Exp;
            budget = 4000;

            MeetingRoomController.Instance.AddDnDQuestion();
            Debug.Log("going to level 2");
        }
        else if (Player_Level == 3)
        {
            GameMaster.Instance.MaxOffers = 8;
            GameMaster.Instance.FalseOffers = 4;
            budgetRegenerationRate = 170;
            maxBudget = 20000;
            Next_Level_Exp = 120;
            Expirience_Slider.maxValue = Next_Level_Exp;
            budget = 10000;

            for(int i = 0; i < 3; i++)
            {
                MeetingRoomController.Instance.AddDnDQuestion();
            }
            Debug.Log("going to level 3");
        }
        else if (Player_Level == 4)
        {
            GameMaster.Instance.MaxOffers = 12;
            GameMaster.Instance.FalseOffers = 6;
            budgetRegenerationRate = 210;
            maxBudget = 20000;
            Next_Level_Exp = 240;
            Expirience_Slider.maxValue = Next_Level_Exp;
            budget = 40000;

            for (int i = 0; i < 5; i++)
            {
                MeetingRoomController.Instance.AddDnDQuestion();
            }
            Debug.Log("going to level 4");
        }
        else if (Player_Level == 5)
        {
            GameMaster.Instance.MaxOffers = 15;
            GameMaster.Instance.FalseOffers = 5;
            budgetRegenerationRate = 310;
            maxBudget = 100000;
            Next_Level_Exp = 500;
            Expirience_Slider.maxValue = Next_Level_Exp;
            budget = 20000;

            for (int i = 0; i < 6; i++)
            {
                MeetingRoomController.Instance.AddDnDQuestion();
            }

            Debug.Log("going to level 4");
        }
        else if (Player_Level > 5)
        {
            GameMaster.Instance.MaxOffers = 15;
            GameMaster.Instance.FalseOffers = 5;
           // budgetRegenerationRate = 310;
            maxBudget = 1000000;
            Next_Level_Exp = 60;
            Expirience_Slider.maxValue = Next_Level_Exp;
            //  budget = 4000;

            for (int i = 0; i < 6; i++)
            {
                MeetingRoomController.Instance.AddDnDQuestion();
            }
        }
    }

}
