using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impact_Achievement_1 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΑΝΤΙΚΤΥΠΟ 1", "Συγκέντρωσε 20 μονάδες υποστήριξης αντίκτυπου προτάσεων", 1, 0);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {

        if (Player.Instance.GPs[2] >= 20)
        {
            AchievementManager.Instance.EarnAchievement("ΑΝΤΙΚΤΥΠΟ 1");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
        gameObject.AddComponent<Impact_Achievement_2>();
        GetComponent<Impact_Achievement_2>().CreateAchievement();
        AchievementManager.Instance.achievement_Mains.Remove(this);
      //  Player.Instance.Expirience += 1;
        Player.Instance.Calculate_UI_Info();
    }
}
