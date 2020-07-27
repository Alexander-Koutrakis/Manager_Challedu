using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class InfoPanelControl : MonoBehaviour
{
    [SerializeField]
    private TMP_Text trainningText=null;
    [SerializeField]
    private Image trainningImage=null;
    public Trainning_Info trainning_Info;
    public int trainningIndex;
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
    private int questionIndex = 0;
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
        trainning_Info.trainning_Level++;
        trainningIndex = 0;
        prevButton.interactable = false;
        nextButton.interactable = true;
        startQuizButton.gameObject.SetActive(false);
        trainningImage.sprite = trainning_Info.trainning_Sprites[trainningIndex];
        trainningText.text = trainning_Info.trainning_info_text[trainningIndex];
        pageIndex_text.text = (trainningIndex + 1).ToString() + " / " + (trainning_Info.trainning_info_text.Length+1).ToString();

    }

    public void NextPage()
    {
        trainningIndex++;
        if (trainningIndex >= trainning_Info.trainning_info_text.Length)
        {
            nextButton.interactable = false;
            pageIndex_text.text = (trainningIndex + 1).ToString() + " / " + (trainning_Info.trainning_info_text.Length + 1).ToString();
            ReadyToStartQuiz();
        }
        else
        {
            prevButton.interactable = true;
            trainningImage.sprite = trainning_Info.trainning_Sprites[trainningIndex];
            trainningText.text = trainning_Info.trainning_info_text[trainningIndex];
            pageIndex_text.text = (trainningIndex + 1).ToString() + " / " + (trainning_Info.trainning_info_text.Length + 1).ToString();
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
            trainningText.text = trainning_Info.trainning_info_text[trainningIndex];
            pageIndex_text.text = (trainningIndex + 1).ToString() + " / " + (trainning_Info.trainning_info_text.Length + 1).ToString();
        }
        else
        {
            nextButton.interactable = true;

            trainningImage.sprite = trainning_Info.trainning_Sprites[trainningIndex];
            trainningText.text = trainning_Info.trainning_info_text[trainningIndex];
            pageIndex_text.text = (trainningIndex + 1).ToString() + " / " + (trainning_Info.trainning_info_text.Length + 1).ToString();
        }
    }



    private void ReadyToStartQuiz()
    {
        trainningText.text = readyForQuiz_text;
        startQuizButton.gameObject.SetActive(true);
    }

    //public void NextQuestion()
    //{
    //    questionIndex++;
    //    if (questionIndex < 3)
    //    {          
    //        Question_Manager.Instance.question = trainning_Info.QuizInfo[(trainning_Info.trainning_Level * 3) + questionIndex];
    //        Question_Manager.Instance.StartQuestion();
    //    }else
    //    {
    //        Question_Manager.Instance.GetComponent<Panel_Control>().ClosePanel();

    //        //show results
    //    }
    //}

    public void StartQuiz()
    {
        questionIndex = 0;
        Question_Manager.Instance.question = trainning_Info.QuizInfo[(trainning_Info.trainning_Level * 3) + questionIndex];
        Question_Manager.Instance.StartQuestion();
        GetComponent<Panel_Control>().ClosePanel();
    }
}
