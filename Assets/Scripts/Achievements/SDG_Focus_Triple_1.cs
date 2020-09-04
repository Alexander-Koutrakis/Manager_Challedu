using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDG_Focus_Triple_1 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΣΤΟΧΟΘΕΣΙΑ 1", "Συνέβαλε σε 3 SDG κατά 10 μονάδες", 50, 0);
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

        if (i >= 3)
        {
            AchievementManager.Instance.EarnAchievement("ΣΤΟΧΟΘΕΣΙΑ 1");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
        gameObject.AddComponent<SDG_Focus_Triple_2>();
        GetComponent<SDG_Focus_Triple_2>().CreateAchievement();
        gameObject.AddComponent<SDG_Focus_Sept_1>();
        GetComponent<SDG_Focus_Sept_1>().CreateAchievement();
        AchievementManager.Instance.achievement_Mains.Remove(this);
        Player.Instance.Expirience += 50;
        Player.Instance.Calculate_UI_Info();
    }
}
