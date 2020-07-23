using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fading_toNothing : MonoBehaviour
{

    private void Start()
    {
        LeanTween.alpha(gameObject.GetComponent<RectTransform>(), 0, 0.5f).setOnComplete(DestroyGameobject);
        LeanTween.scale(gameObject.GetComponent<RectTransform>(), new Vector3(0, 0, 0), 0.4f);
    }
    private void Fade()
    {
        
    }

    private void DestroyGameobject()
    {
        Destroy(gameObject);
    }
}
