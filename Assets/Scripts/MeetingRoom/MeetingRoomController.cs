using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeetingRoomController : MonoBehaviour , IMiniGame
{
  
    public void StartMiniGame()
    {
        DnD_Controller.Instance.ResetController();
    }

   

    public void CloseMiniGame()
    {
        foreach (Panel_Control panel_control in GetComponentsInChildren<Panel_Control>())
        {
            panel_control.ClosePanel();
        }
    }
}
