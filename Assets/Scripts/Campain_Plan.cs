﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Campain_Plan : MonoBehaviour
{
    public static Campain_Plan Instance;
    public int[] campaingStars = new int[6];
    public Campaing_Strategy[] campaing_Strategies;
    public int stars = 5;
    public int maxStars = 5;


    private void Start()
    {
        Instance = this;
        campaing_Strategies = GetComponentsInChildren<Campaing_Strategy>();
    }
    public void ChangePlayerCampaing()
    {
        for(int i = 0; i < campaingStars.Length; i++)
        {
            GameMaster.Instance.CampaignStars[i] = campaingStars[i];
        }
    }

    public void GetStars(Campaing_Strategy campaing_Strategy)
    {
        int index = System.Array.IndexOf(campaing_Strategies, campaing_Strategy);
        Debug.Log(index);
        campaingStars[index]= campaing_Strategy.stars;
        GameMaster.Instance.CampaignStars[index] = campaing_Strategy.stars;
    }
}