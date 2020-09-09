using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDG_Focus_Sept_2 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΔΕΣΜΗ ΣΤΟΧΩΝ 2", "Συνέβαλε σε 7 SDG κατά 30 μονάδες", 3, 0);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {
        int i = 0;
        foreach (float x in Player.Instance.SDGs)
        {
            if (x >= 30)
            {
                i++;
            }
        }

        if (i >= 7)
        {
            AchievementManager.Instance.EarnAchievement("ΔΕΣΜΗ ΣΤΟΧΩΝ 2");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
        gameObject.AddComponent<SDG_Focus_Sept_3>();
        GetComponent<SDG_Focus_Sept_3>().CreateAchievement();
        AchievementManager.Instance.achievement_Mains.Remove(this);
        Player.Instance.Expirience += 3;
        Player.Instance.Calculate_UI_Info();
    }
}
