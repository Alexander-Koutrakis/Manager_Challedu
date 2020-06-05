using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public int budget=1000;
    public int people=10;
    public int products=100;
    public float Reputation=1;
    public static Player_Controller player_Controller;
    public float[] SDGs=new float[17];
    public int baseBudget = 1000;
    public int basePeople = 10;
    public int baseproducts = 100;

    private void Awake()
    {
        if (player_Controller == null)
        {
            player_Controller = this;
        }
        else
        {
            Destroy(gameObject);
        }
        InitializeSDGs();

    }

    public void AddSDGPoints(float[] SDGPoints)
    {
        
        for(int i = 0; i < SDGs.Length; i++)
        {
            SDGs[i] += SDGPoints[i];
        }
        if(GameMaster.gameMaster.pieGraph_Small!=null)
        GameMaster.gameMaster.pieGraph_Small.GetValues();
    }

    private void InitializeSDGs() {

        for(int i = 0; i < SDGs.Length; i++)
        {
            SDGs[i] = 0.001f;
        }
    }

    public void AddReputation(float i) {
        Reputation += i;
        UI_Controller.ui_Controller.RefreshResourcesText();
        
    }

    public void RenewResources() {
        budget += Mathf.RoundToInt(baseBudget * Reputation);
        people+= Mathf.RoundToInt(basePeople * Reputation);
        products+= Mathf.RoundToInt(baseproducts * Reputation);
        UI_Controller.ui_Controller.RefreshResourcesText();
    }
}
