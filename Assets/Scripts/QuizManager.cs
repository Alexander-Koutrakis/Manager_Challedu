using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizManager : MonoBehaviour
{
    public Question_Manager question_Manager;
    private List<Question> questions = new List<Question>();
    private int questionNum = 0;
    public int maxNumbQuestion;
    public bool continueQuiz;
    public int CorrectAnswers;
    private void Start()
    {
        foreach(Question question in Resources.LoadAll<Question>("Trainning_Questions"))
        {
            questions.Add(question);
        }
    }

    public void NewQuestion()
    {
        continueQuiz = true;
        questionNum++;
        int x = Random.Range(0, questions.Count);
        question_Manager.question = questions[x];
        questions.Remove(questions[x]);
        question_Manager.gameObject.SetActive(true);
    }

    public void CloseQuestionManager()
    {
        question_Manager.CloseQuestionManager();
    }

    public void ContinueQuiz()
    {
        if (questionNum >= maxNumbQuestion|| continueQuiz==false)
        {
            continueQuiz = false;
            questionNum = 0;
            if (CorrectAnswers == maxNumbQuestion)
            {
                Player.Instance.Reputation += 0.2f;               
            }
        }
        else
        {
            NewQuestion();
        }        
    }

   
}
