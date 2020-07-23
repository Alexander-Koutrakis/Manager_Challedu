using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DnD_Controller : MonoBehaviour
{
    [SerializeField]
    private DropGroup startingGroup;
    [SerializeField]
    private DropGroup finalGroup;
    [SerializeField]
    private Drag_n_Drop_Question question;
    private List<DnD_Answer> DnDanswers = new List<DnD_Answer>();
    [SerializeField]
    private TMP_Text question_text;

    public void selectRandomQuestion()
    {
        // select a random question from resources
    }
    private void Start()
    {
        FillDnDAnswers();
        RandomizeAnswer();
    }


    public void FillDnDAnswers()
    {

        foreach(DnD_Answer answer in GetComponentsInChildren<DnD_Answer>())
        {
            DnDanswers.Add(answer);
        }

        question_text.text = question.question;
        for (int i = 0; i < question.answers.Length; i++)
        {
            if (i <= 1)
            {
                DnDanswers[i].FillAnswer(question.answers[i], true);
            }
            else
            {
                DnDanswers[i].FillAnswer(question.answers[i], false);
            }
        }

      
    }

    private void RandomizeAnswer()
    {
        int x = Random.Range(0, DnDanswers.Count);
        DnDanswers[x].transform.SetAsLastSibling();
    }

    public void ResetController()
    {
        foreach(DnD_Answer answer in DnDanswers)
        {
            answer.transform.SetParent(startingGroup.layoutgroupTransform);
        }
        startingGroup.currentAnswers = 0;
        finalGroup.currentAnswers = 0;
        selectRandomQuestion();
        FillDnDAnswers();
        RandomizeAnswer();
    }
    

    public void CheckAnswers()
    { int correctAnswers = 0;
        foreach(DnD_Answer answer in finalGroup.GetComponentsInChildren<DnD_Answer>())
        {
            if (answer.CorrectAnswer)
            {
                correctAnswers++;
            }
        }


        if (correctAnswers > 1)
        {
            Debug.Log("Correct !!!!");
            // show correct messege
        }
        else
        {
            Debug.Log("Wrong !!!");
        }
    }
}
