using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invest_Achievement_1 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΕΠΕΝΔΥΣΗ 1", "Διέθεσε 3000 χρήματα σε χρηματοδότηση προτάσεων", 1, 0);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {

        if (Player.Instance.totalbudgetPaid >= 3000)
        {
            AchievementManager.Instance.EarnAchievement("ΕΠΕΝΔΥΣΗ 1");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
        gameObject.AddComponent<Invest_Achievement_2>();
        GetComponent<Invest_Achievement_2>().CreateAchievement();
        AchievementManager.Instance.achievement_Mains.Remove(this);
        Player.Instance.Expirience += 1;
        Player.Instance.Calculate_UI_Info();
    }
}
