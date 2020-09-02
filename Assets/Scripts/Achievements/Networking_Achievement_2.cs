using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Networking_Achievement_2 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΔΙΚΤΥΩΣΗ 2", "Παρακολούθησε 3 παρουσιάσεις οργανισμών", 600, 0);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {

        if (Player.Instance.netWorks >= 3)
        {
            AchievementManager.Instance.EarnAchievement("ΔΙΚΤΥΩΣΗ 2");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
        gameObject.AddComponent<Networking_Achievement_3>();
        GetComponent<Networking_Achievement_3>().CreateAchievement();
        Player.Instance.Expirience += 600;
        Player.Instance.Calculate_UI_Info();
    }
}
