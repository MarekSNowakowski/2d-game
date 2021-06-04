using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameSaver : MonoBehaviour
{
    [SerializeField]
    DayNightController dayNightController;
    [SerializeField]
    Transform playerTransform;

    public void SaveGame()
    {
        GameData gameData = SaveCurrentState();
        string filepath = Application.persistentDataPath + "/save.dat";
        using (FileStream file = File.Create(filepath))
        {
            new BinaryFormatter().Serialize(file, gameData);
        }
    }

    GameData SaveCurrentState()
    {
        GameData gameData = new GameData();
        gameData.time = dayNightController.GetTime();
        gameData.playerPositionX = playerTransform.position.x;
        gameData.playerPositionY = playerTransform.position.y;
        return gameData;
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt("Load",0) == 1)
        {
            GameData gameData = LoadFromFile();
            PlayerPrefs.SetInt("Load", 0);
            playerTransform.position = new Vector2(gameData.playerPositionX, gameData.playerPositionY);
            dayNightController.SetTime(gameData.time);
        }
    }

    public GameData LoadFromFile()
    {
        string filepath = Application.persistentDataPath + "/save.dat";
        GameData gameData = null;
        if (File.Exists(filepath))
        {
            using (FileStream file = File.Open(filepath, FileMode.Open))
            {
                object loadedData = new BinaryFormatter().Deserialize(file);
                gameData = (GameData)loadedData;
            }
        }
        else
        {
            SaveGame();
        }
        return gameData;
    }
}

[Serializable]
public class GameData
{
    public float time;
    public int date;
    public float playerPositionX;
    public float playerPositionY;
}
