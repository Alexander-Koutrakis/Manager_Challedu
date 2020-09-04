using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Level_Up : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "Get to Level 2","Increase Budget income +20", 10, 0);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {
        
        if (Player.Instance.Player_Level >= 2)
        {
            AchievementManager.Instance.EarnAchievement("Get to Level 2");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
        Player.Instance.incomeRate += 20;
        Player.Instance.Calculate_UI_Info();
    }
}
