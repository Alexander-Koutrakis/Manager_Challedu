using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDG_Training_3 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΓΝΩΣΗ SDG 3", "Ολοκλήρωσε επιτυχώς 21 εκπαιδεύσεις SDG", 10, 0);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {

        if (Player.Instance.successfulSDGTrainings >= 21)
        {
            AchievementManager.Instance.EarnAchievement("ΓΝΩΣΗ SDG 3");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
        gameObject.AddComponent<SDG_Training_4>();
        GetComponent<SDG_Training_4>().CreateAchievement();
        Player.Instance.Expirience += 1200;
        Player.Instance.Calculate_UI_Info();
    }
}
