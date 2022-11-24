using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour


{
    public static GameManager Instance;

    public string playerName;
    public string bestPlayer;
    public int bestScore;
    [SerializeField] GameObject textEnter;

    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TextEnter()
    {
        playerName = textEnter.gameObject.GetComponent<TMP_InputField>().text;

    }

    [System.Serializable]
    class SaveData
    {
        public string bestPlayer;
        public int bestScore;
    }

    public void SaveScore(string bestPlayer, int bestScore)
    {
        SaveData data = new SaveData();
        data.bestPlayer = bestPlayer;
        data.bestScore = bestScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savedata.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savedata.json";
        if (File.Exists(path))
        {
            SaveData data = new SaveData();
            string json = File.ReadAllText(path);
            data = JsonUtility.FromJson<SaveData>(json);
            bestPlayer = data.bestPlayer;
            bestScore = data.bestScore;
        }
        else bestScore = 0;
    }





   
}
