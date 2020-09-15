using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Networking_Controller : MonoBehaviour
{
    [SerializeField]
    private List<Slideshow> slideshows = new List<Slideshow>();
    [SerializeField]
    private Image image;
    Slideshow currentSlideshow;
    private int index=0;


    private void Start()
    {
        index = 0;
        currentSlideshow = slideshows[0];
        Star_Show();
    }


    public void Star_Show()
    {
        image.sprite = currentSlideshow.Slides[index];
        StartCoroutine(HoldImage());
    }

    private IEnumerator HoldImage()
    {
        yield return new WaitForSeconds(5);
       
        if (index < currentSlideshow.Slides.Length)
        {
            index++;
            image.sprite = currentSlideshow.Slides[index];
            StartCoroutine(HoldImage());
        }
    }
  
}
