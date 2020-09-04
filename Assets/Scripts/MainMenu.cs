using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private string sceneName = "Office";
   public void StartGame()
    {
        SaveSystem.DeleteSave();
        SceneManager.LoadScene(sceneName);
    }

    public void QuitGame() {

        Application.Quit();
    }
}
