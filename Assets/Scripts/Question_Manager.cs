using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Question_Manager : MonoBehaviour
{
    public Question question;
    public TMP_Text question_Text;
    private List<Vector3> position_List = new List<Vector3>();
    private List<Vector3> starting_Pos = new List<Vector3>();
    public GameObject[] Answer_Button;
    public static Question_Manager Instance;
    public int CorrectAnswers=0;
    private int questionIndex = 0;
    private void Awake()
    {
        for (int i = 0; i < 4; i++)
        {
            starting_Pos.Add(Answer_Button[i].GetComponent<RectTransform>().anchoredPosition);
        }       
        Instance = this;
    }
    public void StartQuestion()
    {

  
        question_Text.text = question.question_Text;

        if (starting_Pos != null)
        {
            for(int i = 0; i < Answer_Button.Length; i++)
            {
                Answer_Button[i].GetComponent<RectTransform>().anchoredPosition = starting_Pos[i];
            }
        }


        for(int i = 0; i < 4; i++)
        {
            if (i < question.answers_Text.Length)
            {
               
                Answer_Button[i].GetComponentInChildren<TMP_Text>().text = question.answers_Text[i];
                Answer_Button[i].gameObject.SetActive(true);
                if (i == 0)
                {
                    Answer_Button[i].GetComponent<Quiz_Answer_Button>().correct_Answer = true;
                }
                else
                {
                    Answer_Button[i].GetComponent<Quiz_Answer_Button>().correct_Answer = false;
                }
            }
            else
            {
                Answer_Button[i].SetActive(false);
            }
          
           
        }

        foreach(GameObject GO in Answer_Button)
        {
            if (GO.activeSelf)
            {
                position_List.Add(GO.GetComponent<RectTransform>().anchoredPosition);
            }
        }
               
        position_List.Shuffle();

        for (int i = 0; i < position_List.Count; i++)
        {
            Answer_Button[i].GetComponent<RectTransform>().anchoredPosition = position_List[i];
        }


        position_List.Clear();

    }


    public void NextQuestion()
    {
        questionIndex++;
        if (questionIndex < 3)
        {
            Question_Manager.Instance.question =InfoPanelControl.Instance.trainning_Info.QuizInfo[(InfoPanelControl.Instance.trainning_Info.trainning_Level * 3) + questionIndex];
            Question_Manager.Instance.StartQuestion();
        }
        else
        {
            Question_Manager.Instance.GetComponent<Panel_Control>().ClosePanel();
            QuizResults.Instance.ShowResults(CorrectAnswers);
            CorrectAnswers = 0;
            //show results
        }
    }
}
