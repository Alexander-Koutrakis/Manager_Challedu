using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Mathematics;
using Random = UnityEngine.Random;

public class Offer_Manager : MonoBehaviour
{
    public Offer offer;
    public TMP_Text title_Text;
    public TMP_Text main_Text;
    public TMP_Text budget_Text;
    public TMP_Text people_Text;
    public TMP_Text product_Text;
    private Offer_GPGraph offer_GPGraph;
    public bool ShownOffer = false;



    private void Awake()
    {
        InitializeValues();
        offer_GPGraph = GetComponentInChildren<Offer_GPGraph>();
    }

    private void InitializeValues()
    {
        TMP_Text[] tMP_Texts = GetComponentsInChildren<TMP_Text>();
        title_Text = tMP_Texts[0];
        main_Text= tMP_Texts[1];
        budget_Text= tMP_Texts[2];
        people_Text= tMP_Texts[3];
        product_Text= tMP_Texts[4];
    }

    public void SetOfferValues() {
        title_Text.text = offer.title_Text+" Offer ID : "+offer.OfferID;
        main_Text.text = offer.main_Text;
        budget_Text.text = offer.budgetCost.ToString();
        people_Text.text = offer.peopleCost.ToString();
        product_Text.text = offer.peopleCost.ToString();    
    }

    public void OpenOfferTab()
    {
        offer_GPGraph.ShowGraph(offer.GP);
        gameObject.transform.localScale = new Vector3(1, 1, 1);
    }

    public void CloseTab()
    {
        offer_GPGraph.HideGraph();
        gameObject.transform.localScale = new Vector3(0, 0, 0);
    }
}
