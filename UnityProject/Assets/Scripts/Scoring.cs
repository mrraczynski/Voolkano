using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scoring : MonoBehaviour
{
    public Text scoreText;
    private int score;

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();

    }

    public void RemoveScore(int newScoreVale)
    {
        score -= newScoreVale;
        UpdateScore();

    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

}
