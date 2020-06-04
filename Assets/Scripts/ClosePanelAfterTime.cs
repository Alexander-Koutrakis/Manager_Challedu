using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ClosePanelAfterTime : MonoBehaviour
{
    public RectTransform targetPanel;
    public float waitingTime;
    private IEnumerator ClosePanelAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        targetPanel.gameObject.SetActive(false);
    }

    public void CloseButton()
    {
        StartCoroutine(ClosePanelAfter(waitingTime));
    }
}
