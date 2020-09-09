using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Up_4 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΕΞΕΛΙΞΗ 2", "Ανέβα στο επίπεδο 4", 15, 0);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {

        if (Player.Instance.Player_Level >= 8)
        {
            AchievementManager.Instance.EarnAchievement("ΕΞΕΛΙΞΗ 2");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
        Player.Instance.Expirience += 15;
        gameObject.AddComponent<Level_Up_8>();
        AchievementManager.Instance.achievement_Mains.Remove(this);
        GetComponent<Level_Up_8>().CreateAchievement();
        Player.Instance.Calculate_UI_Info();
    }
}
