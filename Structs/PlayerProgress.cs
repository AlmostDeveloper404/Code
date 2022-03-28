using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct PlayerProgress
{
    public int Gold;
    public int BlueBottles;
    public int RedBottles;
    public int GoldInMarket;
    public int MainBuilding, Market, Craft, Barrack, Pub;
    public int Level;
    public float Score;
    public int Villager, Swordman, Spearman, Archer, Bouncer;
    public int CurrentCapacity;
    public int[] WarriorsInQueue, WarriorsCreated;
}
