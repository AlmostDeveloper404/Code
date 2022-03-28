using UnityEngine;
using TMPro;

public class CapacityPanal : MonoBehaviour
{
    [SerializeField] private TMP_Text _capacityText;

    private void OnEnable()
    {
        Setup();
        ArmyManager.OnWarriorsCapacityChanged += Setup;
    }

    public void Setup()
    {
        _capacityText.text = $"Capacity: {ArmyManager.Instance.GetCurrentCapacity()} / {ArmyManager.Instance.GetMaxCapacity()}";
    }

    private void OnDisable()
    {
        ArmyManager.OnWarriorsCapacityChanged -= Setup;
    }


}
