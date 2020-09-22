using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Innovation_Achievement_2 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΚΑΙΝΟΤΟΜΙΑ 2", "Συγκέντρωσε 60 μονάδες υποστήριξης καινοτομία προτάσεων", 3, 12);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {

        if (Player.Instance.GPs[4] >= 60)
        {
            AchievementManager.Instance.EarnAchievement("ΚΑΙΝΟΤΟΜΙΑ 2");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
        gameObject.AddComponent<Innovation_Achievement_3>();
        GetComponent<Innovation_Achievement_3>().CreateAchievement();
        AchievementManager.Instance.achievement_Mains.Remove(this);
    //    Player.Instance.Expirience += 3;
        Player.Instance.Calculate_UI_Info();
    }
}
