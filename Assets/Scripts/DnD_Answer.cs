using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DnD_Answer : MonoBehaviour
{
    [SerializeField]
    private TMP_Text choice_text;
    public bool CorrectAnswer;

    public void FillAnswer(string answer, bool correct)
    {
        choice_text.text = answer;
        CorrectAnswer = correct;
    }
}
