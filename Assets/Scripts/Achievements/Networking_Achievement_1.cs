using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Networking_Achievement_1 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΔΙΚΤΥΩΣΗ 1", "Παρακολούθησε 1 παρουσιάση οργανισμών", 1, 0);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {

        if (Player.Instance.netWorks >= 1)
        {
            AchievementManager.Instance.EarnAchievement("ΔΙΚΤΥΩΣΗ 1");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
        gameObject.AddComponent<Networking_Achievement_2>();
        GetComponent<Networking_Achievement_2>().CreateAchievement();
        AchievementManager.Instance.achievement_Mains.Remove(this);
        Player.Instance.Expirience += 1;
        Player.Instance.Calculate_UI_Info();
    }
}
