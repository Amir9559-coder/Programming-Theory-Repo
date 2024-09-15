using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] TextMeshProUGUI scoreTx;
    [SerializeField] TextMeshProUGUI healthTx;
    [SerializeField] GameObject endingObj;
    [SerializeField] GameObject cowPlayer;
    [SerializeField] GameObject dogPlayer;
    [SerializeField] GameObject horsePlayer;
    public int scoreInt;
    public int healthInt;
    public bool isGameOver;
    private void Awake()
    {
        CreateChoosenItem();
        isGameOver = false;
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreInt = 0;
        healthInt = 3;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScoreText();
        UpdateHealthText();
        GameOver();
    }
    void UpdateScoreText()
    {
        scoreTx.text = "Score : " + scoreInt;
    }
    void UpdateHealthText()
    {
        healthTx.text = "Health : " + healthInt;
    }
    void GameOver()
    {
        if(healthInt == 0)
        {
            isGameOver = true;
            endingObj.SetActive(true);
            if(scoreInt > MenuManager.bestScoreInt)
            {
                DataSaver.Serialization.Save();
            }
        }
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void CreateChoosenItem()
    {
        Vector3 pos = new Vector3(0, 0, 0);
        if(MenuManager.isCowActive)
        {
            Instantiate(cowPlayer, pos, cowPlayer.transform.rotation);
        }
        else if(MenuManager.isDogActive)
        {
            Instantiate(dogPlayer, pos, dogPlayer.transform.rotation);
        }
        else if(MenuManager.isHorseActive)
        {
            Instantiate(horsePlayer, pos, horsePlayer.transform.rotation);
        }
    }
}
