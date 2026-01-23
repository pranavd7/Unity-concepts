using UnityEngine;
using System;
using System.IO;

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
    private string fileName = "PlayerData.json";

    public void Start()
    {
        SaveData();

        PlayerData loadedData = LoadData();
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