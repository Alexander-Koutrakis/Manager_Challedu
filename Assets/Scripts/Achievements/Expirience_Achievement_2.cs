using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expirience_Achievement_2 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΕΜΠΕΙΡΙΑ 2", "Συγκέντρωσε 60 μονάδες υποστήριξης εμπειρίας προτάσεων", 10, 0);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {

        if (Player.Instance.GPs[1] >= 60)
        {
            AchievementManager.Instance.EarnAchievement("ΕΜΠΕΙΡΙΑ 2");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
        gameObject.AddComponent<Expirience_Achievement_3>();
        GetComponent<Expirience_Achievement_3>().CreateAchievement();
        Player.Instance.Expirience += 600;
        Player.Instance.Calculate_UI_Info();
    }
}
