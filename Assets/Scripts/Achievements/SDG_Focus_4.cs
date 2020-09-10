using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDG_Focus_4 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΣΤΟΧΟΠΡΟΣΗΛΩΣΗ 4", "Συνέβαλε σε  1 SDG κατά 150 μονάδες", 15, 15);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {
        foreach (float x in Player.Instance.SDGs)
        {
            if (x >= 150)
            {
                AchievementManager.Instance.EarnAchievement("ΣΤΟΧΟΠΡΟΣΗΛΩΣΗ 4");
                activated = true;
                Rewards();
            }
        }
    }

    public override void Rewards()
    {
        AchievementManager.Instance.achievement_Mains.Remove(this);
        Player.Instance.Expirience += 15;       
        Player.Instance.Calculate_UI_Info();
    }
}
