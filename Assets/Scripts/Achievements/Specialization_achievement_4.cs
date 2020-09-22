using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Specialization_achievement_4 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΕΞΕΙΔΙΚΕΥΣΗ 4", "Συγκέντρωσε 300 μονάδες υποστήριξης εξειδίκευσης προτάσεων", 15, 11);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {

        if (Player.Instance.GPs[3] >= 300)
        {
            AchievementManager.Instance.EarnAchievement("ΕΞΕΙΔΙΚΕΥΣΗ 4");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
        AchievementManager.Instance.achievement_Mains.Remove(this);
      //  Player.Instance.Expirience += 15;
        Player.Instance.Calculate_UI_Info();
    }
}
