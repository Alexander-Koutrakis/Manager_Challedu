using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.WSA;

public class Presentation_results : MonoBehaviour
{
    [SerializeField]
    private TMP_Text presentation_text;
    [SerializeField]
    private TMP_Text answer_1;
    [SerializeField]
    private TMP_Text answer_2;

    public void StartPresentration(string title , string answer1, string answer2)
    {
        presentation_text.text = title;
        answer_1.text = answer1;
        answer_2.text = answer2;
    }
}
