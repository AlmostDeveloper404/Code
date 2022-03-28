using UnityEngine;
using TMPro;

public class CurrencyHolder : MonoBehaviour
{
    [Header("Currency")]
    [SerializeField] private TMP_Text _goldText;
    [SerializeField] private TMP_Text _blueBottlesText;
    [SerializeField] private TMP_Text _redBottlesText;

    private void OnEnable()
    {
        UpdateCurrency();

        GameResources.OnGoldAmountChanged += UpdateCurrency;
        GameResources.OnBlueBottlesChanged += UpdateCurrency;
        GameResources.OnRedBottlesChanged += UpdateCurrency;
    }

    public void UpdateCurrency()
    {
        _goldText.text = GameResources.GetGoldAmount().ToString();
        _blueBottlesText.text = GameResources.GetBlueBottles().ToString();
        _redBottlesText.text = GameResources.GetRedBottles().ToString();
    }

    private void OnDisable()
    {
        GameResources.OnGoldAmountChanged -= UpdateCurrency;
        GameResources.OnBlueBottlesChanged -= UpdateCurrency;
        GameResources.OnRedBottlesChanged -= UpdateCurrency;
    }
}
