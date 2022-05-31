using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestScore : MonoBehaviour
{
    [SerializeField] private Text text;
    private const string _key = "BestScore";

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey(_key))
        {
            text.text = "BEST SCORE: " + PlayerPrefs.GetInt(_key);
        }
        else
        {
            text.text = "BEST SCORE: 0";
        }
    }
}
