using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Support_Achievement_3 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΥΠΟΣΤΗΡΙΞΗ 3", "Χρηματοδότησε 21 Προτάσεις", 7, 16);
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
        AchievementManager.Instance.achievement_Mains.Remove(this);
      //  Player.Instance.Expirience += 7;
        Player.Instance.Calculate_UI_Info();
    }
}
