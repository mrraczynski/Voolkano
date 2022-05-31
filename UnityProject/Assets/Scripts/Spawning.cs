using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    public Vector3 center; //центр спавна
    public Vector3 size; //размер спавна
    public GameObject pref; //объект для спавна
    public float spawnTime; //общее время спавна, обязателен, если infiniteSpawn=false 
    public float spawnWait; //время между единичными спавнами
    public bool infiniteSpawn = true; //бесконечный спавн
    public float initWait = 5;
    public GameObject[] navPoints;
    public int houseCount = 5;

    [SerializeField] private Transform _destanation;

    private void Start()
    {
        center = transform.position;
        StartSpawning();
    }
    //старт спавна
    public void StartSpawning()
    {
        StartCoroutine(SpawningEnemies());
    }

    private void Update()
    {
        if(houseCount == 0)
        {
            gameObject.SetActive(false);
        }
    }

    //массовый спавн
    private IEnumerator SpawningEnemies()
    {
        yield return new WaitForSeconds(initWait);
        if (infiniteSpawn)
        {
            //бесконечный спавн
            while (true)
            {
                Spawn();
                Debug.Log("wrong " + houseCount);
                yield return new WaitForSeconds(spawnWait);
            }
                
        }
        else
        {
            //конечный спавн
            float startTime = Time.time;
            while (Time.time < startTime + spawnTime)
            {
                Spawn();
                yield return new WaitForSeconds(spawnWait);
            }
        }
        
    }

    //спавн одного объекта
    private void Spawn()
    {
        GameObject localPref;
        Vector3 position = center + new Vector3(Random.Range(-size.x/2,size.x/2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
        var enemy = pref.GetComponent<EnemyController>();
        enemy._destanation = this._destanation;
        enemy.navPoints = this.navPoints;
        Instantiate(pref, position, Quaternion.identity);
    }

    //рисовка спавна
    private void OnDrawGizmosSelected()
    {
        center = transform.position;
        Gizmos.color = new Color(1f, 0f, 0f, .5f);
        Gizmos.DrawCube(center, size);
    }

}
