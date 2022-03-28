using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveLoadProgress
{
    
    public static void SaveData()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string path = Application.persistentDataPath+"/playerProgress.bn";
        FileStream fileStream = new FileStream(path,FileMode.Create);

        PlayerProgress playerProgress = new PlayerProgress
        {
            Gold = GameResources.GetGoldAmount(),
            BlueBottles = GameResources.GetBlueBottles(),
            RedBottles = GameResources.GetRedBottles(),
            GoldInMarket = (int)Market.Instance.GetCurrentGoldFromMarket(),
            MainBuilding = BuildingProgress.GetCurrentMainBuildingLevel(),
            Market= BuildingProgress.GetCurrentMarketLevel(),
            Barrack= BuildingProgress.GetCurrentBarrackLevel(),
            Pub= BuildingProgress.GetCurrentPubLevel(),
            Craft= BuildingProgress.GetCurrentCraftLevel(),
            Score=PlayerStats.Instance.GetPlayerExp(),
            Level=PlayerStats.Instance.GetPlayerLevel(),
            CurrentCapacity=ArmyManager.Instance.GetMaxCapacity(),
            WarriorsCreated=ArmyManager.Instance.GetCreatedWarriorsIndexes(),
            WarriorsInQueue=ArmyManager.Instance.GetWarriorsInQueueIndexes()
        };

        binaryFormatter.Serialize(fileStream,playerProgress);
        fileStream.Close();
    }

    public static PlayerProgress? LoadData()
    {
        string path = Application.persistentDataPath + "/playerProgress.bn";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path,FileMode.Open);

            PlayerProgress? playerProgress= formatter.Deserialize(stream) as PlayerProgress?;
            stream.Close();

            return playerProgress;
        }
        else
        {
            Debug.LogError($"File doesn't found! Path: {path} ");
            return null;
        }
    }

    public static void DeleteData()
    {
        string path = Application.persistentDataPath + "/playerProgress.bn";
        File.Delete(path);
    }
}
