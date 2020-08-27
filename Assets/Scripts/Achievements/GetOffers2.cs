using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetOffers2 : Achievement_Main
{
    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "Close 15 offers", "Get 1000 expirience points", 10, 0);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {
        if (Player.Instance.offersAccepted >= 15)
        {
            AchievementManager.Instance.EarnAchievement("Close 15 offers");
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
