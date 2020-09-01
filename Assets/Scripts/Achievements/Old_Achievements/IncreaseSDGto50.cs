using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseSDGto50 : Achievement_Main
{
    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "Increase an SDGs to 50", "Get 2000 expirience points", 10, 0);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {
        bool achieved = false;
        foreach (float sdgScore in Player.Instance.SDGs)
        {
            if (sdgScore >= 50)
            {
                achieved = true;

            }
        }
        if (achieved )
        {
            AchievementManager.Instance.EarnAchievement("Increase an SDGs to 50");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
        Player.Instance.Expirience += 2000;
        Player.Instance.Calculate_UI_Info();
    }
}
