using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Innovation_Achievement_1 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΚΑΙΝΟΤΟΜΙΑ 1", "Συγκέντρωσε 20 μονάδες υποστήριξης καινοτομία προτάσεων", 300, 0);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {

        if (Player.Instance.GPs[4] >= 20)
        {
            AchievementManager.Instance.EarnAchievement("ΚΑΙΝΟΤΟΜΙΑ 1");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
        gameObject.AddComponent<Innovation_Achievement_2>();
        GetComponent<Innovation_Achievement_2>().CreateAchievement();
        Player.Instance.Expirience += 300;
        Player.Instance.Calculate_UI_Info();
    }
}
