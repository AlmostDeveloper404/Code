using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class MarketUI : MonoBehaviour
{
    [SerializeField] private Image _fillImage;
    [SerializeField] private TMP_Text _filledPercent;
    [SerializeField] private TMP_Text _amountInStorage;

    private void OnEnable()
    {
        UpdateUI(Market.Instance.GetCurrentGoldCapacity(),Market.Instance.GetCurrentGoldFromMarket());
        Market.OnGoldInMarketChanged += UpdateUI;
    }

    public void UpdateUI(float marketCapacity,float currentGold)
    {
        float filledAmount = currentGold / marketCapacity;

        _fillImage.fillAmount = filledAmount;
        _filledPercent.text = $"{filledAmount * 100}%";
        _amountInStorage.text = $"{currentGold}/{marketCapacity}";
    }

    private void OnDisable()
    {
        Market.OnGoldInMarketChanged -= UpdateUI;
    }
}
