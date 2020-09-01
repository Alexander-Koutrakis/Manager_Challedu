using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseBudgetPaid : Achievement_Main
{
    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "Spend 10.000 on offers", "Get 1000 expirience points", 10, 0);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {
        if (Player.Instance.totalbudgetPaid >= 10000)
        {
            AchievementManager.Instance.EarnAchievement("Spend 10.000 on offers");
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
