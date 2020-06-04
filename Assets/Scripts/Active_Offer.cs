using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Active_Offer : MonoBehaviour
{
    public Offer offer;
    public float[] SDGscore;
    public float Duration;
    public float ReputationScore;
    public Image timerImage;


    public void StartTimer()
    {
        GetComponent<Active_Offer_Panel>().ActivePanel = true;
        GetComponent<Active_Offer_Panel>().ActivatePanel();
        timerImage = GetComponentInChildren<Image>();
        StartCoroutine(CountTimer());
    }

    private IEnumerator CountTimer() {
        float totalduration = Duration;
        while (Duration > 0)
        {
            Duration--;
            timerImage.fillAmount =1- Duration / totalduration;
            yield return new WaitForSeconds(1);
        }
        Player_Controller.player_Controller.AddSDGPoints(SDGscore);
        Player_Controller.player_Controller.AddReputation(ReputationScore);

        timerImage.fillAmount = 0;
        GetComponent<Active_Offer_Panel>().ActivePanel = false;
        GetComponent<Active_Offer_Panel>().DeactivatePanel();
       Destroy(this);
    }

}
