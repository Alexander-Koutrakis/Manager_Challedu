﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.Mathematics;

public class InfoPanelControl : MonoBehaviour
{
    [SerializeField]
    private TMP_Text trainningText=null;
    [SerializeField]
    private Image trainningImage=null;
    public Trainning_Info trainning_Info;
    private int trainningIndex;
    [SerializeField]
    private Button nextButton=null;
    [SerializeField]
    private Button prevButton=null;
    [SerializeField]
    private TMP_Text pageIndex_text=null;
    [SerializeField]
    private string readyForQuiz_text=null;
    [SerializeField]
    private Button startQuizButton=null;
    public static InfoPanelControl Instance;
    private string[] trainningSlides;
    private Question[] quizQuestions;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

   

    public void StartTrainning()
    {

        if (trainning_Info.trainning_Level == 1)
        {
            trainningSlides = trainning_Info.trainning_info_text1;
            Question_Manager.Instance.questions = trainning_Info.QuizInfo1;
        }
        else if(trainning_Info.trainning_Level == 2)
        {
            trainningSlides = trainning_Info.trainning_info_text2;
            Question_Manager.Instance.questions = trainning_Info.QuizInfo2;
        }
        else if (trainning_Info.trainning_Level == 3)
        {
            trainningSlides = trainning_Info.trainning_info_text3;
            Question_Manager.Instance.questions = trainning_Info.QuizInfo3;
        }



        // add text and questions according to level

        trainningIndex = 0;
        prevButton.interactable = false;
        nextButton.interactable = true;
        startQuizButton.gameObject.SetActive(false);
        trainningImage.sprite = trainning_Info.trainning_Sprites[trainningIndex];
        trainningText.text = trainningSlides[trainningIndex];
        pageIndex_text.text = (trainningIndex + 1).ToString() + " / " + (trainningSlides.Length + 1).ToString();

    }

    public void NextPage()
    {
        trainningIndex++;
        if (trainningIndex >= trainningSlides.Length)
        {
            nextButton.interactable = false;
            pageIndex_text.text = (trainningIndex + 1).ToString() + " / " + (trainningSlides.Length + 1).ToString();
            ReadyToStartQuiz();
        }
        else
        {
            prevButton.interactable = true;
            trainningImage.sprite = trainning_Info.trainning_Sprites[trainningIndex];
            trainningText.text = trainningSlides[trainningIndex];
            pageIndex_text.text = (trainningIndex + 1).ToString() + " / " + (trainningSlides.Length + 1).ToString();
        }
    }

    public void PrevPage()
    {
        trainningIndex--;
        if (trainningIndex <= 0)
        {
            trainningIndex = 0;
            prevButton.interactable = false;
            trainningImage.sprite = trainning_Info.trainning_Sprites[trainningIndex];
            trainningText.text = trainningSlides[trainningIndex];
            pageIndex_text.text = (trainningIndex + 1).ToString() + " / " + (trainningSlides.Length + 1).ToString();
        }
        else
        {
            nextButton.interactable = true;

            trainningImage.sprite = trainning_Info.trainning_Sprites[trainningIndex];
            trainningText.text = trainningSlides[trainningIndex];
            pageIndex_text.text = (trainningIndex + 1).ToString() + " / " + (trainningSlides.Length + 1).ToString();
        }
    }

    private void ReadyToStartQuiz()
    {
        trainningText.text = readyForQuiz_text;
        startQuizButton.gameObject.SetActive(true);
    }
 
    public void StartQuiz()
    {
        Question_Manager.Instance.StartQuestion();
        GetComponent<Panel_Control>().ClosePanel();
    }


   
}
