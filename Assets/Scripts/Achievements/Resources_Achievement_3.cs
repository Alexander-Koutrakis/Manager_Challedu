using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources_Achievement_3 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΕΞΑΣΦΑΛΙΣΗ ΠΟΡΩΝ 3", "Ανέβασε τον ρυθμό ροής χρηματοδότησης σε 700 ευρώ/δευτερόλεπτο", 10, 0);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {

        if (Player.Instance.budgetRegenerationRate >= 700)
        {
            AchievementManager.Instance.EarnAchievement("ΕΞΑΣΦΑΛΙΣΗ ΠΟΡΩΝ 3");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
        gameObject.AddComponent<Resources_Achievement_4>();
        GetComponent<Resources_Achievement_4>().CreateAchievement();
        Player.Instance.Expirience += 1200;
        Player.Instance.Calculate_UI_Info();
    }
}
