using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Campain_Plan : MonoBehaviour
{
    public static Campain_Plan Instance;
    private int[] campaingStars = new int[6];
    private Campaing_Strategy[] campaing_Strategies;
    public int stars = 5;
    private int maxStars = 5;


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
       // GameMaster.Instance.CampaignStars[index] = campaing_Strategy.stars;
    }

    public void StartCampaing()
    {
        if(stars > 0)
        {
            Debug.Log("Use All the Stars first");
            // force the player to use all the stars
        }
        else
        {
            ChangePlayerCampaing();
            GameMaster.Instance.StartCampaign();
        }
    }
}
