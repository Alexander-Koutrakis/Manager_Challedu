using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources_Achievement_1 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΕΞΑΣΦΑΛΙΣΗ ΠΟΡΩΝ 1", "Ανέβασε τον ρυθμό ροής χρηματοδότησης σε 100 ευρώ/δευτερόλεπτο", 50, 0);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {

        if (Player.Instance.incomeRate >= 100)
        {
            AchievementManager.Instance.EarnAchievement("ΕΞΑΣΦΑΛΙΣΗ ΠΟΡΩΝ 1");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
        gameObject.AddComponent<Resources_Achievement_2>();
        GetComponent<Resources_Achievement_2>().CreateAchievement();
        AchievementManager.Instance.achievement_Mains.Remove(this);
        Player.Instance.Expirience += 50;
        Player.Instance.Calculate_UI_Info();
    }
}
