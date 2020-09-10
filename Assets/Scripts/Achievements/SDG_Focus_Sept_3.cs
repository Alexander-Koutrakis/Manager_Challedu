using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDG_Focus_Sept_3 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΔΕΣΜΗ ΣΤΟΧΩΝ 3", "Συνέβαλε σε 7 SDG κατά 70 μονάδες", 7, 4);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {
        int i = 0;
        foreach (float x in Player.Instance.SDGs)
        {
            if (x >= 70)
            {
                i++;
            }
        }

        if (i >= 7)
        {
            AchievementManager.Instance.EarnAchievement("ΔΕΣΜΗ ΣΤΟΧΩΝ 3");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
        gameObject.AddComponent<SDG_Focus_Sept_4>();
        GetComponent<SDG_Focus_Sept_4>().CreateAchievement();
        AchievementManager.Instance.achievement_Mains.Remove(this);
        Player.Instance.Expirience += 7;
        Player.Instance.Calculate_UI_Info();
    }
}
