using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDG_Focus_Sept_1 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΔΕΣΜΗ ΣΤΟΧΩΝ 1", "Συνέβαλε σε 7 SDG κατά 10 μονάδες", 1, 0);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {
        int i = 0;
        foreach (float x in Player.Instance.SDGs)
        {
            if (x >= 10)
            {
                i++;
            }
        }

        if (i >= 7)
        {
            AchievementManager.Instance.EarnAchievement("ΔΕΣΜΗ ΣΤΟΧΩΝ 1");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
        gameObject.AddComponent<SDG_Focus_Sept_2>();
        GetComponent<SDG_Focus_Sept_2>().CreateAchievement();
        gameObject.AddComponent<SDG_Focus_Full_1>();
        GetComponent<SDG_Focus_Full_1>().CreateAchievement();
        AchievementManager.Instance.achievement_Mains.Remove(this);
        Player.Instance.Expirience += 1;
        Player.Instance.Calculate_UI_Info();
    }
}
