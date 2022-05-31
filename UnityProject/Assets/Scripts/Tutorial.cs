using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
	public Transform cameraRotation;
	public Vector3 cameraStartRotation;

	public float delta;
	public float deltaMax;

	public GameObject rotationHelp;
	public GameObject fireHelp;

    // Start is called before the first frame update
    void Start()
    {
		cameraStartRotation = cameraRotation.eulerAngles;

	}

    // Update is called once per frame
    void Update()
    {
		delta = Mathf.Abs(cameraStartRotation.y - cameraRotation.eulerAngles.y);

		if(delta > 40) {
			rotationHelp.SetActive(false);
			fireHelp.SetActive(true);
		}

		if (fireHelp.activeSelf) {
			if(GameObject.FindGameObjectsWithTag("Player").Length > 0) {
				Destroy(gameObject);
			}
		}

	}
}
