using UnityEngine;

public class Barrack : Building
{
    [Header("Army capacity")]
    [Tooltip("Each barrack level capacity")]
    [SerializeField] private int[] _allLevelsArmyCapacity;

    public override void Start()
    {
        if (!PlayerStats.Instance.GetPlayerProgress().HasValue) return;

        BuildingLevel = PlayerStats.Instance.GetPlayerProgress().Value.Barrack;
        base.Start();
        BuildingProgress.SetBarrackLevel(BuildingLevel);
        ArmyManager.Instance.SetMaxCapacity(_allLevelsArmyCapacity[BuildingLevel]);
    }

    public override void UpgradeBuilding()
    {
        base.UpgradeBuilding();
        BuildingProgress.SetBarrackLevel(BuildingLevel);
        ArmyManager.Instance.SetMaxCapacity(_allLevelsArmyCapacity[BuildingLevel]);
        SaveLoadProgress.SaveData();
    }
}
