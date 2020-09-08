using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseGP_Publicity1 : Achievement_Main
{
    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "Increase Publicity to 10", "Get 100 expirience points", 10, 0);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {
        if (Player.Instance.GPs[0] >= 10)
        {
            AchievementManager.Instance.EarnAchievement("Increase Publicity to 10");
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
