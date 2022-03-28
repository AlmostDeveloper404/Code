using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewWarrior",menuName ="Item/Warrior")]
public class WarriorSO : ScriptableObject
{
    public Sprite LockedIcon;
    public Sprite UnlockedIcon;

    public string Name;
    public string Description;

    public int Cost;
    public int Capacity;
    public int Attack;
    public int Defence;

    public int LevelNeeded;

    public float TimeToCreate;
}
