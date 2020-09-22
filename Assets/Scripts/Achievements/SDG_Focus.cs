using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDG_Focus : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΣΤΟΧΟΠΡΟΣΗΛΩΣΗ 1", "Συνέβαλε σε  1 SDG κατά 10 μονάδες", 1, 15);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {
        foreach (float x in Player.Instance.SDGs)
        {
            if (x >= 10)
            {
                AchievementManager.Instance.EarnAchievement("ΣΤΟΧΟΠΡΟΣΗΛΩΣΗ 1");
                activated = true;
                Rewards();
            }
        }
    }

    public override void Rewards()
    {
        gameObject.AddComponent<SDG_Focus_2>();
        GetComponent<SDG_Focus_2>().CreateAchievement();
        gameObject.AddComponent<SDG_Focus_Triple_1>();
        GetComponent<SDG_Focus_Triple_1>().CreateAchievement();
        AchievementManager.Instance.achievement_Mains.Remove(this);
     //   Player.Instance.Expirience += 1;
        Player.Instance.Calculate_UI_Info();
    }
}
