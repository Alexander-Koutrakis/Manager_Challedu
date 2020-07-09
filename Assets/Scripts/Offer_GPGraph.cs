using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Offer_GPGraph : MonoBehaviour
{
   
    public Slider[] sliders;
   // private IEnumerator[] coroutines=new IEnumerator[6];




    private void Start()
    {
        GetSliders();
    }

    public void ShowGraph(float[] GPs)
    {
       
        
       //foreach (Slider slider in sliders)
       //{
       //     slider.value = 0;
       //}
       
        for(int i = 0; i < sliders.Length; i++)
        {
            
            //coroutines[i] = CalculateGraph(sliders[i], GPs[i]);
            StartCoroutine(CalculateGraph(sliders[i], GPs[i]));
        }
    }

  

    private void GetSliders()
    {

        sliders = GetComponentsInChildren<Slider>();

    }

    private IEnumerator CalculateGraph(Slider slider, float targetValue) {

        slider.value = 0;
        yield return new WaitForSeconds(0.5f); //--------Delay for tab movement

        while (Mathf.Abs(slider.value - targetValue)>0.1f)
        {
          slider.value = Mathf.Lerp(slider.value, targetValue, 10 * Time.deltaTime);
          yield  return null;
        }      
    }


  
}
