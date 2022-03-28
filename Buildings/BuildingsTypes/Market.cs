using System;
using UnityEngine;

public class Market : Building
{
    public static event Action<float,float> OnGoldInMarketChanged;

    [SerializeField]private float _addingAmount = 1f;
    [SerializeField] private float _timeToGetGold=1f;

    private float _marketCapacity=50;
    private float _currentGoldInMarket;

    private float _timer=0;

    public override void Start()
    {
        
        if (PlayerStats.Instance.GetPlayerProgress()==null) return;

        BuildingLevel = PlayerStats.Instance.GetPlayerProgress().Value.Market;
        base.Start();
        BuildingProgress.SetMarketLevel(BuildingLevel);

        GameResources.AddGold(PlayerStats.Instance.GetPlayerProgress().Value.Gold);
        GameResources.AddBlueBottles(PlayerStats.Instance.GetPlayerProgress().Value.BlueBottles);
        GameResources.AddRedBottles(PlayerStats.Instance.GetPlayerProgress().Value.RedBottles);

        AddGoldToMarket(PlayerStats.Instance.GetPlayerProgress().Value.GoldInMarket);
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _timeToGetGold)
        {
            if (_marketCapacity <= _currentGoldInMarket) return;
            _timer = 0;
            AddGoldToMarket(_addingAmount);
        }
    }

    public override void UpgradeBuilding()
    {
        base.UpgradeBuilding();
        BuildingProgress.SetMarketLevel(BuildingLevel);
        SaveLoadProgress.SaveData();
    }

    public void AddGoldToMarket(float amount)
    {   
        _currentGoldInMarket += amount;
        if (_currentGoldInMarket>_marketCapacity) _currentGoldInMarket = _marketCapacity;

        OnGoldInMarketChanged?.Invoke(_marketCapacity, _currentGoldInMarket);
    }

    [ContextMenu("Collect")]
    public void CollectTaxes()
    {
        GameResources.AddGold((int)_currentGoldInMarket);
        _currentGoldInMarket = 0;
        OnGoldInMarketChanged?.Invoke(_marketCapacity, _currentGoldInMarket);
        SaveLoadProgress.SaveData();
    }

    public override float GetCurrentGoldFromMarket() => _currentGoldInMarket;

    public override float GetCurrentGoldCapacity() => _marketCapacity;

}
