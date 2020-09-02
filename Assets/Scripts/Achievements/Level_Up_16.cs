using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Up_16 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΕΞΕΛΙΞΗ 4", "Ανέβα στο επίπεδο 16", 1000, 0);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {

        if (Player.Instance.Player_Level >= 16)
        {
            AchievementManager.Instance.EarnAchievement("ΕΞΕΛΙΞΗ 4");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
        Player.Instance.Expirience += 1000;      
        Player.Instance.Calculate_UI_Info();
    }
}
