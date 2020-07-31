using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Training_Canvas_Control : MonoBehaviour
{   
    [SerializeField]
    private List<TrainningButton> trainningButtons = new List<TrainningButton>();


    private void OnEnable()
    {
        

        foreach (TrainningButton button in trainningButtons)
        {
            if(button.buttonInfo.current_Level< button.buttonInfo.max_Level)
            {
                
                button.GetComponent<Button>().interactable = true;
            }
            else
            {
                button.GetComponent<Button>().interactable = false;
            }
        }
    }

}
