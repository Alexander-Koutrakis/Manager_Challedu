
using UnityEngine;
using TMPro;


public class Presentation_results : MonoBehaviour
{
    [SerializeField]
    private TMP_Text presentation_text=null;
    [SerializeField]
    private TMP_Text answer_1=null;
    [SerializeField]
    private TMP_Text answer_2=null;

    public void StartPresentration(string title , string answer1, string answer2)
    {
        presentation_text.text = title;
        answer_1.text = answer1;
        answer_2.text = answer2;
    }
}
