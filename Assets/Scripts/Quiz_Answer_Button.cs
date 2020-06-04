using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quiz_Answer_Button : MonoBehaviour
{
    public bool correct_Answer;

    public void OnSelect_Answer()
    {
        if (correct_Answer)
        {
            GetComponentInParent<QuizManager>().CloseQuestionManager();
            GetComponentInParent<QuizManager>().CorrectAnswers++;
            Debug.Log("Correct!!!");
        }
        else if(!correct_Answer)
        {
            GetComponentInParent<QuizManager>().CloseQuestionManager();
            Debug.Log("Wrong");
        }
    }
}
