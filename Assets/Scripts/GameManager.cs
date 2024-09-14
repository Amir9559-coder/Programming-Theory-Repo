using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] TextMeshProUGUI scoreTx;
    [SerializeField] TextMeshProUGUI healthTx;
    public int scoreInt;
    public int healthInt;

    private void Awake()
    {
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
    }
    void UpdateScoreText()
    {
        scoreTx.text = "Score : " + scoreInt;
    }
    void UpdateHealthText()
    {
        healthTx.text = "Health : " + healthInt;
    }
}
