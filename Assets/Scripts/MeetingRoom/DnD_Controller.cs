using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DnD_Controller : MonoBehaviour
{
    public static DnD_Controller Instance;
    [SerializeField]
    private DropGroup startingGroup;
    [SerializeField]
    private DropGroup finalGroup;
    [SerializeField]
    private Drag_n_Drop_Question question;
    private List<DnD_Answer> DnDanswers = new List<DnD_Answer>();
    [SerializeField]
    private TMP_Text question_text;
    [SerializeField]
    private Button presentationButton;
    [SerializeField]
    private Presentation_results results;
    [SerializeField]
    private Panel_Control presentationPanelControl;
    [SerializeField]
    private Panel_Control wrongPanelControl;


    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
       
        FillDnDAnswers();
        RandomizeAnswer();
    }


    private void selectRandomQuestion()
    {
        question = question;
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

        startingGroup.restartAnswerPositions();
        finalGroup.EmptyAnswerSlots();
        selectRandomQuestion();
        FillDnDAnswers();
        RandomizeAnswer();
    }   
    public void CheckAnswers()
    { int correctAnswers = 0;
        string[] answersString=new string[2];
       
        foreach(DnD_Answer answer in finalGroup.GetComponentsInChildren<DnD_Answer>())
        {
            if (answer.CorrectAnswer)
            {
                answersString[correctAnswers] = answer.choice_text.text;
                correctAnswers++;                
            }
        }


        if (correctAnswers > 1)
        {
            Debug.Log("Correct !!!!");
            results.StartPresentration(question.question, answersString[0], answersString[1]);
            presentationPanelControl.OpenPanel();
            // show correct messege
        }
        else
        {
            Debug.Log("Wrong !!!");
            wrongPanelControl.OpenPanel();
        }
    }

    public void CheckIFreadyForPresentation()
    {
        if (finalGroup.GetComponentsInChildren<DnD_Answer>().Length > 1)
        {
            presentationButton.interactable = true;
        }
        else
        {
            presentationButton.interactable = false;
        }
    }


}
