using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Question", menuName = "Question")]
public class Question : ScriptableObject
{
    public string question_Text;
    [Tooltip("First Answer must be the Correct one")]
    public string[] answers_Text;

}
