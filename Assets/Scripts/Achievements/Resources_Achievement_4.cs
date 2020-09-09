using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources_Achievement_4 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΕΞΑΣΦΑΛΙΣΗ ΠΟΡΩΝ 4", "Ανέβασε τον ρυθμό ροής χρηματοδότησης σε 1500 ευρώ/δευτερόλεπτο", 15, 0);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {

        if (Player.Instance.incomeRate >= 1500)
        {
            AchievementManager.Instance.EarnAchievement("ΕΞΑΣΦΑΛΙΣΗ ΠΟΡΩΝ 4");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
        AchievementManager.Instance.achievement_Mains.Remove(this);
        Player.Instance.Expirience +=15;
        Player.Instance.Calculate_UI_Info();
    }
}
