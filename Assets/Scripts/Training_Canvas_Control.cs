using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Training_Canvas_Control : MonoBehaviour
{
    public static Training_Canvas_Control Instance;
    [SerializeField]
    private int[] Max_trainninglevels = new int[17];
    [SerializeField]
    private Trainning_Info[] trainnings = null;
    [SerializeField]
    private TrainningButton[] trainningButtons;
    private void Awake()
    {
        Instance = this;
        foreach(Trainning_Info trainning_Info in trainnings)
        {
            trainning_Info.trainning_Level = 0;
        }
        trainningButtons = GetComponentsInChildren<TrainningButton>();
        CheckForTrainning();
    }


   
    public void CheckForTrainning()
    {
        Debug.Log("Checking for trainning");
       for(int i = 0; i < Player.Instance.SDGs.Length; i++)
       {
            if (Player.Instance.SDGs[i] > 5)
            {
                Max_trainninglevels[i] = 1;
            }else if(Player.Instance.SDGs[i] > 10)
            {
                Max_trainninglevels[i] = 2;
            }
            else if (Player.Instance.SDGs[i] > 200)
            {
                Max_trainninglevels[i] = 3;
            }


            if (trainningButtons[i].buttonInfo.trainning_Level < Max_trainninglevels[i])
            {
                trainningButtons[i].GetComponent<Button>().interactable = true;
            }
            else
            {
                trainningButtons[i].GetComponent<Button>().interactable = false;
            }
     
        }
    }

}
