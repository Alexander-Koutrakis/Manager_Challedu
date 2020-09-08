using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Publicity_Achievement_3 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΔΗΜΟΣΙΟΤΗΤΑ 3", "Συγκέντρωσε 140 μονάδες υποστήριξης δημοσιότητας προτάσεων", 600, 0);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {

        if (Player.Instance.GPs[0] >= 140)
        {
            AchievementManager.Instance.EarnAchievement("ΔΗΜΟΣΙΟΤΗΤΑ 3");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
        gameObject.AddComponent<Publicity_Achievement_4>();
        GetComponent<Publicity_Achievement_4>().CreateAchievement();
        AchievementManager.Instance.achievement_Mains.Remove(this);
        Player.Instance.Expirience += 600;
        Player.Instance.Calculate_UI_Info();
    }
}
