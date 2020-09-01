using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseInnovation1 : Achievement_Main
{
    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "Increase Innovation to 10", "Get 100 expirience points", 10, 0);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {
        if (Player.Instance.GPs[4] >= 10)
        {
            AchievementManager.Instance.EarnAchievement("Increase Innovation to 10");
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
