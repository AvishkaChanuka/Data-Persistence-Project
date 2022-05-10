using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string UserName;
    public string BestUserName;
    public int Score;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadScore();

    }
  
    [System.Serializable]
    class SaveHIScore
    {
        public string playerName;
        public int score;
    }

    public void SaveScore()
    {
        SaveHIScore data = new SaveHIScore();
        data.playerName = BestUserName;
        data.score = Score;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/saveData.json", json);
    }

    public void LoadScore()
    {
        string filePath = Application.persistentDataPath + "/saveData.json";

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            SaveHIScore data = JsonUtility.FromJson<SaveHIScore>(json);

            BestUserName = data.playerName;
            Score = data.score;
        }
    }
}
