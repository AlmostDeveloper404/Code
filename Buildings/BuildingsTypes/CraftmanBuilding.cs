using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftmanBuilding : Building
{
    public override void Start()
    {
        if (!PlayerStats.Instance.GetPlayerProgress().HasValue) return;

        BuildingLevel = PlayerStats.Instance.GetPlayerProgress().Value.Craft;
        base.Start();
        BuildingProgress.SetCraftLevel(BuildingLevel);
    }

    public override void UpgradeBuilding()
    {
        base.UpgradeBuilding();
        BuildingProgress.SetCraftLevel(BuildingLevel);
        SaveLoadProgress.SaveData();
    }
}
