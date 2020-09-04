using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDG_Focus_Full_4 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΟΛΙΣΤΙΚΗ ΣΤΟΧΕΥΣΗ 4", "Συνέβαλε σε ολα τα SDG κατά 150 μονάδες", 30000, 0);
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

        if (i >= 16)
        {
            AchievementManager.Instance.EarnAchievement("ΟΛΙΣΤΙΚΗ ΣΤΟΧΕΥΣΗ 4");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
        AchievementManager.Instance.achievement_Mains.Remove(this);
        Player.Instance.Expirience += 30000;
        Player.Instance.Calculate_UI_Info();
    }
}
