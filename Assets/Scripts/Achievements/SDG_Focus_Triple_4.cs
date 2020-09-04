using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDG_Focus_Triple_4 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΣΤΟΧΟΘΕΣΙΑ 4", "Συνέβαλε σε 3 SDG κατά 150 μονάδες", 3000, 0);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {
        int i = 0;
        foreach (float x in Player.Instance.SDGs)
        {
            if (x >= 150)
            {
                i++;
            }
        }

        if (i >= 3)
        {
            AchievementManager.Instance.EarnAchievement("ΣΤΟΧΟΘΕΣΙΑ 4");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
        AchievementManager.Instance.achievement_Mains.Remove(this);
        Player.Instance.Expirience += 3000;
        Player.Instance.Calculate_UI_Info();
    }
}
