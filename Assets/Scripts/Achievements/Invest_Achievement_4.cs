using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invest_Achievement_4 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΕΠΕΝΔΥΣΗ 4", "Διέθεσε 45.000 χρήματα σε χρηματοδότηση προτάσεων", 15, 0);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {

        if (Player.Instance.totalbudgetPaid >= 45000)
        {
            AchievementManager.Instance.EarnAchievement("ΕΠΕΝΔΥΣΗ 4");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
        AchievementManager.Instance.achievement_Mains.Remove(this);
        Player.Instance.Expirience += 15;
        Player.Instance.Calculate_UI_Info();
    }
}
