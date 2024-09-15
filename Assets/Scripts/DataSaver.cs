using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataSaver : MonoBehaviour
{
    public static DataSaver Serialization;
    private int oldCowScore;
    private int oldDogScore;
    private int oldHorseScore;
    // Start is called before the first frame update
    void Start()
    {
        Serialization = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [System.Serializable]
    public class SaveData 
    {
        public int bestScoreCow;
        public int bestScoreDog;
        public int bestScoreHorse;
    }
    public void Save()
    {
        SaveData data = new SaveData();
        //Save BestScore for each item
        if (MenuManager.isCowActive)
        {
            data.bestScoreCow = GameManager.instance.scoreInt;
        }
        else
        {
            data.bestScoreCow = oldCowScore;
        }
        if (MenuManager.isDogActive)
        {
            data.bestScoreDog = GameManager.instance.scoreInt;
        }
        else
        {
            data.bestScoreDog = oldDogScore;
        }
        if(MenuManager.isHorseActive)
        {
            data.bestScoreHorse = GameManager.instance.scoreInt;
        }
        else
        {
            data.bestScoreHorse = oldHorseScore;
        }
        string json = JsonUtility.ToJson(data);
        string path = Application.persistentDataPath + "/savefile.json";
        File.WriteAllText(path, json);
    }
    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            if (MenuManager.isCowActive)
            {
                MenuManager.bestScoreInt = data.bestScoreCow;
                oldCowScore = data.bestScoreCow;
            }
            else if (MenuManager.isDogActive)
            {
                MenuManager.bestScoreInt = data.bestScoreDog;
                oldDogScore = data.bestScoreDog;
            }
            else if(MenuManager.isHorseActive)
            {
                MenuManager.bestScoreInt = data.bestScoreHorse;
                oldHorseScore = data.bestScoreHorse;
            }
        }
    }
}
