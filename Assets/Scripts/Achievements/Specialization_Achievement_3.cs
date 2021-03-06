﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Specialization_Achievement_3 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΕΞΕΙΔΙΚΕΥΣΗ 3", "Συγκέντρωσε 140 μονάδες υποστήριξης εξειδίκευσης προτάσεων", 7, 11);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {

        if (Player.Instance.GPs[3] >= 140)
        {
            AchievementManager.Instance.EarnAchievement("ΕΞΕΙΔΙΚΕΥΣΗ 3");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
        gameObject.AddComponent<Specialization_achievement_4>();
        GetComponent<Specialization_achievement_4>().CreateAchievement();
        AchievementManager.Instance.achievement_Mains.Remove(this);
      //  Player.Instance.Expirience += 7;
        Player.Instance.Calculate_UI_Info();
    }
}
