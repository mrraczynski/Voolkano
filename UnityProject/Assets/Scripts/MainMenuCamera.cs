using UnityEngine;

public class MainMenuCamera : MonoBehaviour
{
	public float rotationSpeed;

	public Transform cameraCenter;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		cameraCenter.eulerAngles = new Vector3(0, cameraCenter.eulerAngles.y + rotationSpeed, 0);
	}
}
