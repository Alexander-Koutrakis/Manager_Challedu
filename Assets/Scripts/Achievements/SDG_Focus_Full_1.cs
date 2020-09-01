using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDG_Focus_Full_1 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΟΛΙΣΤΙΚΗ ΣΤΟΧΕΥΣΗ 1", "Συνέβαλε σε ολα τα SDG κατά 10 μονάδες", 10, 0);
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

        if (i >= 16)
        {
            AchievementManager.Instance.EarnAchievement("ΟΛΙΣΤΙΚΗ ΣΤΟΧΕΥΣΗ 1");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
        gameObject.AddComponent<SDG_Focus_Full_2>();
        GetComponent<SDG_Focus_Full_2>().CreateAchievement();
        Player.Instance.Expirience += 1000;
        Player.Instance.Calculate_UI_Info();
    }
}
