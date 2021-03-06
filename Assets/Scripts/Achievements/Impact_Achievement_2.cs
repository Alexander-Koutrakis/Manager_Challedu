﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impact_Achievement_2 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΑΝΤΙΚΤΥΠΟ 2", "Συγκέντρωσε 60 μονάδες υποστήριξης αντίκτυπου προτάσεων", 3, 0);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {

        if (Player.Instance.GPs[2] >= 60)
        {
            AchievementManager.Instance.EarnAchievement("ΑΝΤΙΚΤΥΠΟ 2");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
        gameObject.AddComponent<Impact_Achievement_3>();
        GetComponent<Impact_Achievement_3>().CreateAchievement();
        AchievementManager.Instance.achievement_Mains.Remove(this);
      //  Player.Instance.Expirience += 3;
        Player.Instance.Calculate_UI_Info();
    }
}
