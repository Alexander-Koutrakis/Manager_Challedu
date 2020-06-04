using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PieText : MonoBehaviour
{

    public Vector3 rot;
    Image image;
    TMP_Text text;
    
    public void UpdateText()
    {
        image = GetComponentInParent<Image>();
        text = GetComponent<TMP_Text>();
        if (image.fillAmount < 0.08)
        {
            text.enabled = false;
        }
        else
        {
            text.enabled = true;
        }

        transform.eulerAngles = new Vector3(0, 0, 0);

    }
    
}
