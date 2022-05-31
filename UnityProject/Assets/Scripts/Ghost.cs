using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
	public float scaleSpeed = 0.001f;
	public float moveSpeed = 0.001f;


	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		transform.position = new Vector3(transform.position.x, transform.position.y + moveSpeed, transform.position.z);
		transform.localScale = new Vector3(transform.localScale.x - scaleSpeed, transform.localScale.y - scaleSpeed, transform.localScale.z - scaleSpeed);

		if(transform.localScale.x < 0) {
			Destroy(gameObject);
		}
	}
}
