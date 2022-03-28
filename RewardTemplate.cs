using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class RewardTemplate : MonoBehaviour
{
    [SerializeField] private Image _rewardIcon;
    [SerializeField] private TMP_Text _amount;

    public void Setup(Reward rewardForLevel)
    {
        _rewardIcon.sprite = rewardForLevel.Icon;
        _amount.text = rewardForLevel.Amount.ToString();
    }
}
