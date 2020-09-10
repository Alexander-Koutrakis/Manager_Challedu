using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Publicity_Achievement_1 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΔΗΜΟΣΙΟΤΗΤΑ 1", "Συγκέντρωσε 20 μονάδες υποστήριξης δημοσιότητας προτάσεων", 1, 5);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {

        if (Player.Instance.GPs[0] >= 20)
        {
            AchievementManager.Instance.EarnAchievement("ΔΗΜΟΣΙΟΤΗΤΑ 1");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
        gameObject.AddComponent<Publicity_achievement_2>();
        GetComponent<Publicity_achievement_2>().CreateAchievement();
        AchievementManager.Instance.achievement_Mains.Remove(this);
        Player.Instance.Expirience += 1;
        Player.Instance.Calculate_UI_Info();
    }
}
