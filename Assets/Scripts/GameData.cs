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

    public GameData(GameMaster gamemaster, Player_Controller player_Controller) {
        PlayerReputation = player_Controller.Reputation;
        PlayerBudget = player_Controller.budget;
        PlayerPeople = player_Controller.people;
        PlayerProduct = player_Controller.products;

        ActiveOffersIDs = gamemaster.activeOffersIDs;

        OfferManagerIDs = new int[gamemaster.offerManagerIDs.GetLength(0)];
        OfferManagerIDsBudget = new int[gamemaster.offerManagerIDs.GetLength(0)];
        OfferManagerIDsPeople = new int[gamemaster.offerManagerIDs.GetLength(0)];
        OfferManagerIDsProduct = new int[gamemaster.offerManagerIDs.GetLength(0)];


        for (int i = 0; i < gamemaster.offerManagerIDs.GetLength(0); i++) {
            OfferManagerIDs[i] = gamemaster.offerManagerIDs[i, 0];
            OfferManagerIDsBudget[i] = gamemaster.offerManagerIDs[i, 1];
            OfferManagerIDsPeople[i] = gamemaster.offerManagerIDs[i, 2];
            OfferManagerIDsProduct[i] = gamemaster.offerManagerIDs[i, 3];
        }
        
    }
}
