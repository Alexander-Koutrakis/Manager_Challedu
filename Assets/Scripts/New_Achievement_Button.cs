using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class New_Achievement_Button : MonoBehaviour
{

    public void ClaimAchievement()
    {
        string pointsText = GetComponentsInChildren<TMP_Text>()[2].text;
        int points = int.Parse(pointsText);
        GetComponent<Image>().sprite = GameMaster.Instance.achievementComplete_Sprite;
        Player.Instance.Expirience += points;
        Player.Instance.Calculate_UI_Info();
        Debug.Log(points);
    }
}
