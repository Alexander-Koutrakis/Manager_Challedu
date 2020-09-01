using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Support_Achievement_3 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΥΠΟΣΤΗΡΙΞΗ 3", "Χρηματοδότησε 21 Προτάσεις", 10, 0);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {

        if (Player.Instance.offersAccepted >= 21)
        {
            AchievementManager.Instance.EarnAchievement("ΥΠΟΣΤΗΡΙΞΗ 3");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
        gameObject.AddComponent<Support_Achievement_4>();
        GetComponent<Support_Achievement_4>().CreateAchievement();
        Player.Instance.Expirience += 1200;
        Player.Instance.Calculate_UI_Info();
    }
}
