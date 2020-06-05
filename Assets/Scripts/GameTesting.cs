using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.UI;
using TMPro;
public class GameTesting : MonoBehaviour
{
    public RectTransform panel;
    public TMP_InputField BaseBudgetInput;
    public TMP_InputField BasePeopleInput;
    public TMP_InputField BaseProductsInput;
    public TMP_InputField BudgetInput;
    public TMP_InputField PeopleInput;
    public TMP_InputField ProductsInput;


    public void RestartGame() {

        Destroy(GameMaster.gameMaster.gameObject);
        Destroy(Player_Controller.player_Controller.gameObject);
        GameMaster.NextRound = null;
        StopAllCoroutines();
        LeanTween.cancelAll();
        SceneManager.LoadScene(0);
    }

    public void ResourcesChanged() {
        Player_Controller.player_Controller.baseBudget = int.Parse(BaseBudgetInput.text);
        Player_Controller.player_Controller.basePeople= int.Parse(BasePeopleInput.text);
        Player_Controller.player_Controller.baseproducts = int.Parse(BaseProductsInput.text);
        Player_Controller.player_Controller.budget= int.Parse(BudgetInput.text);
        Player_Controller.player_Controller.people= int.Parse(PeopleInput.text);
        Player_Controller.player_Controller.products= int.Parse(ProductsInput.text);
        UI_Controller.ui_Controller.RefreshResourcesText();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
