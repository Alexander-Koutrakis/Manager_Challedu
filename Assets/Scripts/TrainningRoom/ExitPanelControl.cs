using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPanelControl : MonoBehaviour
{
    [SerializeField]
    private Panel_Control[] panel_controls = null;

    public void CloseAllPanels()
    {
        foreach(Panel_Control PC in panel_controls)
        {
            PC.ClosePanel();
        }
    }

   
}
