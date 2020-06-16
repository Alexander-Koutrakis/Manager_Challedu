using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Offer_Tab_Group : MonoBehaviour
{
   public void CheckChildrent()
    {
        int childrentNum = 0;
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            if (gameObject.transform.GetChild(i).gameObject.activeInHierarchy)
            {
                childrentNum++;
            }
        }

        if (childrentNum == 0)
        {
            gameObject.SetActive(false);
        }
    }
}
