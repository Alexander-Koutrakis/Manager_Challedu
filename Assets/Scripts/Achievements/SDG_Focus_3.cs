﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDG_Focus_3 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΣΤΟΧΟΠΡΟΣΗΛΩΣΗ 3", "Συνέβαλε σε  1 SDG κατά 70 μονάδες", 7, 15);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {
        foreach (float x in Player.Instance.SDGs)
        {
            if (x >= 70)
            {
                AchievementManager.Instance.EarnAchievement("ΣΤΟΧΟΠΡΟΣΗΛΩΣΗ 3");
                activated = true;
                Rewards();
            }
        }
    }

    public override void Rewards()
    {
        gameObject.AddComponent<SDG_Focus_4>();
        GetComponent<SDG_Focus_4>().CreateAchievement();
        AchievementManager.Instance.achievement_Mains.Remove(this);
     //   Player.Instance.Expirience += 7;
        Player.Instance.Calculate_UI_Info();
    }
}
