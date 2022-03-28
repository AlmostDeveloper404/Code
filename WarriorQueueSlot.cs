using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WarriorQueueSlot : MonoBehaviour
{
    [SerializeField] private Image _warriorImage;
    [SerializeField] private Sprite _defaultSprite;
    [SerializeField] private TMP_Text _warriorsAmountText;

    private int _warriorsAmount;
    [HideInInspector] public WarriorSO _warriorSO;


    public void Setup(WarriorSO warriorSO)
    {
        _warriorSO = warriorSO;

        _warriorsAmount++;
        _warriorImage.sprite = _warriorSO.UnlockedIcon;
        _warriorsAmountText.text = _warriorsAmount.ToString();
    }

    public void ClearSlot()
    {
        _warriorSO = null;

        _warriorsAmount = 0;
        _warriorImage.sprite = _defaultSprite;
        _warriorsAmountText.text = _warriorsAmount.ToString();
    }
}
