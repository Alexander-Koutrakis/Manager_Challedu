using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasLoader : MonoBehaviour
{
    [SerializeField]
    private Image fadeImage;
    [SerializeField]
    private Canvas targetCanvas;
    // Start is called before the first frame update
    public void FadeTo(Canvas canvas)
    {
        targetCanvas = canvas;
        LeanTween.moveLocalX(fadeImage.gameObject, 0, 0.5f).setOnComplete(GameMasterLoad);
    }

    private void GameMasterLoad()
    {
        GameMaster.Instance.LoadCanvas(targetCanvas);
        LeanTween.moveLocalX(fadeImage.gameObject, -2500, 0.5f);
    }
}
