using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public Vector3 velocity;

    public Rigidbody rb;

    public GameObject brokePrefab;

    public float timeToDestroy = 2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        velocity = rb.velocity;
        timeToDestroy -= Time.deltaTime;
        if (timeToDestroy < 0)
        {
            DestroyRock();
        }
    }

    public void DestroyRock()
    {
        Instantiate(brokePrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
