using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources_Achievement_4 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΕΞΑΣΦΑΛΙΣΗ ΠΟΡΩΝ 4", "Ανέβασε τον ρυθμό ροής χρηματοδότησης σε 1500 ευρώ/δευτερόλεπτο", 10, 0);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {

        if (Player.Instance.budgetRegenerationRate >= 1500)
        {
            AchievementManager.Instance.EarnAchievement("ΕΞΑΣΦΑΛΙΣΗ ΠΟΡΩΝ 4");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
       
        Player.Instance.Expirience +=3000;
        Player.Instance.Calculate_UI_Info();
    }
}
