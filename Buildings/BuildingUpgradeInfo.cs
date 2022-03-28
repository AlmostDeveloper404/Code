using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct BuildingUpgradeInfo
{
    public string Name;
    public Sprite BuildingSprite;
    public int Cost;
    public int BuildingLevel;
    public int PlayerLevel;
    public RewardForLevel RewardForLevel;
}
