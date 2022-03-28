using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameResourcesUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _currencyText;
    [SerializeField] private TMP_Text _blueBottlesAmount;
    [SerializeField] private TMP_Text _redBottlesAmount;

    private void Awake()
    {
        GameResources.OnBlueBottlesChanged += UpdateBlueBottlesAmount;
        GameResources.OnRedBottlesChanged += UpdateRedBottlesAmount;
        GameResources.OnGoldAmountChanged += UpdateCurrencyAmount;
    }

    private void Start()
    {
        UpdateCurrencyAmount();
        UpdateBlueBottlesAmount();
        UpdateRedBottlesAmount();
    }

    public void UpdateCurrencyAmount()
    {
        _currencyText.text = GameResources.GetGoldAmount().ToString();
    }

    public void UpdateBlueBottlesAmount()
    {
        _blueBottlesAmount.text = GameResources.GetBlueBottles().ToString();
    }

    public void UpdateRedBottlesAmount()
    {
        _redBottlesAmount.text = GameResources.GetRedBottles().ToString();
    }
}
