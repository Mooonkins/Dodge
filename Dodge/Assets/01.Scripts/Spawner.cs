using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{    
    public GameObject CubeObject;
    public GameObject[] gameObjects;
        
    public float fireRateMin = 1f;
    public float fireRateMax = 3f;

    private Transform target;
    private float timeAfterSpawn;
    private float spawnRate = 0f;
    private int arrSize = 20;
    private int pivot = 0;
    
    void Start()
    {
        timeAfterSpawn = 0;

        gameObjects = new GameObject[arrSize];

        for (int i = 0; i < gameObjects.Length; i++)
        {
            GameObject gameObject = Instantiate(CubeObject, transform.position, transform.rotation);
            gameObjects[i] = gameObject;
            gameObject.SetActive(false);
        }
        StartCoroutine("EnableBullet");
    }
    IEnumerator EnableBullet()
    {
        yield return new WaitForSeconds(2f);
        gameObjects[pivot++].SetActive(true);
        if (pivot == gameObjects.Length) pivot = 0;
        StartCoroutine("EnableBullet");
    }
/*    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        timeAfterSpawn = 0;

        if (timeAfterSpawn >= spawnRate)
        {            
            spawnRate = Random.Range(fireRateMin, fireRateMax);
        }
    }*/
}
