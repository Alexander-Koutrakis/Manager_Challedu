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
            Question_Manager.Instance.CorrectAnswers++;
            Question_Manager.Instance.NextQuestion();
           
            Debug.Log("Correct!!!");
        }
        else if(!correct_Answer)
        {
            Question_Manager.Instance.NextQuestion();
            Debug.Log("Wrong");
        }
    }
}
