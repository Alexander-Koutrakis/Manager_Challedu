using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Offer", menuName ="Offer")]
public class Offer : ScriptableObject
{
    public int OfferID;
    public int budgetCost;    
    public int productCost;
    public int peopleCost;
    public float expiriencePoints;
    public string title_Text;
    public string main_Text;


    public float DurationInSec;
    public float[] GP;



    public float[] SDGs;

    public Sprite SDG1;
    public Sprite SDG2;
    public Sprite SDG3;


    

}
