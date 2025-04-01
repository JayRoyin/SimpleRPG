using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    public string saveFolder = "Saves";

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            SaveData gameSave = CreateSampleSaveData();
            SaveGame(gameSave);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            List<string> saveFiles = GetAllSaveFiles();
            if (saveFiles.Count > 0)
            {
                SaveData loadedSave = LoadGame(saveFiles[0]);
                Debug.Log("Loaded save data: " + JsonUtility.ToJson(loadedSave));
            }
        }
    }

    void Start()
    {

    }

    private SaveData CreateSampleSaveData()
    {
        SaveData save = new SaveData()
        {
            playerId = Random.Range(1, 1000),
            playerName = "Player" + Random.Range(1, 100),
            isGameCompleted = false,
            playTime = Random.Range(10f, 300f),
            inventory = new InventoryData()
            {
                items = new List<InventoryItem>
                {
                    new InventoryItem { itemId = 101, itemName = "Health Potion", value = 50, count = 3 },
                    new InventoryItem { itemId = 205, itemName = "Magic Sword", value = 200, count = 1 },
                    new InventoryItem { itemId = 302, itemName = "Gold Coin", value = 1, count = 250 }
                }
            }
        };
        return save;
    }

    public void SaveGame(SaveData saveData)
    {
        string folderPath = GetSaveFolderPath();
        string saveFileName = $"save_{saveData.playerId}_{System.DateTime.Now:yyyyMMddHHmmss}.json";
        string savePath = Path.Combine(folderPath, saveFileName);
        string jsonData = JsonUtility.ToJson(saveData, true);

        try
        {
            File.WriteAllText(savePath, jsonData);
            Debug.Log("Game saved successfully to: " + savePath);
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to save game: " + e.Message);
        }
    }

    public SaveData LoadGame(string fileName)
    {
        string savePath = Path.Combine(GetSaveFolderPath(), fileName);

        if (!File.Exists(savePath))
        {
            Debug.LogWarning("No save file found at: " + savePath);
            return null;
        }

        try
        {
            string jsonData = File.ReadAllText(savePath);
            return JsonUtility.FromJson<SaveData>(jsonData);
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to load game: " + e.Message);
            return null;
        }
    }

    public List<string> GetAllSaveFiles()
    {
        string folderPath = GetSaveFolderPath();
        if (!Directory.Exists(folderPath)) return new List<string>();
        return new List<string>(Directory.GetFiles(folderPath, "save_*.json"));
    }

    private string GetSaveFolderPath()
    {
        string folderPath = Path.Combine(Application.persistentDataPath, saveFolder);
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
        return folderPath;
    }
}

[System.Serializable]
public class SaveData
{
    public int playerId;
    public string playerName;
    public bool isGameCompleted;
    public float playTime;
    public InventoryData inventory;
}

[System.Serializable]
public class InventoryData
{
    public List<InventoryItem> items;
}

[System.Serializable]
public class InventoryItem
{
    public int itemId;
    public string itemName;
    public int value;
    public int count;
}
