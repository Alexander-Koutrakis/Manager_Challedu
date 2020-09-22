using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDG_Focus_Triple_2 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΣΤΟΧΟΘΕΣΙΑ 2", "Συνέβαλε σε 3 SDG κατά 30 μονάδες", 3, 14);
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

        if (i >= 3)
        {
            AchievementManager.Instance.EarnAchievement("ΣΤΟΧΟΘΕΣΙΑ 2");
            activated = true;
            Rewards();
        }
    }

    public override void Rewards()
    {
        gameObject.AddComponent<SDG_Focus_Triple_3>();
        GetComponent<SDG_Focus_Triple_3>().CreateAchievement();
        AchievementManager.Instance.achievement_Mains.Remove(this);
      //  Player.Instance.Expirience += 3;
        Player.Instance.Calculate_UI_Info();
    }
}
