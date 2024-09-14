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
    public int scoreInt;
    public int healthInt;
    public bool isGameOver;

    private void Awake()
    {
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
        }
    }
    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
