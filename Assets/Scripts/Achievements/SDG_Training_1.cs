using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDG_Training_1 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΓΝΩΣΗ SDG 1", "Ολοκλήρωσε επιτυχώς 3 εκπαιδεύσεις SDG", 1, 2);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {

        if (Player.Instance.successfulSDGTrainings >= 3)
        {
            AchievementManager.Instance.EarnAchievement("ΓΝΩΣΗ SDG 1");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
        gameObject.AddComponent<SDG_Training_2>();
        GetComponent<SDG_Training_2>().CreateAchievement();
        AchievementManager.Instance.achievement_Mains.Remove(this);
        Player.Instance.Expirience += 1;
        Player.Instance.Calculate_UI_Info();
    }
}
