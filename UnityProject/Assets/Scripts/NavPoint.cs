using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavPoint : MonoBehaviour
{
    public GameObject rayCaster;
    public Vector3 navPoint;

    void Start()
    {

        Vector3 objPos = GetComponent<Transform>().position;
        Vector3 zone = new Vector3(objPos.x, 100, objPos.z);
        
        GameObject localRayCaster = Instantiate(rayCaster, zone, rayCaster.transform.rotation);
        if (Physics.Raycast(localRayCaster.transform.position, localRayCaster.transform.up, out RaycastHit hitInfo))
        {
            navPoint = hitInfo.point;
            
        }
        Destroy(localRayCaster);
    }

}
