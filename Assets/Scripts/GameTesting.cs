using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.UI;
public class GameTesting : MonoBehaviour
{
    public RectTransform panel;
    public void RestartGame() {

        Destroy(GameMaster.gameMaster.gameObject);
        Destroy(Player_Controller.player_Controller.gameObject);
        GameMaster.NextRound = null;
        StopAllCoroutines();
        LeanTween.cancelAll();
        SceneManager.LoadScene(0);
    }

    

    public void QuitGame()
    {
        Application.Quit();
    }
}
