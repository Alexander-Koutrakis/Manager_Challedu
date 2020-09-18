using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private string sceneName = "Office";
    [SerializeField]
    private RectTransform fadeImage = null;

   public void StartGame()
    {
        SaveSystem.DeleteSave();
        
        LeanTween.moveLocalX(fadeImage.gameObject, 100, 0.5f).setOnComplete(Loadnextscene);
    }



    private void Loadnextscene()
    {
        SceneManager.LoadScene(sceneName);
    }



    public void QuitGame() {

        Application.Quit();
    }
}
