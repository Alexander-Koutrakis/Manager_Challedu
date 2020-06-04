using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PieGraph : MonoBehaviour
{
    public float[] values;
    private float total;
    private Image[] images;
    private float zRotation;
    PieText[] pieTexts;

    private void Start()
    {
        GetValues();
        RefreshGraph();
        pieTexts = GetComponentsInChildren<PieText>();
        GameMaster.gameMaster.pieGraph_Small = this;
    }


    public void RefreshGraph()
    {
        total = 0;
        images = GetComponentsInChildren<Image>();
        for (int i = 0; i < values.Length; i++)
        {
            total += values[i];

        }

        for (int i = 0; i < values.Length; i++)
        {
            
            images[i].fillAmount = values[i]/total;
            images[i].transform.rotation = Quaternion.Euler(new Vector3(0, 0, zRotation));
            zRotation -= images[i].fillAmount*360f;
        }

    }

    public void GetValues()
    {
        values = Player_Controller.player_Controller.SDGs;
        RefreshGraph();
    }
}
