using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expirience_Achievement_3 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΕΜΠΕΙΡΙΑ 3", "Συγκέντρωσε 140 μονάδες υποστήριξης εμπειρίας προτάσεων", 7, 7);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {

        if (Player.Instance.GPs[1] >= 140)
        {
            AchievementManager.Instance.EarnAchievement("ΕΜΠΕΙΡΙΑ 3");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
        gameObject.AddComponent<Expirience_Achievement_4>();
        GetComponent<Expirience_Achievement_4>().CreateAchievement();
        AchievementManager.Instance.achievement_Mains.Remove(this);
     //   Player.Instance.Expirience += 7;
        Player.Instance.Calculate_UI_Info();
    }
}
