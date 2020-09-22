using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invest_Achievement_2 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΕΠΕΝΔΥΣΗ 2", "Διέθεσε 9000 χρήματα σε χρηματοδότηση προτάσεων", 3, 10);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {

        if (Player.Instance.totalbudgetPaid >= 9000)
        {
            AchievementManager.Instance.EarnAchievement("ΕΠΕΝΔΥΣΗ 2");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
        gameObject.AddComponent<Invest_Achievement_3>();
        GetComponent<Invest_Achievement_3>().CreateAchievement();
        AchievementManager.Instance.achievement_Mains.Remove(this);
     //   Player.Instance.Expirience += 3;
        Player.Instance.Calculate_UI_Info();
    }
}

