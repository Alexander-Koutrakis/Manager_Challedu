using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SDG_Stats : MonoBehaviour
{   [SerializeField]
    private float[] SDGs=null;
    private Slider[] Sliders;
    public static SDG_Stats instance;

    private void Awake()
    {
        instance = this;
        Sliders = GetComponentsInChildren<Slider>();
    }

    public void GetSDGStats()
    {
        SDGs = Player.Instance.SDGs;
        for(int i = 0; i < Sliders.Length; i++)
        {
            Sliders[i].value = SDGs[i];
        }
    }
}
