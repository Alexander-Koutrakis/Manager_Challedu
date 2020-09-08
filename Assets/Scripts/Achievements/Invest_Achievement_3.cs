using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invest_Achievement_3 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΕΠΕΝΔΥΣΗ 3", "Διέθεσε 21.000 χρήματα σε χρηματοδότηση προτάσεων", 600, 0);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {

        if (Player.Instance.totalbudgetPaid >= 21000)
        {
            AchievementManager.Instance.EarnAchievement("ΕΠΕΝΔΥΣΗ 3");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
        gameObject.AddComponent<Invest_Achievement_4>();
        GetComponent<Invest_Achievement_4>().CreateAchievement();
        AchievementManager.Instance.achievement_Mains.Remove(this);
        Player.Instance.Expirience += 600;
        Player.Instance.Calculate_UI_Info();
    }
}
