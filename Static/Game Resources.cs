using System;

public static class GameResources
{
    public static Action OnGoldAmountChanged;
    public static Action OnBlueBottlesChanged;
    public static Action OnRedBottlesChanged;

    private static int _currency;
    private static int _blueBottles;
    private static int _redBottles;


    public static void AddGold(int amount)
    {
        _currency += amount;
        OnGoldAmountChanged?.Invoke();
    }

    public static void AddBlueBottles(int amount)
    {
        _blueBottles += amount;
        OnBlueBottlesChanged?.Invoke();
    }

    public static void AddRedBottles(int amount)
    {
        _redBottles += amount;
        OnRedBottlesChanged?.Invoke();
    }

    public static void SpendGold(int amount)
    {
        _currency -= amount;
        OnGoldAmountChanged?.Invoke();
    }

    public static void SpendBlueBottles(int amount)
    {
        _blueBottles -= amount;
        OnBlueBottlesChanged?.Invoke();
    }

    public static void SpendRedBottles(int amount)
    {
        _redBottles -= amount;
        OnRedBottlesChanged?.Invoke();
    }

    public static void ResetResources(int gold,int blue,int red)
    {
        _currency = gold;
        _redBottles = blue;
        _blueBottles = red;
    }

    public static int GetBlueBottles()
    {
        return _blueBottles;
    }

    public static int GetRedBottles()
    {
        return _redBottles;
    }

    public static int GetGoldAmount()
    {
        return _currency;
    }
}
