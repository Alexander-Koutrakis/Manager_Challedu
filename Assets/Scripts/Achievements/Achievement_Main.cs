using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Achievement_Main : MonoBehaviour
{
    public bool activated = false;
    public abstract void CreateAchievement();
    public abstract void Requirements();

    public abstract void Rewards();
}
