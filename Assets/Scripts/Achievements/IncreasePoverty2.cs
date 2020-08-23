using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreasePoverty2 : Achievement_Main
{
    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "Increase SDG against poverty to 25", "Get 500 expirience points", 10, 0);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {
        if (Player.Instance.SDGs[0] >= 25)
        {
            AchievementManager.Instance.EarnAchievement("Increase SDG against poverty to 25");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
        Player.Instance.Expirience += 500;
        Player.Instance.Calculate_UI_Info();
    }
}
