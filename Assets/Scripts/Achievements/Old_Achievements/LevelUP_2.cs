using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUP_2 : Achievement_Main
{
    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "Get to Level 3", "Increase Budget income +60", 10, 0);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {
        if (Player.Instance.Player_Level >= 3)
        {
            AchievementManager.Instance.EarnAchievement("Get to Level 3");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
        Player.Instance.budgetRegenerationRate += 60;
        Player.Instance.Calculate_UI_Info();
    }
}
