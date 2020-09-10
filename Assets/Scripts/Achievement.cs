using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Achievement
{
    private string title;
    public string Title { get => title; set => title = value; }

    private string description;
    public string Description { get => description; set => description = value; }

    private int points;
    public int Points { get => points; set => points = value; }

    private bool unlocked;
    public bool Unlocked { get => unlocked; set => unlocked = value; }

    private int spriteIndex;
    public int SpriteIndex { get => spriteIndex; set => spriteIndex = value; }
    

    private string child;
    public string Child { get => child; set => child = value; }

    public GameObject achievementRef;
    private List<Achievement> dependencies = new List<Achievement>();
    public Achievement(string title , string description , int points , int spriteIndex, GameObject achievementRef)
    {
        this.title = title;
        this.description = description;
        this.points = points;
        this.unlocked = false;
        this.spriteIndex = spriteIndex;
        this.achievementRef = achievementRef;
        LoadAchievement();
    }

    public void AddDependencies(Achievement achievement)
    {
        dependencies.Add(achievement);
    }
   

    public bool EarnAchievement()
    {
        if (!unlocked && !dependencies.Exists(x=>x.unlocked==false))
        {
            achievementRef.GetComponent<Image>().sprite = AchievementManager.Instance.unlockedSprite;
           
            foreach(TMP_Text text in this.achievementRef.GetComponentsInChildren<TMP_Text>())
            {
                text.color = new Color32(255,255,255,255);
                text.gameObject.transform.localScale = new Vector3(1, 1, 1);
            }

          this.achievementRef.GetComponentsInChildren<TMP_Text>()[2].color = new Color32(221, 82, 70, 255);
          this.achievementRef.GetComponentsInChildren<Image>()[1].color = new Color32(255, 255, 255, 255);
          this.achievementRef.GetComponentsInChildren<Image>()[2].sprite= AchievementManager.Instance.Star_Points_sprite;

            SaveAchievement(true);

            if (child != null)
            {
                AchievementManager.Instance.EarnAchievement(child);
            }
            return true;
        }
       
        return false;
    }

    public void SaveAchievement(bool value)
    {
        unlocked = value;
        int tmpPoints = PlayerPrefs.GetInt("Points");
        PlayerPrefs.SetInt("Points", tmpPoints += points);
        PlayerPrefs.SetInt(title, value ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void LoadAchievement()
    {
        unlocked = PlayerPrefs.GetInt(title) == 1 ? true : false;
        
        if (unlocked)
        {
            achievementRef.GetComponent<Image>().sprite = AchievementManager.Instance.unlockedSprite;
            AchievementManager.Instance.pointText.text = "Points : " + PlayerPrefs.GetInt("Points");
        }
    }
}
