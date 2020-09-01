using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Increase2SDGto20 : Achievement_Main
{
    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "Increase two SDGs to 20", "Get 2000 expirience points", 10, 0);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {
        bool achieved = false;
        int count = 0;
        foreach (float sdgScore in Player.Instance.SDGs)
        {
            if (sdgScore >= 20)
            {
                achieved = true;
                count++;
            }
        }
        if (achieved&&count>=2)
        {
            AchievementManager.Instance.EarnAchievement("Increase two SDGs to 20");
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
