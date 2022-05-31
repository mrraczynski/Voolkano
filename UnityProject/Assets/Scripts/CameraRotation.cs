using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
	private Vector2 pixelsToPercents;
	private Vector2 mouseScreenPos;
	
	private Vector2 screenPosInPercents;
	private Vector2 pressPos;

	public Vector3 spressedCameraAng;

	public Vector2 deltaPos;
	public bool mousePressed = false;

	public Transform cameraCenter;

	public Transform spawnPos;
	public GameObject rockPrefab;

	public int maxRocksCount;
	public int rocksCount;
    public float rockWait;


    public ParticleSystem voolkanoParticles;

	// Start is called before the first frame update
	void Start() {
		pixelsToPercents = new Vector2((float)Screen.width / 100, (float)Screen.height / 100);
       
    }

    IEnumerator RockAdd()
    {
        yield return new WaitForSeconds(rockWait);
        rocksCount--;
        yield break;
    }

	// Update is called once per frame
	void Update() {
		mouseScreenPos = Input.mousePosition;
		screenPosInPercents = new Vector2(mouseScreenPos.x / pixelsToPercents.x, mouseScreenPos.y / pixelsToPercents.y);
        
		//rocksCount = GameObject.FindGameObjectsWithTag("Player").Length;

		if (maxRocksCount == rocksCount) {
			voolkanoParticles.enableEmission = false;
		} else {
            
			voolkanoParticles.enableEmission = true;
		}

		if (Input.GetMouseButtonDown(0)) {
			pressPos = screenPosInPercents;
			spressedCameraAng = cameraCenter.eulerAngles;
			mousePressed = true;
		}
		if (mousePressed) {
			deltaPos = new Vector2(pressPos.x - screenPosInPercents.x, pressPos.y - screenPosInPercents.y);

			cameraCenter.eulerAngles = new Vector3(0, spressedCameraAng.y + deltaPos.x, 0);
		}
		if (Input.GetMouseButtonUp(0)) {
			if(Mathf.Abs(deltaPos.x) < 5 && rocksCount < maxRocksCount) {
                rocksCount++;
                StartCoroutine(RockAdd());
                Rigidbody prefabRigidbody = Instantiate(rockPrefab, spawnPos.position, Quaternion.identity).GetComponent<Rigidbody>();
				prefabRigidbody.AddForce(spawnPos.transform.rotation*Vector3.up*(5+ Mathf.Abs(deltaPos.y)/20), ForceMode.Impulse);
				prefabRigidbody.AddTorque(new Vector3(Random.Range(-10,10), Random.Range(-10, 10),Random.Range(-10, 10)), ForceMode.Impulse);
                //AudioManager.instance.PlayStone();
            }

            pressPos = Vector2.zero;
			deltaPos = Vector2.zero;
			mousePressed = false;
		}

		
	}
}
