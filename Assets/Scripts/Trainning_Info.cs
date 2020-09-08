using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Trainning_Info", menuName = "Trainning_Info")]
public class Trainning_Info : ScriptableObject
{
    public int current_Level=0;
    public int max_Level = 0;
    public string[] trainning_info_text1;
    public string[] trainning_info_text2;
    public string[] trainning_info_text3;
    public string[] trainning_info_text4;
    public string[] trainning_info_text5;
    public Sprite[] trainning_Sprites;

    public Question[] QuizInfo1 ;
    public Question[] QuizInfo2 ;
    public Question[] QuizInfo3 ;
    public Question[] QuizInfo4;
    public Question[] QuizInfo5;



}
