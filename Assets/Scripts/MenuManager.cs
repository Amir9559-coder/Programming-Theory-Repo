using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject startObj;
    [SerializeField] GameObject itemsObj;
    [SerializeField] GameObject readyObj;
    [SerializeField] GameObject bestScore;
    [SerializeField] TextMeshProUGUI bestScoreTX;
    public static bool isDogActive = false;
    public static bool isCowActive = false;
    public static bool isHorseActive = false;
    public static int bestScoreInt;
    public void StartButton()
    {
        startObj.SetActive(false);
        itemsObj.SetActive(true);
    }
    public void DogButton()
    {
        isDogActive = true;
        isCowActive = false;
        isHorseActive = false;
        DataSaver.Serialization.LoadData();
        readyObj.SetActive(true);
        bestScore.SetActive(true);
        bestScoreTX.text = "Best Score : " + bestScoreInt;
    }
    public void CowButton()
    {
        isDogActive = false;
        isCowActive = true;
        isHorseActive = false;
        DataSaver.Serialization.LoadData();
        readyObj.SetActive(true);
        bestScore.SetActive(true);
        bestScoreTX.text = "Best Score : " + bestScoreInt;
    }
    public void HorseButton()
    {
        isDogActive = false;
        isCowActive = false;
        isHorseActive = true;
        DataSaver.Serialization.LoadData();
        readyObj.SetActive(true);
        bestScore.SetActive(true);
        bestScoreTX.text = "Best Score : " + bestScoreInt;
    }
    public void BackButton()
    {
        isCowActive = false;
        isDogActive = false;
        isHorseActive = false;
        itemsObj.SetActive(false);
        startObj.SetActive(true);
    }
    public void ReadyButton()
    {
        SceneManager.LoadScene(1);
    }
    public void ExitButton()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else 
        Application.Quit();
#endif
    }
}
