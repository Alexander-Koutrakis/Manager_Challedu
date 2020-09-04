using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDG_Focus_Sept_4 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΔΕΣΜΗ ΣΤΟΧΩΝ 4", "Συνέβαλε σε 7 SDG κατά 150 μονάδες", 3000, 0);
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

        if (i >= 7)
        {
            AchievementManager.Instance.EarnAchievement("ΔΕΣΜΗ ΣΤΟΧΩΝ 4");
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
