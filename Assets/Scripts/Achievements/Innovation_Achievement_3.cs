using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Innovation_Achievement_3 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΚΑΙΝΟΤΟΜΙΑ 3", "Συγκέντρωσε 140 μονάδες υποστήριξης καινοτομία προτάσεων", 10, 0);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {

        if (Player.Instance.GPs[4] >= 140)
        {
            AchievementManager.Instance.EarnAchievement("ΚΑΙΝΟΤΟΜΙΑ 3");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
        gameObject.AddComponent<Innovation_Achievement_4>();
        GetComponent<Innovation_Achievement_4>().CreateAchievement();
        Player.Instance.Expirience += 1200;
        Player.Instance.Calculate_UI_Info();
    }
}
