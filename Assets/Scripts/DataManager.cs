using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Security.Cryptography.X509Certificates;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;
    public string playerName;
    public string tempPlayerName;
    public int playerScore;
    [SerializeField] private TMP_InputField nameInputField;
    [SerializeField] private TMP_Text loadedScoreName;

    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        LoadData();
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        loadedScoreName.text = $"Best Score : {Instance.playerName} : {Instance.playerScore}";
    }
    public void StartGame()
    {
        tempPlayerName = nameInputField.text;
        SceneManager.LoadScene(1);
    }

    [System.Serializable]
    public class SavedData
    {
        public string playerName;
        public int playerScore;
    }

    public void SaveData()
    {
        SavedData data = new SavedData();
        data.playerName = playerName;
        data.playerScore = playerScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savedGameData1", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savedGameData1";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SavedData data = JsonUtility.FromJson<SavedData>(json);
            playerName = data.playerName;
            playerScore = data.playerScore;
        }
    }
}
