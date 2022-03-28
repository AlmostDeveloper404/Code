using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WarriorTemplate : MonoBehaviour
{
    [Header("UIHeader")]
    [SerializeField] private Image _warriorImage;
    [SerializeField] private TMP_Text _barrackLevelNeeded;
    [SerializeField] private Button _warriorButton;
    [SerializeField] private GameObject _levelGOHolder;

    [Header("Warrior")]
    [SerializeField] private WarriorSO _warrior;

    private void OnEnable()
    {
        Setup();
    }

    public void Setup()
    {
        if (BuildingProgress.GetCurrentBarrackLevel() >= _warrior.LevelNeeded)
        {
            _warriorImage.sprite = _warrior.UnlockedIcon;
            _barrackLevelNeeded.text = "";
            _levelGOHolder.SetActive(false);
            _warriorButton.interactable = true;
        }
        else
        {
            _warriorImage.sprite = _warrior.LockedIcon;
            _barrackLevelNeeded.text = _warrior.LevelNeeded.ToString();
            _warriorButton.interactable = false;
            _levelGOHolder.SetActive(true);
        }
    }

    public void Select()
    {
        WarriorTrainPanal.Instance.ShowInfo(_warrior);
    }

}
