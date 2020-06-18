using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using JetBrains.Annotations;
using UnityEngine;

public class Offer_Tab_Controller : MonoBehaviour
{
    public List<Offer> PreferedOffers = new List<Offer>();
    private List<Offer_Manager> offer_Managers = new List<Offer_Manager>();
    public List<Offer_Manager> used_Managers = new List<Offer_Manager>();
    public static Offer_Tab_Controller Instance;
    public RectTransform groupTab;
    int tweenID;
    int currentTabIndex=19;
    public Vector3 LeftPos;
    public Vector3 CentralPos;
    public Vector3 RightPos;
    private IEnumerator coroutine1;
    private IEnumerator coroutine2;
    private void Awake()
    {
        Instance = this;
        foreach(Offer_Manager offer_Manager in GetComponentsInChildren<Offer_Manager>())
        {
            offer_Managers.Add(offer_Manager);
        }
    }

    private void Start()
    {
        FillOfferManagers();
        LookForEmptyTabs();
        
               
        foreach (Offer_Manager offer_Manager in offer_Managers)
        {
            if (offer_Manager.offer != null)
            {
                offer_Manager.SetOfferValues();
            }
        }

     
    }

    public void LookForEmptyTabs()
    {
        foreach(Offer_Manager offer_Manager in offer_Managers)
        {
            if (offer_Manager.offer == null)
            {
                offer_Manager.gameObject.SetActive(false);
            }
           
        }
    }

    public void FillOfferManagers()
    {
        for(int i = 0; i < PreferedOffers.Count; i++)
        {
            offer_Managers[i].offer = PreferedOffers[i];
            used_Managers.Add(offer_Managers[i]);
        }
    }

    public void NextOfferTab() {
      
        LeanTween.moveLocalX(used_Managers[currentTabIndex].gameObject, LeftPos.x, 0.5f);

        currentTabIndex++;
        if (currentTabIndex >= used_Managers.Count)
        {
            currentTabIndex = 0;
        }

        used_Managers[currentTabIndex].gameObject.transform.localPosition = RightPos;

        LeanTween.moveLocalX(used_Managers[currentTabIndex].gameObject, CentralPos.x, 0.5f);
        used_Managers[currentTabIndex].OpenOfferTab();
    }


    public void PrevOfferTab()
    {

        LeanTween.moveLocalX(used_Managers[currentTabIndex].gameObject, RightPos.x, 0.5f);
        currentTabIndex--;
        if (currentTabIndex < 0)
        {
            Debug.Log("Here");
            currentTabIndex = used_Managers.Count-1;
        }

        used_Managers[currentTabIndex].gameObject.transform.localPosition = LeftPos;

        LeanTween.moveLocalX(used_Managers[currentTabIndex].gameObject, CentralPos.x, 0.5f);
        used_Managers[currentTabIndex].OpenOfferTab();

    }

    private IEnumerator MoveToPosition(Vector3 pos, GameObject obj)
    {
        while (Vector3.Distance(obj.transform.localPosition, pos) > 0.05f)
        {
            obj.transform.localPosition = Vector3.Lerp(obj.transform.localPosition, pos, Time.deltaTime);
            yield return null;
        }

        used_Managers[currentTabIndex].OpenOfferTab();
    }   
}

   
