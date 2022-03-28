
public class MainBuilding : Building
{
    public override void Start()
    {
        if (!PlayerStats.Instance.GetPlayerProgress().HasValue) return;

        BuildingLevel = PlayerStats.Instance.GetPlayerProgress().Value.MainBuilding;
        base.Start();
        BuildingProgress.SetMainBuildingLevel(BuildingLevel);
    }

    public override void UpgradeBuilding()
    {
        base.UpgradeBuilding();
        BuildingProgress.SetMainBuildingLevel(BuildingLevel);
        SaveLoadProgress.SaveData();
    }
}
