using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Camera_Size_Control : MonoBehaviour
{
    [SerializeField]
    private CanvasScaler[] canvasScalers;
    // Start is called before the first frame update
    void Start()
    {
        if (Camera.main.aspect >= 1.7)
        {
            Debug.Log("16:9");
            changeScalers(1);
        }
        else if (Camera.main.aspect >= 1.5)
        {
            Debug.Log("3:2");
            changeScalers(0);
        }
        else
        {
            Debug.Log("4:3");
            changeScalers(0);
        }
    }

  

    private void changeScalers(float x)
    {
        foreach(CanvasScaler CS in canvasScalers)
        {
            CS.matchWidthOrHeight = x;
        }
    }
}
