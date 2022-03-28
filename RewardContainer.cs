using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardContainer : Singleton<RewardContainer>
{
    [SerializeField] private RewardTemplate[] _allTemplates;

    public void SetupRewards(BuildingUpgradeInfo buildingUpgradeInfo)
    {
        for (int i = 0; i < _allTemplates.Length; i++)
        {
            if (i < buildingUpgradeInfo.RewardForLevel.Rewards.Length)
            {
                _allTemplates[i].gameObject.SetActive(true);
                _allTemplates[i].Setup(buildingUpgradeInfo.RewardForLevel.Rewards[i]);
            }
        }
    }
}
