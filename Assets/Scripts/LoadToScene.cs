using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadToScene : MonoBehaviour
{
    private RectTransform LoadingImage;
    public Vector3 LoadScreenOnPosition;
    public Vector3 LoadScreenOffPosition;
    public Sprite CoverInto;
    public Sprite CoverOutro;
    public int sceneINT;

    void Start()
    {
        LoadingImage = GetComponent<RectTransform>();
        OpenScene();
    }

    public void OpenScene() {

        GetComponent<Image>().sprite = CoverOutro;
        LeanTween.move(LoadingImage, LoadScreenOffPosition, 1f);
       
    }


    public void LoadScene() {
        GetComponent<Image>().sprite = CoverInto;
        LeanTween.move(LoadingImage, LoadScreenOnPosition, 1f).setOnComplete(StartLoading);
    }

    private void StartLoading() {
        SceneManager.LoadScene(sceneINT);
        RefreshCanvas();
        GameMaster.gameMaster.SaveGame();
        Resources.UnloadUnusedAssets();       
    }

    private void RefreshCanvas() {
        Canvas[] canvases = FindObjectsOfType<Canvas>();
        foreach (Canvas canvas in canvases) {
            canvas.worldCamera = Camera.main;
        }     
    }
}
