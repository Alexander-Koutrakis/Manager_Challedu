using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UI_Controller : MonoBehaviour
{
    public RectTransform NextRoundButton;
    public TMP_Text BudgetText;
    public TMP_Text PeopleText;
    public TMP_Text ProductsText;
    public TMP_Text ReputationText;
    public static UI_Controller ui_Controller;

    public void StartNextRoundAnimation()
    {
        LeanTween.rotateAround(NextRoundButton,Vector3.forward, -1440, 1f).setOnComplete(stopNextRoundAnimation);
    }

    private void stopNextRoundAnimation() {
        NextRoundButton.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        GameMaster.gameMaster.NextRoundButton();
    }

    public void RefreshResourcesText()
    {
        BudgetText.text = Player_Controller.player_Controller.budget.ToString();
        PeopleText.text = Player_Controller.player_Controller.people.ToString();
        ProductsText.text = Player_Controller.player_Controller.products.ToString();
        ReputationText.text = Player_Controller.player_Controller.Reputation.ToString("F1");
        RerfreshCanvas();
    }

    private void Awake()
    {
        if (ui_Controller == null)
        {
            ui_Controller = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        RefreshResourcesText();
        GameMaster.gameMaster.NextRoundButton();
    }


    private void RerfreshCanvas() {
        GetComponentInParent<Canvas>().worldCamera = Camera.main;
    }
}
