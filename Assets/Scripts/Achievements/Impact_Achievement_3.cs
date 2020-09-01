using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impact_Achievement_3 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΑΝΤΙΚΤΥΠΟ 3", "Συγκέντρωσε 140 μονάδες υποστήριξης αντίκτυπου προτάσεων", 10, 0);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {

        if (Player.Instance.GPs[2] >= 140)
        {
            AchievementManager.Instance.EarnAchievement("ΑΝΤΙΚΤΥΠΟ 3");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
        gameObject.AddComponent<Impact_Achievement_4>();
        GetComponent<Impact_Achievement_4>().CreateAchievement();
        Player.Instance.Expirience += 1200;
        Player.Instance.Calculate_UI_Info();
    }
}
