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
    public float[] SDGs;
    [SerializeField]
    private TMP_Text budget_Text;
    //[SerializeField]
    //private TMP_Text people_Text;
    //[SerializeField]
    //private TMP_Text product_Text;
    [SerializeField]
    private Slider Expirience_Slider;
    private float Next_Level_Exp=500;
    private void Awake()
    {
        Instance = this;
    }


    private void Start()
    {
        Calculate_UI_Info();
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
        }
    }


    public void Level_Up()
    {
        Campain_Plan.Instance.NewCampaing();
        Expirience_Slider.maxValue = Player_Level * Next_Level_Exp;       
        Expirience_Slider.value = Expirience - Player_Level * Next_Level_Exp;

    }
}
