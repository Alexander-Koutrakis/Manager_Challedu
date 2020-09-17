using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro_Focus_Animation : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float duration = 5f;
    private void OnEnable()
    {
        // LeanTween.scale(gameObject, new Vector3(1.3f, 1.3f, 1), 0.5f).setLoopPingPong();
        //LeanTween.moveX(gameObject,1,0.5f).setLoopPingPong();
        StartCoroutine(MoveRight());
    }
  

   
    private void OnDisable()
    {
        CloseAnimation();
    }

    public void CloseAnimation()
    {
        LeanTween.scale(gameObject, new Vector3(0, 0, 0), 1);
    }


    private IEnumerator MoveRight()
    {

        
        while (duration > 0)
        {
            transform.Translate(Vector3.right);
            duration--; ;
            yield return new WaitForSeconds(0.1f);
        }

        while (duration > -5)
        {
            transform.Translate(Vector3.left);
            duration--; ;
            yield return new WaitForSeconds(0.1f);
        }

        StartCoroutine(MoveRight());
    }
}
