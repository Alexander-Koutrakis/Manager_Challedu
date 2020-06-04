using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Active_Offer_Panel : MonoBehaviour
{
    public bool ActivePanel = false;
    public GameObject PopUp;
    private Vector3 DeactivePosition;

    public void ActivatePanel()
    {
        Vector3 ActivePosition = new Vector3(0, 0, 0);
        var sec = LeanTween.sequence();
        sec.append(LeanTween.moveLocalY(gameObject, 0, 0.5f));
    }

    public void DeactivatePanel() {
        CreatePopUP();       
        var sec = LeanTween.sequence();
        sec.append(LeanTween.moveLocalY(gameObject,0, 0.5f));

    }


    private void CreatePopUP() {
        GameObject popUP = Instantiate(PopUp, transform.position, Quaternion.identity,transform.parent.parent);
        popUP.GetComponent<PopUp>().PopUptext = GetComponent<Active_Offer>().ReputationScore.ToString("F1");
    }
}
