using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseGP_Specialization1 : Achievement_Main
{
    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "Increase Specialization to 10", "Get 100 expirience points", 10, 0);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {
        if (Player.Instance.GPs[3] >= 10)
        {
            AchievementManager.Instance.EarnAchievement("Increase Specialization to 10");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
        Player.Instance.Expirience += 100;
        Player.Instance.Calculate_UI_Info();
    }
}

