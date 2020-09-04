using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expirience_Achievement_1 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΕΜΠΕΙΡΙΑ 1", "Συγκέντρωσε 20 μονάδες υποστήριξης εμπειρίας προτάσεων", 50, 0);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {

        if (Player.Instance.GPs[1] >= 20)
        {
            AchievementManager.Instance.EarnAchievement("ΕΜΠΕΙΡΙΑ 1");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
        gameObject.AddComponent<Expirience_Achievement_2>();
        GetComponent<Expirience_Achievement_2>().CreateAchievement();
        AchievementManager.Instance.achievement_Mains.Remove(this);
        Player.Instance.Expirience += 50;
        Player.Instance.Calculate_UI_Info();
    }
}
