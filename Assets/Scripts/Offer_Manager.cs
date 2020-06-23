﻿using System.Collections;
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
    private Button budget50;
    private Button budget100;
    private Button budget130;
    private Button people50;
    private Button people100;
    private Button people130;
    private Button product50;
    private Button product100;
    private Button product130;
    private Button PayButton;
    private Offer_GPGraph offer_GPGraph;
    public bool ShownOffer = false;
    private int BudgetAmount;
    private int PeopleAmount;
    private int ProductAmount;


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
        GetButtons();
    }

    public void CloseTab()
    {
        offer_GPGraph.HideGraph();
        gameObject.transform.localScale = new Vector3(0, 0, 0);
    }

   


    private void GetButtons()
    {

        budget50 = GetComponentsInChildren<Button>()[0];
        if (offer.budgetCost * 0.5f > Player.Instance.budget)
        {
            budget50.interactable = false;
            //swap sprite
        }else if(offer.budgetCost * 0.5f <= Player.Instance.budget)
        {
            budget50.interactable = true;
            //swap sprite
        }


        budget100 = GetComponentsInChildren<Button>()[1];
        if (offer.budgetCost * 1f > Player.Instance.budget)
        {
            budget100.interactable = false;
            //swap sprite
        }else if(offer.budgetCost * 1f <= Player.Instance.budget)
        {
            budget100.interactable = true;
            //swap sprite
        }


        budget130 = GetComponentsInChildren<Button>()[2];
        if (offer.budgetCost * 1.3f > Player.Instance.budget)
        {
            budget130.interactable = false;
            //swap sprite
        }
        else if(offer.budgetCost * 1.3f <= Player.Instance.budget)
        {
            budget130.interactable = true;
            //swap sprite
        }

        people50 = GetComponentsInChildren<Button>()[3];
        if (offer.peopleCost * 0.5f > Player.Instance.people)
        {
            people50.interactable = false;
            // swap sprite
        }else if (offer.peopleCost * 0.5f <= Player.Instance.people)
        {
            people50.interactable = true;
            // swap sprite
        }

        people100 = GetComponentsInChildren<Button>()[4];
        if (offer.peopleCost * 1f > Player.Instance.people)
        {
            people100.interactable = false;
            //swap sprite
        }else if (offer.peopleCost * 1f <= Player.Instance.people)
        {
            people100.interactable = true;
            //swap sprite
        }

        people130 = GetComponentsInChildren<Button>()[5];
        if (offer.peopleCost * 1.3f > Player.Instance.people)
        {
            people130.interactable = false;
            //swap sprite
        }else if (offer.peopleCost * 1.3f <= Player.Instance.people)
        {
            people130.interactable = true;
            //swap sprite
        }

        product50 =GetComponentsInChildren<Button>()[6];
        if (offer.productCost * 0.5f > Player.Instance.products)
        {
            product50.interactable = false;
            //swap sprite
        }
        else if (offer.productCost * 0.5f <= Player.Instance.products)
        {
            product50.interactable = true;
            //swap sprite
        }

        product100 = GetComponentsInChildren<Button>()[7];
        if (offer.productCost * 1f > Player.Instance.products)
        {
            product100.interactable = false;
            //swap sprite
        }else if (offer.productCost * 1f <= Player.Instance.products)
        {
            product100.interactable = true;
            //swap sprite
        }

        product130 = GetComponentsInChildren<Button>()[8];
        if (offer.productCost * 1.3f > Player.Instance.products)
        {
            product130.interactable = false;
            //swap sprite
        }
        else if (offer.productCost * 1.3f <= Player.Instance.products)
        {
            product130.interactable = true;
            //swap sprite
        }

        PayButton = GetComponentsInChildren<Button>()[9];
    }


    public void PayBudget50()
    {
        BudgetAmount = Mathf.RoundToInt(offer.budgetCost * 0.5f);
        // swap other buttons
    }

    public void PayBudget100()
    {
        BudgetAmount = Mathf.RoundToInt(offer.budgetCost * 1.0f);
        // swap other buttons
    }

    public void PayBudget130()
    {
        BudgetAmount = Mathf.RoundToInt(offer.budgetCost * 1.3f);
        // swap other buttons
    }

    public void PayPeople50()
    {
        PeopleAmount = Mathf.RoundToInt(offer.peopleCost * 0.5f);
        // swap other buttons
    }

    public void PayPeople100()
    {
        PeopleAmount = Mathf.RoundToInt(offer.peopleCost * 1f);
        // swap other buttons
    }

    public void PayPeople130()
    {
        PeopleAmount = Mathf.RoundToInt(offer.peopleCost * 1.3f);
        // swap other buttons
    }

    public void PayProducts50()
    {
        ProductAmount = Mathf.RoundToInt(offer.productCost * 0.5f);
        // swap other buttons
    }

    public void PayProducts100()
    {
        ProductAmount = Mathf.RoundToInt(offer.productCost * 1.0f);
        // swap other buttons
    }

    public void PayProducts130()
    {
        ProductAmount = Mathf.RoundToInt(offer.productCost * 1.3f);
        // swap other buttons
    }





}
