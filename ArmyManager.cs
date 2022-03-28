using UnityEngine;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.Collections.Generic;

public class ArmyManager : Singleton<ArmyManager>
{
    public static Action<Queue<WarriorSO>> OnWarriorInQueueChanged;
    public static Action OnWarriorsCapacityChanged;

    private int[] _warriorsCreatedIndexes;
    private int[] _warriorsInQueueIndexes;

    private WarriorSO[] _allWarriorsSO;

    private Queue<WarriorSO> _warriorsInQueue = new Queue<WarriorSO>();
    private List<WarriorSO> _warriorsCreated = new List<WarriorSO>();

    private int _warriorsCapacity;

    private void Awake()
    {
        LoadArmy();
    }

    private void LoadArmy()
    {
        if (!PlayerStats.Instance.GetPlayerProgress().HasValue) return;

        _warriorsCreatedIndexes = PlayerStats.Instance.GetPlayerProgress().Value.WarriorsCreated;
        _warriorsInQueueIndexes = PlayerStats.Instance.GetPlayerProgress().Value.WarriorsInQueue;

        _allWarriorsSO = Resources.LoadAll<WarriorSO>("Warriors");

        FillCreatedWarriors();
        FillQueueWarriors();
        OnWarriorInQueueChanged?.Invoke(_warriorsInQueue);
    }

    private void FillQueueWarriors()
    {
        for (int i = 0; i < _warriorsInQueueIndexes.Length; i++)
        {
            for (int w = 0; w < _allWarriorsSO.Length; w++)
            {
                if (_warriorsInQueueIndexes[i] == _allWarriorsSO[w].LevelNeeded)
                {
                    _warriorsInQueue.Enqueue(_allWarriorsSO[w]);
                }
            }
        }
        
        StartCreating();
    }

    private void FillCreatedWarriors()
    {
        for (int i = 0; i < _warriorsCreatedIndexes.Length; i++)
        {
            for (int w = 0; w < _allWarriorsSO.Length; w++)
            {
                if (_warriorsCreatedIndexes[i] == _allWarriorsSO[w].LevelNeeded) _warriorsCreated.Add(_allWarriorsSO[w]);
            }
        }
    }

    public void AddWarriorInQueue(WarriorSO warriorSO)
    {
        if (!HasWarriorsInQueue())
        {
            _warriorsInQueue.Enqueue(warriorSO);
            StartCreating();
        }
        else
        {
            _warriorsInQueue.Enqueue(warriorSO);
        }
        OnWarriorInQueueChanged?.Invoke(_warriorsInQueue);
        OnWarriorsCapacityChanged?.Invoke();
        SaveLoadProgress.SaveData();
    }

    private async void StartCreating()
    {
        if (!HasWarriorsInQueue()) return;

        await Create(_warriorsInQueue.Peek());
    }

    public async Task Create(WarriorSO warriorSO)
    {
        for (float i = 0; i < warriorSO.TimeToCreate; i += Time.deltaTime)
        {
            await Task.Yield();
        }

        _warriorsCreated.Add(warriorSO);
        _warriorsInQueue.Dequeue();
        OnWarriorInQueueChanged?.Invoke(_warriorsInQueue);
        OnWarriorsCapacityChanged?.Invoke();
        SaveLoadProgress.SaveData();
        StartCreating();
    }

    public Queue<WarriorSO> GetQueue() => _warriorsInQueue;
    public int[] GetCreatedWarriorsIndexes()
    {
        _warriorsCreatedIndexes = new int[_warriorsCreated.Count];
        for (int i = 0; i < _warriorsCreated.Count; i++)
        {
            _warriorsCreatedIndexes[i] = _warriorsCreated[i].LevelNeeded;
        }

        return _warriorsCreatedIndexes;
    }
    public int[] GetWarriorsInQueueIndexes()
    {
        WarriorSO[] warriors = _warriorsInQueue.ToArray();

        _warriorsInQueueIndexes = new int[warriors.Length];

        for (int i = 0; i < warriors.Length; i++)
        {
            _warriorsInQueueIndexes[i] = warriors[i].LevelNeeded;
        }

        return _warriorsInQueueIndexes;
    }
    public bool HasEnoughRoom(WarriorSO warriorSO)
    {
        return GetCurrentCapacity() + warriorSO.Capacity <= _warriorsCapacity ? true : false;
    }
    private bool HasWarriorsInQueue()
    {
        return _warriorsInQueue.Count <= 0 ? false : true;
    }
    public void SetMaxCapacity(int value) => _warriorsCapacity = value;
    public int GetMaxCapacity() => _warriorsCapacity;
    public int GetCurrentCapacity()
    {
        int sumInQueue = _warriorsInQueue.Sum(t => t.Capacity);
        int sumInList = _warriorsCreated.Sum(t => t.Capacity);

        int currentCapacity = sumInQueue + sumInList;

        return currentCapacity;
    }

}
