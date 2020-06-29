using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class GameData 
{
    public float PlayerReputation;
    public int PlayerBudget;
    public int PlayerPeople;
    public int PlayerProduct;
    public int[] ActiveOffersIDs;
    public int[] OfferManagerIDs;
    public int[] OfferManagerIDsBudget;
    public int[] OfferManagerIDsPeople;
    public int[] OfferManagerIDsProduct;

    public GameData(GameMaster gamemaster, Player player) {
        PlayerReputation = player.Expirience;
        PlayerBudget = player.budget;         
    }
}
