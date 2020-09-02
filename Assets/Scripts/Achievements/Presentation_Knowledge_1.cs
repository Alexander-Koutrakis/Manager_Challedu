﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Presentation_Knowledge_1 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΓΝΩΣΗ ΕΚΕ 1", "Ολοκλήρωσε επιτυχώς 1 παρουσίαση ΕΚΕ", 300, 0);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {

        if (Player.Instance.successfulPresentation >= 1)
        {
            AchievementManager.Instance.EarnAchievement("ΓΝΩΣΗ ΕΚΕ 1");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
        gameObject.AddComponent<Presentation_Knowledge_2>();
        GetComponent<Presentation_Knowledge_2>().CreateAchievement();
        Player.Instance.Expirience += 300;
        Player.Instance.Calculate_UI_Info();
    }
}
