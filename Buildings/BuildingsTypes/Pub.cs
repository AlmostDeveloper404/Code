using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pub : Building
{
    public override void Start()
    {
        if (!PlayerStats.Instance.GetPlayerProgress().HasValue) return;

        BuildingLevel = PlayerStats.Instance.GetPlayerProgress().Value.Pub;
        base.Start();
        BuildingProgress.SetPubLevel(BuildingLevel);
    }

    public override void UpgradeBuilding()
    {
        base.UpgradeBuilding();
        BuildingProgress.SetPubLevel(BuildingLevel);
        SaveLoadProgress.SaveData();
    }
}
