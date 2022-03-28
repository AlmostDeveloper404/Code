using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardManager : Singleton<RewardManager>
{
    public void AddReward(RewardForLevel reward)
    {

        for (int i = 0; i < reward.Rewards.Length; i++)
        {
            Reward newReward = reward.Rewards[i];
            TypeOfReward typeOfReward = newReward.TypeOfReward;

            switch (typeOfReward)
            {
                case TypeOfReward.Gold:
                    GameResources.AddGold(newReward.Amount);
                    break;
                case TypeOfReward.Score:
                    PlayerStats.Instance.AddScore(newReward.Amount);
                    break;
                case TypeOfReward.Upgrading:
                    break;
                case TypeOfReward.Materials:
                    break;
                case TypeOfReward.NewUnits:
                    break;
            }
            
        }
    }
}
