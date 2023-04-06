using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance;
    public string playerName;
    public int bestScore;

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int bestScore;
    }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void saveData()
    {
        SaveData data = new SaveData();
        data.playerName = this.playerName;
        data.bestScore = this.bestScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/saveFile", json);
        Debug.Log("Saved data:"+ data.playerName);
    }
    public void LoadData()
    {
        string path = Application.persistentDataPath + "/saveFile";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            playerName = data.playerName;
            bestScore = data.bestScore;
            Debug.Log("Loaded data: " + data.playerName);
        }
    }

}
