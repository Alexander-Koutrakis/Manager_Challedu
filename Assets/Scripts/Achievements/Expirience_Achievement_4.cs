﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expirience_Achievement_4 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΕΜΠΕΙΡΙΑ 4", "Συγκέντρωσε 300 μονάδες υποστήριξης εμπειρίας προτάσεων", 10, 0);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {

        if (Player.Instance.GPs[1] >= 300)
        {
            AchievementManager.Instance.EarnAchievement("ΕΜΠΕΙΡΙΑ 4");
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
