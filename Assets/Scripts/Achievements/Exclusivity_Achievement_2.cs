using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exclusivity_Achievement_2 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΑΠΟΚΛΕΙΣΤΗΚΟΤΗΤΑ 2", "Συγκέντρωσε 60 μονάδες υποστήριξης αποκλειστηκότητας προτάσεων", 10, 0);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {

        if (Player.Instance.GPs[5] >= 60)
        {
            AchievementManager.Instance.EarnAchievement("ΑΠΟΚΛΕΙΣΤΗΚΟΤΗΤΑ 2");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
        gameObject.AddComponent<Exclusivity_Achievement_3>();
        GetComponent<Exclusivity_Achievement_3>().CreateAchievement();
        Player.Instance.Expirience += 600;
        Player.Instance.Calculate_UI_Info();
    }
}
