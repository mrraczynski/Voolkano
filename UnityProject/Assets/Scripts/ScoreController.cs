using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    public static ScoreController instance;
    private int score;
    [SerializeField] private Text textMesh;
    private const string _key = "BestScore";

    private void Awake()
    {
        instance = this;
    }

    public void AddScore()
    {
        score++;
        if (!PlayerPrefs.HasKey(_key))
        {
            PlayerPrefs.SetInt(_key, score);
        }
        var best = PlayerPrefs.GetInt(_key);
        if(score > best)
        {
            PlayerPrefs.SetInt(_key, score);
        }
        textMesh.text = score.ToString();
    }
}
