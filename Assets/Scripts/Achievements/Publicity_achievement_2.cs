using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Publicity_achievement_2 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΔΗΜΟΣΙΟΤΗΤΑ 2", "Συγκέντρωσε 60 μονάδες υποστήριξης δημοσιότητας προτάσεων", 10, 0);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {

        if (Player.Instance.GPs[0] >= 60)
        {
            AchievementManager.Instance.EarnAchievement("ΔΗΜΟΣΙΟΤΗΤΑ 2");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
        gameObject.AddComponent<Publicity_Achievement_3>();
        GetComponent<Publicity_Achievement_3>().CreateAchievement();
        Player.Instance.Expirience += 600;
        Player.Instance.Calculate_UI_Info();
    }
}
