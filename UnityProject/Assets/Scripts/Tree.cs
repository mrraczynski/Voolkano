using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
	public Rigidbody rb;
	public SphereCollider treeCollider;

	public float timeToDelete = 2;

	void Update() {
		if(rb.isKinematic == false) {
			timeToDelete -= Time.deltaTime;
			if(timeToDelete<0) {
				rb.isKinematic = true;
				Destroy(treeCollider);
			}
		}
	}

	private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Player")
        {
			rb.isKinematic = false;
		}
	}
    private void Destroy()
    {
        Destroy(gameObject);
    }
}
