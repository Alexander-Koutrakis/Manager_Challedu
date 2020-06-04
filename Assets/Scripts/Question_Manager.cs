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
    public Panel_Control panel_Control_Answers;


    private void Awake()
    {
        for (int i = 0; i < 4; i++)
        {
            starting_Pos.Add(Answer_Button[i].GetComponent<RectTransform>().anchoredPosition);
        }

        
    }
    private void OnEnable()
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

        panel_Control_Answers.OpenPanel();


    }

   

    public void CloseQuestionManager()
    {
        foreach(GameObject GO in Answer_Button)
        {
            GO.SetActive(true);
        }
        position_List.Clear();

        panel_Control_Answers.ClosePanel();

        StartCoroutine("WaitForPanels");
    }

    public void CloseQuiz()
    {
        GetComponentInParent<QuizManager>().continueQuiz = false;
    }

    private void DeactivateGO()
    {
        gameObject.SetActive(false);
        GetComponentInParent<QuizManager>().ContinueQuiz();
    }


    private IEnumerator WaitForPanels() {
        // yield return new WaitWhile(() => panel_Control_Answers.gameObject.activeSelf);
        yield return new WaitForSeconds(0.5f);
        DeactivateGO();
    }
}
