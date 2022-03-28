using System.Collections.Generic;

public class WarriorQueueContainer : Singleton<WarriorQueueContainer>
{
    private WarriorQueueSlot[] _allSlots;

    private void Awake()
    {
        SetupSlots();
    }

    private void Start()
    {
        ArmyManager.OnWarriorInQueueChanged += UpdateUI;
    }

    private void OnEnable()
    {
        UpdateUI(ArmyManager.Instance.GetQueue());
    }

    private void SetupSlots()
    {
        _allSlots = new WarriorQueueSlot[transform.childCount];
        for (int i = 0; i < _allSlots.Length; i++)
        {
            _allSlots[i] = transform.GetChild(i).GetComponent<WarriorQueueSlot>();
        }
    }

    public void UpdateUI(Queue<WarriorSO> warriorsQueue)
    {
        ClearSlots();

        WarriorSO[] warriors = warriorsQueue.ToArray();
        int slotIndex = 0;

        for (int i = 0; i < warriors.Length; i++)
        {
            WarriorQueueSlot warriorQueueSlot = _allSlots[slotIndex];
            WarriorSO warriorSO = warriors[i];

            if (!warriorQueueSlot._warriorSO)
            {
                warriorQueueSlot.Setup(warriorSO);
            }
            else
            {
                if (warriorQueueSlot._warriorSO==warriorSO)
                {
                    warriorQueueSlot.Setup(warriorSO);
                }
                else
                {
                    slotIndex++;
                    if (slotIndex == _allSlots.Length) return;
                    

                    WarriorQueueSlot nextWarriorSlot = _allSlots[slotIndex];
                    nextWarriorSlot.Setup(warriorSO);
                }
            }
        }
    }

    public bool CanTrain(WarriorSO warrior)
    {
        WarriorQueueSlot lastSlot = _allSlots[_allSlots.Length-1];

        return lastSlot._warriorSO == null || lastSlot._warriorSO == warrior ? true : false;
    }

    private void ClearSlots()
    {
        for (int i = 0; i < _allSlots.Length; i++)
        {
            _allSlots[i].ClearSlot();
        }
    }

    private void OnDestroy()
    {
        ArmyManager.OnWarriorInQueueChanged -= UpdateUI;
    }

}
