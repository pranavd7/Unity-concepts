using UnityEngine;
using System;
using System.IO;

public class GameData
{
    public PlayerData playerData;
    public BossData bossData;
}

public class BossData
{
    
}


[Serializable]
public class PlayerData
{
    public int health;
    public int speed;
    public Vector3 position;
}

public class SaveSystem : MonoBehaviour
{
    private string directory = "PlayerDataFolder";
    private string fileName = "PlayerData.data";
    
    GameData gameData;

    public void UpdatePlayerdata(PlayerData data)
    {
        gameData.playerData = data;
    }

    public void Start()
    {
        gameData = new GameData();
        
        GameEvents.OnGameProgressed += (f) => SaveData();
        // SaveData();

        PlayerData loadedData = LoadData();
        GameEvents.SendOnGameLoaded(loadedData);
        // m_player.SetHealth(loadedData.health);
        // m_player.transform.position = loadedData.position;
    }

    public void SaveData()
    {
        string directoryPath = Path.Combine(Application.persistentDataPath, directory);
        string path = Path.Combine(Application.persistentDataPath, directory, fileName);
        Debug.Log($"Path: {path}");

        PlayerData data = new PlayerData() { health = 95, speed = 2, position = new Vector3(0, 1, 0) };
        string json = JsonUtility.ToJson(data);
        Debug.Log($"JSON data: {json}");

        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }
        File.WriteAllText(path, json);
    }

    public PlayerData LoadData()
    {
        string directoryPath = Path.Combine(Application.persistentDataPath, directory);
        string path = Path.Combine(Application.persistentDataPath, directory, fileName);
        if(!File.Exists(path))
        {
            return null;
        }
        Debug.Log($"Loading from path: {path}");
        
        string json = File.ReadAllText(path);
        Debug.Log($"Loaded JSON: {json}");

        PlayerData data = JsonUtility.FromJson<PlayerData>(json);
        return data;
    }
}