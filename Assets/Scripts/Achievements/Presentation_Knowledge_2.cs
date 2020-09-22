using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Presentation_Knowledge_2 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΓΝΩΣΗ ΕΚΕ 2", "Ολοκλήρωσε επιτυχώς 3 παρουσιάσεις ΕΚΕ", 3, 3);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {

        if (Player.Instance.successfulPresentation >= 3)
        {
            AchievementManager.Instance.EarnAchievement("ΓΝΩΣΗ ΕΚΕ 2");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
        gameObject.AddComponent<Presentation_Knowledge_3>();
        GetComponent<Presentation_Knowledge_3>().CreateAchievement();
        AchievementManager.Instance.achievement_Mains.Remove(this);
       // Player.Instance.Expirience += 3;
        Player.Instance.Calculate_UI_Info();
    }
}