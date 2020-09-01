using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Support_Achievement_2 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΥΠΟΣΤΗΡΙΞΗ 2", "Χρηματοδότησε 9 Προτάσεις", 10, 0);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {

        if (Player.Instance.offersAccepted >= 9)
        {
            AchievementManager.Instance.EarnAchievement("ΥΠΟΣΤΗΡΙΞΗ 2");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
        gameObject.AddComponent<Support_Achievement_3>();
        GetComponent<Support_Achievement_3>().CreateAchievement();
        Player.Instance.Expirience += 600;
        Player.Instance.Calculate_UI_Info();
    }
}
