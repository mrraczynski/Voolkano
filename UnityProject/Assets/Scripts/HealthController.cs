using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    [SerializeField] private List<Image> _images = new List<Image>();
    private int _health = 5;
    [HideInInspector] public static HealthController instance;
    private void Awake()
    {
        instance = this;
    }

    public void TakeDamage()
    {
        _health--;
        if(_health == 0)
        {
            Debug.LogError("Game Over!");
             SceneManager.LoadScene(0);
            return;
        }
        _images.Last().gameObject.SetActive(false);
        _images.Remove(_images.Last());
    }
    public void TakeHealth(int health)
    {
        _health += health;
        if (_health > 5)
            _health = 5;
    }
}
