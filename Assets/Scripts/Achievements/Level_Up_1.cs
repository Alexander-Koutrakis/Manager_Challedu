using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Up_1 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΕΞΕΛΙΞΗ 1", "Ανέβα στο επίπεδο 2", 1, 9);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {

        if (Player.Instance.Player_Level >= 2)
        {
            AchievementManager.Instance.EarnAchievement("ΕΞΕΛΙΞΗ 1");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
        Player.Instance.Expirience += 1;
        gameObject.AddComponent<Level_Up_4>();
        GetComponent<Level_Up_4>().CreateAchievement();
        AchievementManager.Instance.achievement_Mains.Remove(this);
        Player.Instance.Calculate_UI_Info();
    }
}
