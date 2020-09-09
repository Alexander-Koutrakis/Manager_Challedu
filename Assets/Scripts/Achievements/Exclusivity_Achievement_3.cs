using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exclusivity_Achievement_3 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΑΠΟΚΛΕΙΣΤΗΚΟΤΗΤΑ 3", "Συγκέντρωσε 140 μονάδες υποστήριξης αποκλειστηκότητας προτάσεων", 7, 0);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {

        if (Player.Instance.GPs[5] >= 140)
        {
            AchievementManager.Instance.EarnAchievement("ΑΠΟΚΛΕΙΣΤΗΚΟΤΗΤΑ 3");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
        gameObject.AddComponent<Exclusivity_Achievement_4>();
        GetComponent<Exclusivity_Achievement_4>().CreateAchievement();
        AchievementManager.Instance.achievement_Mains.Remove(this);
        Player.Instance.Expirience += 7;
        Player.Instance.Calculate_UI_Info();
    }
}
