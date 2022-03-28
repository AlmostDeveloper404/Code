using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WarriorTrainPanal : Singleton<WarriorTrainPanal>
{
    [Header("Visuals")]
    [SerializeField] private Image _warriorImage;
    [SerializeField] private Button _trainButton;
    [SerializeField] private Sprite _canTrainButtonSprite;
    [SerializeField] private Sprite _cannotTrainButtonSprite;

    [Header("Text info")]
    [SerializeField] private TMP_Text _description;
    [SerializeField] private TMP_Text _attackText;
    [SerializeField] private TMP_Text _defenceText;
    [SerializeField] private TMP_Text _cost;
    [SerializeField] private TMP_Text _capacity;
    [SerializeField] private TMP_Text _warriorName;
    [SerializeField] private TMP_Text _warriorCost;

    private WarriorSO warrior;
    public void ShowInfo(WarriorSO warriorSO)
    {
        warrior = warriorSO;

        _warriorCost.text = warriorSO.Cost.ToString();
        _warriorImage.sprite = warriorSO.UnlockedIcon;
        _description.text = warriorSO.Description;
        _warriorName.text = warriorSO.Name;
        _attackText.text = $"Attack: {warriorSO.Attack}";
        _defenceText.text = $"Defence: {warriorSO.Defence}";
        _cost.text = $"Cost:{warriorSO.Cost}";
        _capacity.text = $"Capacity: {warriorSO.Capacity}";

        SetButtonState();
    }

    public void Train()
    {
        GameResources.SpendGold(warrior.Cost);
        ArmyManager.Instance.AddWarriorInQueue(warrior);
        SaveLoadProgress.SaveData();

        SetButtonState();
    }

    private void SetButtonState()
    {
        _trainButton.interactable = GameResources.GetGoldAmount()>= warrior.Cost && 
            WarriorQueueContainer.Instance.CanTrain(warrior) && 
            ArmyManager.Instance.HasEnoughRoom(warrior)? true : false;

        _trainButton.image.sprite = GameResources.GetGoldAmount() >= warrior.Cost && 
            WarriorQueueContainer.Instance.CanTrain(warrior) && 
            ArmyManager.Instance.HasEnoughRoom(warrior) ? _canTrainButtonSprite : _cannotTrainButtonSprite;
    }

    private void OnDisable()
    {
        gameObject.SetActive(false);
    }
}
