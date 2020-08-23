using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseQualityEducation3 : Achievement_Main
{
    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "Increase SDG Quality Education to 75", "Get 5000 expirience points", 10, 0);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {
        if (Player.Instance.SDGs[3] >= 75)
        {
            AchievementManager.Instance.EarnAchievement("Increase SDG Quality Education to 75");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
        Player.Instance.Expirience += 5000;
        Player.Instance.Calculate_UI_Info();
    }
}
