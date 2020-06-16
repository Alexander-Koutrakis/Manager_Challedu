using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    public int budget;
    public int people;
    public int products;
    public float Reputation;
    public float[] SDGs;

    private void Awake()
    {
        Instance = this;
    }
}
