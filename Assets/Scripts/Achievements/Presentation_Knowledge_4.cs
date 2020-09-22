using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Presentation_Knowledge_4 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΓΝΩΣΗ ΕΚΕ 4", "Ολοκλήρωσε επιτυχώς 15 παρουσιάσεις ΕΚΕ", 15, 3);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {

        if (Player.Instance.successfulPresentation >= 15)
        {
            AchievementManager.Instance.EarnAchievement("ΓΝΩΣΗ ΕΚΕ 4");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
        AchievementManager.Instance.achievement_Mains.Remove(this);
      //  Player.Instance.Expirience += 15;
        Player.Instance.Calculate_UI_Info();
    }
}
