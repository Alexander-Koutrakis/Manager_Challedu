using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseSDGto20 : Achievement_Main
{
    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "Increase an SDG to 20", "Get 1000 expirience points", 10, 0);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {
        bool achieved=false;
        foreach(float sdgScore in Player.Instance.SDGs)
        {
            if (sdgScore >= 20)
            {
                achieved = true;
            }
        }
        if (achieved)
        {
            AchievementManager.Instance.EarnAchievement("Increase an SDG to 20");
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
