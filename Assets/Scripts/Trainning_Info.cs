using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Trainning_Info", menuName = "Trainning_Info")]
public class Trainning_Info : ScriptableObject
{
    public int trainning_Level=0;
    public string[] trainning_info_text1;
    public string[] trainning_info_text2;
    public string[] trainning_info_text3;
    public Sprite[] trainning_Sprites;

    public Question[] QuizInfo1 ;
    public Question[] QuizInfo2 ;
    public Question[] QuizInfo3 ;

}
