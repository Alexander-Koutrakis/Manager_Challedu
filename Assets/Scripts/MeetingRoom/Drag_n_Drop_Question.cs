using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New DnD_Question", menuName = "DnD_Question")]
public class Drag_n_Drop_Question : ScriptableObject
{
    
    public string question=null;
    [Tooltip("First two Answers must be the Correct")]
    public string[] answers = new string[3];
}
