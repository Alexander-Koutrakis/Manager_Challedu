using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SDgs_Detail_Graph : MonoBehaviour
{
    public Slider[] sliders;

    private void OnEnable()
    {
        RefreshGraph();
    }

    public void RefreshGraph()
    {
        sliders = GetComponentsInChildren<Slider>();
        for (int i = 0; i < sliders.Length; i++)
        {
            sliders[i].value = Player_Controller.player_Controller.SDGs[i];
        }
    }
}
