using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		gameObject.transform.localScale = gameObject.transform.localScale - Vector3.one / 50;
		if(gameObject.transform.localScale.x < 0) {
			Destroy(gameObject.transform.parent.gameObject);
		}

	}
}
