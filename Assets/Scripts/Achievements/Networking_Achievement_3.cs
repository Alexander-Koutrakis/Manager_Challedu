using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Networking_Achievement_3 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΔΙΚΤΥΩΣΗ 3", "Παρακολούθησε 7 παρουσιάσεις οργανισμών", 10, 0);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {

        if (Player.Instance.netWorks >= 7)
        {
            AchievementManager.Instance.EarnAchievement("ΔΙΚΤΥΩΣΗ 3");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
        gameObject.AddComponent<Networking_Achievement_4>();
        GetComponent<Networking_Achievement_4>().CreateAchievement();
        Player.Instance.Expirience += 1200;
        Player.Instance.Calculate_UI_Info();
    }
}
