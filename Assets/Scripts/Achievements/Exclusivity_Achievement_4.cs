using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exclusivity_Achievement_4 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΑΠΟΚΛΕΙΣΤΗΚΟΤΗΤΑ 4", "Συγκέντρωσε 300 μονάδες υποστήριξης αποκλειστηκότητας προτάσεων", 10, 0);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {

        if (Player.Instance.GPs[5] >= 300)
        {
            AchievementManager.Instance.EarnAchievement("ΑΠΟΚΛΕΙΣΤΗΚΟΤΗΤΑ 4");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {        
        Player.Instance.Expirience += 3000;
        Player.Instance.Calculate_UI_Info();
    }
}
