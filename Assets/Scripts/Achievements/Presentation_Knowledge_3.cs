using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Presentation_Knowledge_3 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΓΝΩΣΗ ΕΚΕ 3", "Ολοκλήρωσε επιτυχώς 7 παρουσιάσεις ΕΚΕ", 7, 3);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {

        if (Player.Instance.successfulPresentation >= 7)
        {
            AchievementManager.Instance.EarnAchievement("ΓΝΩΣΗ ΕΚΕ 3");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
        gameObject.AddComponent<Presentation_Knowledge_4>();
        GetComponent<Presentation_Knowledge_4>().CreateAchievement();
        AchievementManager.Instance.achievement_Mains.Remove(this);
        Player.Instance.Expirience += 7;
        Player.Instance.Calculate_UI_Info();
    }
}
