using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Button _play;
    // Start is called before the first frame update
    void Start()
    {
        _play.onClick.AddListener(delegate () { OpenScene(); });
    }

    private void OpenScene()
    {
        SceneManager.LoadScene("Game");
    }
}
