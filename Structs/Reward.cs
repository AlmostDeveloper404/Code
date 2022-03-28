using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TypeOfReward
{
    Gold,
    Score,
    Upgrading,
    NewUnits,
    Materials,

}

[System.Serializable]
public struct Reward
{
    public Sprite Icon;
    public int Amount;
    public bool IsCountable;
    public TypeOfReward TypeOfReward;

}
