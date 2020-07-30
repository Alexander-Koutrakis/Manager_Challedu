using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class QuizResults : MonoBehaviour
{
    public static QuizResults Instance;
    [SerializeField]
    private TMP_Text result_Text;
    private void Awake()
    {
        Instance = this;
    }

    public void ShowResults(int correctAnswers)
    {
        GetComponent<Panel_Control>().OpenPanel();
        result_Text.text =(correctAnswers * (100)).ToString();
    }
}
