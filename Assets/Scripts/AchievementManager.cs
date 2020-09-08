using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour
{
    public GameObject achievement_Prefab;
    public Sprite[] achievementSprites;
    public Achievement_Button activeButton;
    private ScrollRect scrollRect;
    public GameObject visualAchievement;
    public Dictionary<string, Achievement> achievements = new Dictionary<string, Achievement>();
    public Sprite unlockedSprite;
    public TMP_Text pointText; 
    public static AchievementManager Instance;
    public Panel_Control panel_Control;
    public List<Achievement_Main> achievement_Mains = new List<Achievement_Main>();
    
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        PlayerPrefs.DeleteAll();//----------------------------delete saves---------------
        scrollRect = GetComponentInChildren<ScrollRect>();
        activeButton = GameObject.Find("GeneralCategory_Button").GetComponent<Achievement_Button>();       
        foreach (GameObject achievement in GameObject.FindGameObjectsWithTag("Achievement_List"))
        {
            achievement.SetActive(false);
        }
       
        activeButton.Click();

        Debug.Log("here");

        foreach (Achievement_Main AM in GetComponents<Achievement_Main>())
        {
            AM.CreateAchievement();
        }



    }
    public void CreateAchievement(string parent, string Title, string Description, int Points, int SpriteIndex, string[] dependencies = null)
    {
        GameObject achievement_Clone = Instantiate(achievement_Prefab);
        Achievement newAchievement = new Achievement(Title, Description, Points, SpriteIndex, achievement_Clone);
        achievements.Add(Title, newAchievement);
        SetAchievement_Info(parent, Title, achievement_Clone);

        if (dependencies != null)
        {
            foreach (string achievementTitle in dependencies)
            {
                Achievement dependency = achievements[achievementTitle];
                dependency.Child = Title;
                newAchievement.AddDependencies(dependency);
            }
        }
    }
  
    private void SetAchievement_Info(string parent , string Title,GameObject achievement)
    {
        achievement.transform.SetParent(GameObject.Find(parent).transform);
        achievement.transform.localScale = new Vector3(1, 1, 0);
        achievement.transform.GetChild(0).GetComponent<TMP_Text>().text = Title;
        achievement.transform.GetChild(1).GetComponent<TMP_Text>().text = achievements[Title].Description;
        achievement.transform.GetChild(2).GetComponent<TMP_Text>().text = achievements[Title].Points.ToString();
        achievement.transform.GetChild(3).GetComponent<Image>().sprite = achievementSprites[achievements[Title].SpriteIndex];
    }

    public void ChangeCategory(GameObject button)
    {
        Achievement_Button A_Button = button.GetComponent<Achievement_Button>();
        scrollRect.content = A_Button.achievement_List.GetComponent<RectTransform>();
        A_Button.Click();
        activeButton.Click();
        activeButton = A_Button;
    }

    public void EarnAchievement(string title)
    {
       if(achievements[title].EarnAchievement())
        {
            GameObject achievement = Instantiate(visualAchievement);
            SetAchievement_Info("EarnAchievementCanvas", title, achievement);
            pointText.text = "Points : " + PlayerPrefs.GetInt("Points");
            StartCoroutine(FadeAchivement(achievement));
            Player.Instance.Calculate_UI_Info();          
       }
    }

    private IEnumerator HideAchievement(GameObject achievement)
    {
        yield return new WaitForSeconds(3);
        Destroy(achievement);
    }


    public void CheckAchievements()
    {
        foreach (Achievement_Main AM in achievement_Mains.ToList())
        {
            if (!AM.activated)
            {
                AM.Requirements();
            }
        }
        
    }


    private IEnumerator FadeAchivement(GameObject earnedachievement)
    {
        CanvasGroup canvasGroup = earnedachievement.GetComponent<CanvasGroup>();
        float startAlpha = 0;
        float endAlpha = 1;


        for(int i = 0; i < 2; i++)
        {
            float progress = 0.0f;
            while (progress < 1.0)
            {
                canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, progress);
                progress += Time.deltaTime *0.5f;
                yield return null;
            }
            startAlpha = 1;
            endAlpha = 0;
            yield return new WaitForSeconds(2);
        }

        Destroy(earnedachievement);
        

    }

   
}
