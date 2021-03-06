﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Innovation_Achievement_4 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΚΑΙΝΟΤΟΜΙΑ 4", "Συγκέντρωσε 300 μονάδες υποστήριξης καινοτομία προτάσεων", 15, 12);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {

        if (Player.Instance.GPs[4] >= 300)
        {
            AchievementManager.Instance.EarnAchievement("ΚΑΙΝΟΤΟΜΙΑ 4");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
        AchievementManager.Instance.achievement_Mains.Remove(this);
     //   Player.Instance.Expirience += 15;
        Player.Instance.Calculate_UI_Info();
    }
}
