using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NewCampaing_Panel : MonoBehaviour
{
    public static NewCampaing_Panel Instance;
    [SerializeField]
    private Transform[] star_buckets = new Transform[6];
    private int[] campaingStars = new int[6];
    [SerializeField]
    private Image LockCampaingImage = null;
 
    public Button StartCampaingButton = null;


    private void Awake()
    {
        Instance = this;
        ResetCampaing();
    }

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
            campaingStars[i] = star_buckets[i].GetComponentsInChildren<StarDragNDrop>().Length;
        }
        CampaingReady();
    }

    private void UnlockCampaing()
    {
        LockCampaingImage.gameObject.SetActive(false);
    }

    public void ResetCampaing()
    {
        GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 12, 0);
        UnlockCampaing();

        foreach (StarDropSpot starDropSpot in GetComponentsInChildren<StarDropSpot>())
        {
            starDropSpot.ResetDropSpot();
        }

        foreach(StarDragNDrop star in GetComponentsInChildren<StarDragNDrop>())
        {
            star.ResetStar();
        }

    }

    private void LockCampaing()
    {
        LockCampaingImage.gameObject.SetActive(true);
        StartCampaingButton.interactable = false;
    }

    private void CampaingReady()
    {

        int total = 0;
        foreach(int i in campaingStars)
        {
            total += i;
        }

        if (total >= 3)
        {
            StartCampaingButton.interactable = true;
        }
        else
        {
            StartCampaingButton.interactable = false;
        }
    }


    public void StartCampaing() { 
  
            ChangePlayerCampaing();
            GameMaster.Instance.StartCampaign();
            LockCampaing();
    }
}
