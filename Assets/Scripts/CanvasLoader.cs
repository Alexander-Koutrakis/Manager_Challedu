﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasLoader : MonoBehaviour
{
    [SerializeField]
    private Image fadeImage=null;
    [SerializeField]
    private Canvas targetCanvas=null;
    // Start is called before the first frame update
    public static CanvasLoader Instance;
    private void Start()
    {
        Instance = this;
        //  FadeTo(targetCanvas);
        LeanTween.moveLocalX(fadeImage.gameObject, -2500, 0.5f);
    }


    public void FadeTo(Canvas canvas)
    {
        targetCanvas = canvas;
        LeanTween.moveLocalX(fadeImage.gameObject, 100, 0.5f).setOnComplete(WaitForReset);
        Audio_Manager.Instance.Play_Sound("Fade");
    }

    private void WaitForReset()
    {              
        GameMaster.Instance.LoadCanvas(targetCanvas);
        LeanTween.moveLocalX(fadeImage.gameObject, 100, 0.5f).setOnComplete(GameMasterLoad);       
    }

    private void GameMasterLoad()
    {
        GameMaster.Instance.DelayedExpAdded();
        Cover_Back_Image.Instance.HideImage();
        LeanTween.moveLocalX(fadeImage.gameObject, -2500, 0.5f);
    }

   
}
