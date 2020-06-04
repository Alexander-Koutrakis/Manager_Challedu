using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Trainning_Panel : MonoBehaviour
{
    public Trainning_Info trainning_Info;
    public TMP_Text shownText;
    string currentText = "";
   // string[] trainningTexts;
    private int currentTrainningText;
    private IEnumerator currentCoroutine;
    private float delay = 0.01f;
    public GameObject Next_Button;
    public void NextText()
    {
        StopCoroutine(currentCoroutine);
        currentText = "";
        shownText.text = currentText;
        if (currentTrainningText < trainning_Info.trainning_info_text.Length)
        {
            currentTrainningText++;
        }

        if(currentTrainningText == trainning_Info.trainning_info_text.Length - 1)
        {
            Next_Button.SetActive(false);
        }
        currentCoroutine = TypewriterEffect();
        StartCoroutine(currentCoroutine);
    }

    private IEnumerator TypewriterEffect() {
        trainning_Info.trainning_info_text[currentTrainningText]= trainning_Info.trainning_info_text[currentTrainningText].Replace("\\n", "\n");
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < trainning_Info.trainning_info_text[currentTrainningText].Length; i++)
        {
            //--------------Save for Later-------------------------------------------------------//
            currentText = trainning_Info.trainning_info_text[currentTrainningText].Substring(0, i);
            shownText.text = currentText;
             yield return new WaitForSeconds(delay);

        }    
    }

    public void StartTrainning()
    {
        Debug.Log("here");
        Next_Button.SetActive(true);
        currentText = "";
        shownText.text = currentText;
        currentCoroutine = TypewriterEffect();
        StartCoroutine(currentCoroutine);
    }

    public void Stoptrainning() {
        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
        }

        currentTrainningText = 0;
    }

}
