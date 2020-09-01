using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Specialization_Achievement_2 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΕΞΕΙΔΙΚΕΥΣΗ 2", "Συγκέντρωσε 60 μονάδες υποστήριξης εξειδίκευσης προτάσεων", 10, 0);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {

        if (Player.Instance.GPs[3] >= 60)
        {
            AchievementManager.Instance.EarnAchievement("ΕΞΕΙΔΙΚΕΥΣΗ 2");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
        gameObject.AddComponent<Specialization_Achievement_3>();
        GetComponent<Specialization_Achievement_3>().CreateAchievement();
        Player.Instance.Expirience += 600;
        Player.Instance.Calculate_UI_Info();
    }
}
