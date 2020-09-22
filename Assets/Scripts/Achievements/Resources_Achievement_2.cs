using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources_Achievement_2 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΕΞΑΣΦΑΛΙΣΗ ΠΟΡΩΝ 2", "Ανέβασε τον ρυθμό ροής χρηματοδότησης σε 300 ευρώ/δευτερόλεπτο", 3, 8);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {

        if (Player.Instance.incomeRate >= 300)
        {
            AchievementManager.Instance.EarnAchievement("ΕΞΑΣΦΑΛΙΣΗ ΠΟΡΩΝ 2");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
        gameObject.AddComponent<Resources_Achievement_3>();
        GetComponent<Resources_Achievement_3>().CreateAchievement();
        AchievementManager.Instance.achievement_Mains.Remove(this);
      //  Player.Instance.Expirience += 3;
        Player.Instance.Calculate_UI_Info();
    }
}

