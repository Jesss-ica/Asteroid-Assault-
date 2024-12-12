using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI LiveText;

    private int Score = 0;
    private int Value = 3;

    public void AddToScore(int ScoretoAdd)
    {
        Score += ScoretoAdd;
        ScoreText.text = "Score: " + Score.ToString();
    }

    public void UpdatePlayerLives(int value)
    {
        LiveText.text = "Lives: " + value.ToString();
    }
    void Start()
    {
        ScoreText.text = "Score: " + Score.ToString();
        LiveText.text = "Lives: " + Value.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public int GetScore()
    {
        return this.Score;
    }

}