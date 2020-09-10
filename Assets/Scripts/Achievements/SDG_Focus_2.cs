using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SDG_Focus_2 : Achievement_Main
{

    public override void CreateAchievement()
    {
        AchievementManager.Instance.CreateAchievement("General", "ΣΤΟΧΟΠΡΟΣΗΛΩΣΗ 2", "Συνέβαλε σε  1 SDG κατά 30 μονάδες", 3, 15);
        AchievementManager.Instance.achievement_Mains.Add(this);
    }

    public override void Requirements()
    {
        foreach (float x in Player.Instance.SDGs)
        {
            if (x >= 30)
            {
                AchievementManager.Instance.EarnAchievement("ΣΤΟΧΟΠΡΟΣΗΛΩΣΗ 2");
                activated = true;
                Rewards();
            }
        }
    }

    public override void Rewards()
    {
        gameObject.AddComponent<SDG_Focus_3>();
        GetComponent<SDG_Focus_3>().CreateAchievement();
        AchievementManager.Instance.achievement_Mains.Remove(this);
        Player.Instance.Expirience += 3;
        Player.Instance.Calculate_UI_Info();
    }
}
