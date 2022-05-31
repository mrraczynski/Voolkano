using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Clear Enter");
        if (other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy")
        {
            Debug.Log("Destroy");
            Destroy(other.gameObject);
        }
    }
}
