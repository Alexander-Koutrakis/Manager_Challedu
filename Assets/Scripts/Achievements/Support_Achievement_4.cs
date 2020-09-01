﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Support_Achievement_4 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΥΠΟΣΤΗΡΙΞΗ 4", "Χρηματοδότησε 45 Προτάσεις", 10, 0);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {

        if (Player.Instance.offersAccepted >= 45)
        {
            AchievementManager.Instance.EarnAchievement("ΥΠΟΣΤΗΡΙΞΗ 4");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
       
        Player.Instance.Expirience += 3000;
        Player.Instance.Calculate_UI_Info();
    }
}
