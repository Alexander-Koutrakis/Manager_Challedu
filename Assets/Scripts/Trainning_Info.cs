using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Trainning_Info", menuName = "Trainning_Info")]
public class Trainning_Info : ScriptableObject
{
    public int trainning_Level=-1;
    public string[] trainning_info_text;
    public Sprite[] trainning_Sprites;
    public List<Question> QuizInfo = new List<Question>();

}
