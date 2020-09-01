using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetOffers1 : Achievement_Main
{
    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "Close 10 offers", "Get 100 expirience points", 10, 0);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {
        if (Player.Instance.offersAccepted >= 10)
        {
            AchievementManager.Instance.EarnAchievement("Close 10 offers");
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
