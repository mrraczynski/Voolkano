using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentSpawn : MonoBehaviour
{
    
    public GameObject[] spawningObj;
    public GameObject rayCaster;
    public float height = 100;
    public float radius;
    public int count;
    public float spawnHeight;
    

    private void Start()
    {
        SpawnInLocation();
    }

    void SpawnInLocation ()
    {
        for (int i = 0; i <= count; i++)
        {
            Vector3 objPos = GetComponent<Transform>().position;
            Vector3 zone = new Vector3(Random.Range(objPos.x - radius, objPos.x + radius), spawnHeight, Random.Range(objPos.z - radius, objPos.z + radius));
            GameObject localRayCaster = Instantiate(rayCaster, zone, rayCaster.transform.rotation);
            if (Physics.Raycast(localRayCaster.transform.position, localRayCaster.transform.up, out RaycastHit hitInfo))
            {
                Vector3 pos = hitInfo.point;
                Instantiate(spawningObj[Random.Range(0, spawningObj.Length)], pos, Quaternion.identity);
            }
            Destroy(localRayCaster);
        }
    }
}
