using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDG_Focus_Full_2 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΟΛΙΣΤΙΚΗ ΣΤΟΧΕΥΣΗ 2", "Συνέβαλε σε ολα τα SDG κατά 30 μονάδες", 3, 13);
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

        if (i >= 16)
        {
            AchievementManager.Instance.EarnAchievement("ΟΛΙΣΤΙΚΗ ΣΤΟΧΕΥΣΗ 2");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
        gameObject.AddComponent<SDG_Focus_Full_3>();
        GetComponent<SDG_Focus_Full_3>().CreateAchievement();
        AchievementManager.Instance.achievement_Mains.Remove(this);
        Player.Instance.Expirience += 3;
        Player.Instance.Calculate_UI_Info();
    }
}
