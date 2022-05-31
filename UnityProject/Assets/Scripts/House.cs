﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
	public bool destroy = false;
	public GameObject brokePrefab;
    public GameObject spawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter(Collider coll) {
		if (coll.gameObject.tag == "Player") {
			destroy = true;
			Instantiate(brokePrefab, transform.position, transform.rotation);
            spawn.GetComponent<Spawning>().houseCount--;
            coll.GetComponent<Rock>().DestroyRock();
            Destroy(gameObject);
        }
	}
}
