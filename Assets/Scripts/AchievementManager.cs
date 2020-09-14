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
    public Sprite Star_Points_sprite;
    public Sprite unlockedSprite;
    public TMP_Text pointText; 
    public static AchievementManager Instance;
    public Panel_Control panel_Control;
    public List<Achievement_Main> achievement_Mains = new List<Achievement_Main>();
    [SerializeField]
    private RectTransform achievement_rect_Transform = null;
    private int currentPage = 1;
    [SerializeField]
    private int totalPages = 0;
    private bool waitButtonBool;
    [SerializeField]
    private TMP_Text page_Text = null;
    private int totalAchievements = 0;
    [SerializeField]
    private RectTransform warningSign;
    private bool warning = false;
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

        totalAchievements++;
        if(totalAchievements % 8 == 0)
        {
            totalPages = totalAchievements / 8 ;
        }
        else
        {
            totalPages = totalAchievements / 8 + 1;
        }
        
        page_Text.text = currentPage.ToString() + " / " + totalPages.ToString();
    }
  
    private void SetAchievement_Info(string parent , string Title,GameObject achievement)
    {
        achievement.transform.SetParent(GameObject.Find(parent).transform);
        achievement.transform.localScale = new Vector3(1, 1, 0);
        achievement.transform.GetChild(0).GetComponent<TMP_Text>().text = Title;
      
        achievement.transform.GetChild(1).GetComponent<TMP_Text>().text = achievements[Title].Description;
        achievement.transform.GetChild(4).GetComponent<TMP_Text>().text = achievements[Title].Points.ToString();
        achievement.transform.GetChild(2).GetComponent<Image>().sprite = achievementSprites[achievements[Title].SpriteIndex];
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
            achievements[title].achievementRef.transform.SetAsFirstSibling();
            // GameObject achievement = Instantiate(visualAchievement);
            //  SetAchievement_Info("EarnAchievementCanvas", title, achievement);
            //  StartCoroutine(FadeAchivement(achievement));
            Warning_Panel.Instance.ShowMessege("Νεο \n Επίτευγμα");
            Player.Instance.Calculate_UI_Info();
            ShowWarning();
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


    public void NextPage()
    {
        int x = (totalPages - 1) * -1180;
        if (achievement_rect_Transform.anchoredPosition.x > x && !waitButtonBool)
        {
            Debug.Log("here");
            LeanTween.moveLocalX(achievement_rect_Transform.gameObject, achievement_rect_Transform.anchoredPosition.x - 1180, 0.5f).setOnComplete(buttonReady);
            currentPage++;
            page_Text.text = currentPage.ToString() + " / " + totalPages.ToString();
            waitButtonBool = true;
        }
    }

    public void PrevPage()
    {
        if (achievement_rect_Transform.anchoredPosition.x < -590 && !waitButtonBool)
        {
            LeanTween.moveLocalX(achievement_rect_Transform.gameObject, achievement_rect_Transform.anchoredPosition.x + 1180, 0.5f).setOnComplete(buttonReady);
            currentPage--;
            page_Text.text = currentPage.ToString() + " / " + totalPages.ToString();
            waitButtonBool = true;
        }
    }

    private void buttonReady()
    {
        waitButtonBool = false;
    }


    public void ShowWarning()
    {
        if (!warning)
        {
            warning = true;
            LeanTween.scale(warningSign.gameObject, new Vector3(1f, 1f, 1f), 0.5f).setOnComplete(WarningFollowUp);
        }
        Warning_Panel.Instance.ShowMessege("το Έργο ολοκληρώθηκε");
    }


    private void WarningFollowUp()
    {
        LeanTween.scale(warningSign.gameObject, new Vector3(1.2f, 1.2f, 1.2f), 0.5f).setLoopPingPong();
    }

    public void HideWarning()
    {
        if (warning)
        {
            warning = false;
            LeanTween.cancel(warningSign.gameObject);
            LeanTween.scale(warningSign.gameObject, Vector3.zero, 0.5f);
        }

    }
}
