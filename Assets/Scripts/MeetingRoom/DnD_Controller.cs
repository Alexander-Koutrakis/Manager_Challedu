using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DnD_Controller : MonoBehaviour
{
    public static DnD_Controller Instance;
    [SerializeField]
    private DropGroup startingGroup=null;
    [SerializeField]
    private DropGroup finalGroup=null;
    [SerializeField]
    private Drag_n_Drop_Question question=null;
    private List<DnD_Answer> DnDanswers = new List<DnD_Answer>();
    [SerializeField]
    private TMP_Text question_text=null;
    [SerializeField]
    private Button presentationButton=null;
    [SerializeField]
    private Presentation_results results=null;
    [SerializeField]
    private Panel_Control presentationPanelControl=null;
    [SerializeField]
    private Panel_Control wrongPanelControl=null;
    [SerializeField]
    private Panel_Control congrats_PanelControl = null;

    private void Awake()
    {
        Instance = this;
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

    public void ResetController(Drag_n_Drop_Question dnd_Question)
    {
        startingGroup.restartAnswerPositions();
        finalGroup.EmptyAnswerSlots();
        question = dnd_Question;
        FillDnDAnswers();
        RandomizeAnswer();
    }   
    public void CheckAnswers()
    {   
        int correctAnswers = 0;
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
            congrats_PanelControl.OpenPanel();
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
