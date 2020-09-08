using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDG_Focus_Full_3 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΟΛΙΣΤΙΚΗ ΣΤΟΧΕΥΣΗ 3", "Συνέβαλε σε ολα τα SDG κατά 70 μονάδες", 3000, 0);
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

        if (i >= 16)
        {
            AchievementManager.Instance.EarnAchievement("ΟΛΙΣΤΙΚΗ ΣΤΟΧΕΥΣΗ 3");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
        gameObject.AddComponent<SDG_Focus_Full_4>();
        GetComponent<SDG_Focus_Full_4>().CreateAchievement();
        AchievementManager.Instance.achievement_Mains.Remove(this);
        Player.Instance.Expirience += 3000;
        Player.Instance.Calculate_UI_Info();
    }
}
