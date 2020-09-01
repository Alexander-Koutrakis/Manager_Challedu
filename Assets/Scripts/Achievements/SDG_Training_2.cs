using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDG_Training_2 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΓΝΩΣΗ SDG 2", "Ολοκλήρωσε επιτυχώς 9 εκπαιδεύσεις SDG", 10, 0);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {

        if (Player.Instance.successfulSDGTrainings >= 9)
        {
            AchievementManager.Instance.EarnAchievement("ΓΝΩΣΗ SDG 2");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
        gameObject.AddComponent<SDG_Training_3>();
        GetComponent<SDG_Training_3>().CreateAchievement();
        Player.Instance.Expirience += 600;
        Player.Instance.Calculate_UI_Info();
    }
}
