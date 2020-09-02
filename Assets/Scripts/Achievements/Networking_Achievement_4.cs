using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Networking_Achievement_4 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΔΙΚΤΥΩΣΗ 4", "Παρακολούθησε 15 παρουσιάσεις οργανισμών", 3000, 0);
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
        Player.Instance.Expirience += 3000;
        Player.Instance.Calculate_UI_Info();
    }
}
