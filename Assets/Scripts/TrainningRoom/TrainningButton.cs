using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainningButton : MonoBehaviour
{
    [SerializeField]
    private Trainning_Info buttonInfo=null;


    public void StartTraining()
    {
        InfoPanelControl.Instance.trainning_Info = buttonInfo;
        InfoPanelControl.Instance.StartTrainning();
    }
}
