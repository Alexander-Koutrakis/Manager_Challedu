using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCampaing_Panel : MonoBehaviour
{
    public static NewCampaing_Panel Instance;
    [SerializeField]
    private Transform[] star_buckets = new Transform[6];
    private int[] campaingStars = new int[6];
   


    public void ChangePlayerCampaing()
    {
        for (int i = 0; i < campaingStars.Length; i++)
        {
            GameMaster.Instance.CampaignStars[i] = campaingStars[i];
            PieGraph.Instance.AddStrategySprites();
        }
    }

    public void GetStars()
    {
        for(int i = 0; i < star_buckets.Length; i++)
        {
            foreach(StarDragNDrop sDnD in star_buckets[i].GetComponentsInChildren<StarDragNDrop>())
            {
                campaingStars[i]++;
            }
        }
    }
}
