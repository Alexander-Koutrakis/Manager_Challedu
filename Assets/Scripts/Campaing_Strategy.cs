using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Campaing_Strategy : MonoBehaviour
{
    private Campaing_Star_Button[] starButtons;
    public Sprite pressedSprite;
    public Sprite unPressedSprite;
    public int stars;
    [SerializeField]
    private GameObject starPS;
    private void Start()
    {
        starButtons = GetComponentsInChildren<Campaing_Star_Button>();
    }

    public void ButtonPress(Campaing_Star_Button button)
    {
        int index = System.Array.IndexOf(starButtons, button);
       
        for (int j = starButtons.Length-1; j >= index; j--)
        {

            if (Campain_Plan.Instance.stars > 0&& !starButtons[j].pressed)
            {
                starButtons[j].GetComponent<Image>().sprite = pressedSprite;
                starButtons[j].pressed = true;

                Campain_Plan.Instance.stars--;
                Instantiate(starPS, starButtons[j].transform.position, Quaternion.identity);
                // swap sprites to pressed
            }
        }
        GetStars();
        Campain_Plan.Instance.GetStars(this);

    }

    
    public void ButtonUnPress(Campaing_Star_Button button)
    {
        int index = System.Array.IndexOf(starButtons, button);
        starButtons[index].pressed = false;
        starButtons[index].GetComponent<Image>().sprite = unPressedSprite;
        Campain_Plan.Instance.stars++;
        for (int j = index-1; j >= 0; j--)
        {
            if (starButtons[j].pressed)
            {
                starButtons[j].pressed = false;
                starButtons[j].GetComponent<Image>().sprite = unPressedSprite;
                Campain_Plan.Instance.stars++;
                //swap sprites to unpressed
            }
           

        }
        GetStars();
        Campain_Plan.Instance.GetStars(this);
    }


    public void GetStars()
    {
        stars = 0;
        foreach(Campaing_Star_Button campaing_Star_Button in GetComponentsInChildren<Campaing_Star_Button>())
        {
            if (campaing_Star_Button.pressed)
            {
                stars++;
            }
        }
    }
}
