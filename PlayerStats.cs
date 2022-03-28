using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : Singleton<PlayerStats>
{
    public static Action OnScoreValueChanged;

    private PlayerProgress? _playerProgress;

    private int _level=0;
    private float _exp;

    [SerializeField] private int[] _scoreToReachLevel;
    

    private void Awake()
    {
        _playerProgress = SaveLoadProgress.LoadData();
    }

    private void Start()
    {
        if (!_playerProgress.HasValue) return;

        _level = _playerProgress.Value.Level;
        _exp = _playerProgress.Value.Score;

        OnScoreValueChanged?.Invoke();
    }

    public PlayerProgress? GetPlayerProgress()
    {
        return _playerProgress = _playerProgress.HasValue ? _playerProgress : null;
    }

    public void AddScore(float amount)
    {
        _exp += amount;
        if (_exp > _scoreToReachLevel[_level])
        {
            _exp -= _scoreToReachLevel[_level];
            _level++;
        }
        OnScoreValueChanged?.Invoke();
        
    }

    public void ResetData()
    {
        _level = 0;
        _exp = 0;
    }

    public int GetCurrentExpBorder() => _scoreToReachLevel[_level];

    public int GetPlayerLevel() => _level;

    public float GetPlayerExp() => _exp;
    
}
