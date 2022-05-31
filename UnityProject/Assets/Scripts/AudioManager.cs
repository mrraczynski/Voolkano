using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] private AudioSource _theemeSourse;
    [SerializeField] private AudioSource _stoneSourse;


    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(instance);
    }

    public void PlayStone()
    {
        _stoneSourse.PlayOneShot(_stoneSourse.clip);
    }
}
