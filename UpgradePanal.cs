using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UpgradePanal : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private Image _buildingIcon;
    [SerializeField] private TMP_Text _titleText, _costText, _buildingLevelText, _playerLevelText;
    [SerializeField] private Button _upgradeButton;
    [SerializeField] private Image _cost, _buildingLevel, _level;
    [SerializeField] private Sprite _redButtonFill, _grayButtonFill;

    private Building _currentBuilding;



    public void Open(Building building)
    {
        _currentBuilding = building;
        BuildingUpgradeInfo buildingUpgradeInfo = building.GetBuildingInfo();

        _buildingIcon.sprite = buildingUpgradeInfo.BuildingSprite;
        _titleText.text = buildingUpgradeInfo.Name;
        _costText.text = $"Cost: {buildingUpgradeInfo.Cost}";
        _buildingLevelText.text = $"Level: {buildingUpgradeInfo.BuildingLevel}";
        _playerLevelText.text = $"Exp: {buildingUpgradeInfo.PlayerLevel}";

        RewardContainer.Instance.SetupRewards(buildingUpgradeInfo);

        SetupPanal(buildingUpgradeInfo);
    }

    public void Upgrade()
    {
        _currentBuilding.UpgradeBuilding();
        gameObject.SetActive(false);
    }

    private void SetupPanal(BuildingUpgradeInfo buildingUpgradeInfo)
    {
        _cost.sprite = GameResources.GetGoldAmount() >= buildingUpgradeInfo.Cost ? _redButtonFill : _grayButtonFill;
        _buildingLevel.sprite = BuildingProgress.GetCurrentMainBuildingLevel() >= buildingUpgradeInfo.BuildingLevel ? _redButtonFill : _grayButtonFill;
        _level.sprite = PlayerStats.Instance.GetPlayerLevel() >= buildingUpgradeInfo.PlayerLevel ? _redButtonFill : _grayButtonFill;
        _upgradeButton.interactable = CheckUpgradeButtonState(buildingUpgradeInfo) ? true : false;
    }

    private bool CheckUpgradeButtonState(BuildingUpgradeInfo buildingUpgradeInfo)
    {
        if (GameResources.GetGoldAmount() >= buildingUpgradeInfo.Cost &&
            BuildingProgress.GetCurrentMainBuildingLevel() >= buildingUpgradeInfo.BuildingLevel &&
            PlayerStats.Instance.GetPlayerLevel() >= buildingUpgradeInfo.PlayerLevel
            )
        {
            return true;
        }
        else
        {
            return false;
        }

    }




}
