using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PausePanel : MonoBehaviour
{
    public void ExitGame()
    {
        Application.Quit();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    public void PauseGame()
    {
        StartCoroutine(DelayedPause());
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
    

    private IEnumerator DelayedPause()
    {
        yield return new WaitForSeconds(1f);
        Time.timeScale = 0;
    }

   
}
