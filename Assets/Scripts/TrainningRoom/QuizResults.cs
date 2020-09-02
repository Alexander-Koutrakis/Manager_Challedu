﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuizResults : MonoBehaviour
{
    public static QuizResults Instance;
    [SerializeField]
    private TMP_Text result_Text;
    [SerializeField]
    private Sprite CorrectSprite;
    [SerializeField]
    private Sprite FalseSprite;
    [SerializeField]
    private Image ResultImage;
    private void Awake()
    {
        Instance = this;
    }

    public void ShowResults(int correctAnswers)
    {
        if (correctAnswers > 0)
        {
            Player.Instance.successfulSDGTrainings++;
            ResultImage.sprite = CorrectSprite;
            GetComponent<Panel_Control>().OpenPanel();
            result_Text.gameObject.SetActive(true);
            result_Text.text = (correctAnswers * (100)).ToString();
            GameMaster.Instance.DelayedExp = correctAnswers * 100;
        }
        else
        {
            ResultImage.sprite = FalseSprite;
            result_Text.gameObject.SetActive(false);
            GetComponent<Panel_Control>().OpenPanel();
        }
       

    }
}
