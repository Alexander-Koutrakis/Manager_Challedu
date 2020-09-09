using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Networking_Achievement_4 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΔΙΚΤΥΩΣΗ 4", "Παρακολούθησε 15 παρουσιάσεις οργανισμών", 15, 0);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {

        if (Player.Instance.netWorks >= 15)
        {
            AchievementManager.Instance.EarnAchievement("ΔΙΚΤΥΩΣΗ 4");
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
