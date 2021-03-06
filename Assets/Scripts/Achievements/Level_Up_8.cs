﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Up_8 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΕΞΕΛΙΞΗ 3", "Ανέβα στο επίπεδο 8", 7, 9);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {

        if (Player.Instance.Player_Level >= 8)
        {
            AchievementManager.Instance.EarnAchievement("ΕΞΕΛΙΞΗ 3");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
     //   Player.Instance.Expirience += 7;
        gameObject.AddComponent<Level_Up_16>();
        GetComponent<Level_Up_16>().CreateAchievement();
        AchievementManager.Instance.achievement_Mains.Remove(this);
        Player.Instance.Calculate_UI_Info();
    }
}
