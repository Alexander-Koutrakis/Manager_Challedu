using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Warning_Panel : MonoBehaviour
{
    public static Warning_Panel Instance;
    private void Awake()
    {
        Instance = this;
    }


    public void ShowMessege(string messege)
    {
        GetComponentInChildren<TMP_Text>().text = messege;
        OpenPanel();
    }

    private void OpenPanel()
    {
        LeanTween.moveLocalX(gameObject, -815, 0.5f).setOnComplete(WaitForTime);
    }

    private void WaitForTime()
    {
        LeanTween.moveLocalX(gameObject, -815, 2f).setOnComplete(ClosePanel);
    }

    private void ClosePanel()
    {
        LeanTween.moveLocalX(gameObject, -1110, 0.5f);
    }
}
