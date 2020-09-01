using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Publicity_Achievement_4 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΔΗΜΟΣΙΟΤΗΤΑ 3", "Συγκέντρωσε 300 μονάδες υποστήριξης δημοσιότητας προτάσεων", 10, 0);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {

        if (Player.Instance.GPs[0] >= 300)
        {
            AchievementManager.Instance.EarnAchievement("ΔΗΜΟΣΙΟΤΗΤΑ 3");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {        
        Player.Instance.Expirience += 1200;
        Player.Instance.Calculate_UI_Info();
    }
}
