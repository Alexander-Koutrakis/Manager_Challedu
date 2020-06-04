using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PopUp : MonoBehaviour
{
    public string PopUptext;

    private void Start()
    {
        PopUptext = "+ " + PopUptext;
        GetComponent<TMP_Text>().text = PopUptext;
        StartCoroutine(PoPUpLifeTime());
    }


    private void FixedUpdate()
    {
        transform.Translate(Vector3.down * Time.deltaTime *0.5f);
    }

    private IEnumerator PoPUpLifeTime() {
       
        yield return new WaitForSeconds(5);        
        Destroy(gameObject);
    }

}
