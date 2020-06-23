using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Campaing_Star_Button : MonoBehaviour
{
    public bool pressed = false;   


 
    public void PressButton()
    {
        if (!pressed)
        {
           // pressed = true;
            GetComponentInParent<Campaing_Strategy>().ButtonPress(this);
        }
        else if(pressed)
        {
            pressed = false;
            GetComponentInParent<Campaing_Strategy>().ButtonUnPress(this);           
        }

        
    }

}
