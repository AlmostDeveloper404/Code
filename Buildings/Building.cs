using UnityEngine;
using UnityEngine.Events;

public class Building : SelectableObject
{
    public UnityEvent OnBuildingSelected;
    public UnityEvent OnBuildingDeselect;

    [Header("Building Prefabs")]
    [Tooltip("Represents prefab for each building level")]
    [SerializeField] protected GameObject[] _allLevels;


    [Header("Cost")]
    [Tooltip("Cost for building upgrade")]
    [SerializeField] protected int[] _allLevelsCost;


    [Header("Player level")]
    [Tooltip("Player progression to be able to build")]
    [SerializeField] protected int[] _allLevelNeeded;

    [Header("Reward")]
    [Tooltip("Reward for upgrading")]
    [SerializeField] protected RewardForLevel[] _allRewards;

    [Header("Building Info")]
    [Space(15)]
    [SerializeField] protected int BuildingLevel;
    [SerializeField] private string _buildingName;
    [SerializeField] private Sprite _buildingSprite;

    private BuildingUpgradeInfo _buildingInfo;

    public virtual void Start()
    {
        for (int i = 0; i < _allLevels.Length; i++)
        {
            _allLevels[i].SetActive(i == BuildingLevel);
        }
    }

    public BuildingUpgradeInfo GetBuildingInfo()
    {
        _buildingInfo = new BuildingUpgradeInfo
        {
            BuildingSprite = _buildingSprite,
            Name = _buildingName,
            BuildingLevel = BuildingLevel,
            Cost = _allLevelsCost[BuildingLevel],
            PlayerLevel = _allLevelNeeded[BuildingLevel],
            RewardForLevel = _allRewards[BuildingLevel]
        };

        return _buildingInfo;
    }

    public virtual void UpgradeBuilding()
    {
        GameResources.SpendGold(_allLevelsCost[BuildingLevel]);
        RewardManager.Instance.AddReward(_allRewards[BuildingLevel]);

        BuildingLevel++;
        for (int i = 0; i < _allLevels.Length; i++)
        {
            _allLevels[i].SetActive(i == BuildingLevel);
        }

    }


    public override void Select()
    {
        OnBuildingSelected?.Invoke();
    }

    public override void Deselect()
    {
        OnBuildingDeselect?.Invoke();
    }
}
