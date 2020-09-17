using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Level_Up_Panel : MonoBehaviour
{
    [SerializeField]
    private RectTransform Background;
    [SerializeField]
    private RectTransform Inner;
    [SerializeField]
    private RectTransform textTransform;
    [SerializeField]
    private RectTransform[] levelUP_Pos = new RectTransform[6];
    [SerializeField]
    private GameObject fireworkPrefab = null;
    [SerializeField]
    private RectTransform buttonTransform = null;
    public static Level_Up_Panel Instance;
    [SerializeField]
    private Panel_Control Ask_for_Campaing_Panel;
    private void Awake()
    {
        Instance = this;
    }
    public void CheckForLevelUp()
    {
        if (Player.Instance.lvlUp)
        {
            LevelUP_Start();
        }
    }

    private void LevelUP_Start()
    {
        LeanTween.scale(Background, new Vector3(1, 1, 1), 0.1f).setOnComplete(FadeBackGround);
    }

   private void FadeBackGround()
    {

        LeanTween.rotateZ(textTransform.gameObject, -10, 0.5f);
        textTransform.GetComponent<TMP_Text>().text = (Player.Instance.Player_Level+1).ToString();
        LeanTween.alpha(Background, 0.7f, 0.5f).setOnComplete(OpenInner);        
        StartCoroutine(ShowFireWorks());
    }

    private void OpenInner()
    {
        LeanTween.alpha(buttonTransform, 1f, 0.5f);
        LeanTween.scale(buttonTransform, new Vector3(1f, 1f, 1), 0.5f);
        LeanTween.alpha(Inner, 1f, 0.5f);
        LeanTween.rotateZ(textTransform.gameObject, -10, 0.5f);
        LeanTween.scale(Inner, new Vector3(1, 1, 1), 0.5f).setOnComplete(RotateText);

    }

    private void RotateText()
    {
        LeanTween.rotateZ(textTransform.gameObject, 10, 0.5f).setLoopPingPong();
        LeanTween.scale(buttonTransform, new Vector3(1.1f, 1.1f, 1), 0.5f).setLoopPingPong();
    }

    private void ResetLevelUP()
    {
        LeanTween.cancel(Background);
        LeanTween.cancel(Inner);
        LeanTween.cancel(textTransform);
        LeanTween.cancel(buttonTransform);
        Background.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
        Background.localScale = new Vector3(0, 0, 0);
        Inner.localScale = new Vector3(0, 0, 0);
        textTransform.rotation = Quaternion.Euler(new Vector3(0, 0, -10));
        
    }       

    public void CloseLevelUPPanel()
    {
        LeanTween.alpha(Background, 0f, 0.5f);
        LeanTween.scale(Inner, new Vector3(0, 0, 0), 0.5f).setOnComplete(ResetLevelUP);
        Ask_for_Campaing_Panel.OpenPanel();
    }

    private IEnumerator ShowFireWorks()
    {
        List<GameObject> fireworks = new List<GameObject>();
       
        foreach(Transform pos in levelUP_Pos)
        {
            GameObject firework = Instantiate(fireworkPrefab, pos.position, Quaternion.identity,pos);
            fireworks.Add(firework);
        }
        
        
       

        yield return new WaitForSeconds(5);

        foreach (GameObject Go in fireworks)
        {
            Destroy(Go);
        }

        fireworks.Clear();
    }

    public void LevelUPButton()
    {
        CloseLevelUPPanel();
        Player.Instance.Level_Up();
    }
}
