using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDG_Training_4 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΓΝΩΣΗ SDG 4", "Ολοκλήρωσε επιτυχώς 45 εκπαιδεύσεις SDG", 15, 0);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {

        if (Player.Instance.successfulSDGTrainings >= 45)
        {
            AchievementManager.Instance.EarnAchievement("ΓΝΩΣΗ SDG 4");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
        AchievementManager.Instance.achievement_Mains.Remove(this);
        Player.Instance.Expirience += 15;
        Player.Instance.Calculate_UI_Info();
    }
}
