using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int score;

    [SerializeField] private Text scoreText;
    
    void Update()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void AddScore()
    {
        score += 10;
    }
}
