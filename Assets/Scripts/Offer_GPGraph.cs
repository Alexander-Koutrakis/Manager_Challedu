using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Offer_GPGraph : MonoBehaviour
{
   
    public Slider[] sliders;
    private IEnumerator[] coroutines=new IEnumerator[6];
    public float[] sliderScore;
    public void ShowGraph(float[] GPs)
    {
        GetSliders();

       foreach (Slider slider in sliders)
        {
            slider.value = 0;
        }
       
        for(int i = 0; i < sliders.Length; i++)
        {
            
            coroutines[i] = CalculateGraph(sliders[i], GPs[i]);
            StartCoroutine(coroutines[i]);
        }
    }

    public void HideGraph() {
        for (int i = 0; i < sliders.Length; i++)
        {           
            StopCoroutine(coroutines[i]);
        }
    }

    private void GetSliders()
    {

        sliders = GetComponentsInChildren<Slider>();

    }

    private IEnumerator CalculateGraph(Slider slider, float targetValue) {
        float speed = 10;
        foreach (Slider slider0 in sliders)
        {
            slider0.value = 0;
        }

        yield return new WaitForSeconds(0.5f); //--------Delay for tab movement

        while (slider.value != targetValue)
        {
            slider.value = Mathf.Lerp(slider.value, targetValue, speed * Time.deltaTime);
          yield  return null;
        }

       yield return null;
    }


  
}
