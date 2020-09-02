using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impact_Achievement_4 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΑΝΤΙΚΤΥΠΟ 4", "Συγκέντρωσε 300 μονάδες υποστήριξης αντίκτυπου προτάσεων", 300, 0);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {

        if (Player.Instance.GPs[2] >= 300)
        {
            AchievementManager.Instance.EarnAchievement("ΑΝΤΙΚΤΥΠΟ 4");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
        gameObject.AddComponent<Impact_Achievement_4>();
        GetComponent<Impact_Achievement_4>().CreateAchievement();
        Player.Instance.Expirience += 3000;
        Player.Instance.Calculate_UI_Info();
    }
}
