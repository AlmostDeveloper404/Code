using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private int _blueBottles,_redBottles,_gold;

    [ContextMenu("Delete Saves")]
    public void Reset()
    {
        SaveLoadProgress.DeleteData();
    }
    [ContextMenu("Add Resources")]
    public void AddGold()
    {
        GameResources.ResetResources(_gold, _blueBottles, _redBottles);
        SaveLoadProgress.SaveData();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
