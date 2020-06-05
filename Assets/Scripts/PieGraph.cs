using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PieGraph : MonoBehaviour
{
    public float[] values;
    public Sprite[] SDG_Sprites;
    public Image[] TopSDGs=new Image[17];
    private float total;
    private Image[] images;
    private float zRotation;
   

    private void Start()
    {
        GetValues();
        RefreshGraph();
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

        GetTopSDGValues(values);
    }

    public void GetValues()
    {
        values = Player_Controller.player_Controller.SDGs;
        RefreshGraph();
    }


    private void GetTopSDGValues(float[] Sdgs) {
        float top1 = 0;
        float top2 = 0;
        float top3 = 0;
     

        for(int i=0; i < Sdgs.Length; i++)
        {
            if (Sdgs[i] > top1)
            {
                top1 = Sdgs[i];               
                TopSDGs[0].sprite = SDG_Sprites[i];
                TopSDGs[0].transform.GetComponentInChildren<TextMeshProUGUI>().text = top1.ToString("F1");
            } else if (Sdgs[i] > top2)
            {
                top2 = Sdgs[i];

                TopSDGs[1].sprite = SDG_Sprites[i];
                TopSDGs[1].transform.GetComponentInChildren<TextMeshProUGUI>().text = top2.ToString("F1");
            } else if (Sdgs[i] > top3){
                top3 = Sdgs[i];
                TopSDGs[2].sprite = SDG_Sprites[i];
                TopSDGs[2].transform.GetComponentInChildren<TextMeshProUGUI>().text = top3.ToString("F1");
            }

            
        }


    }
}
