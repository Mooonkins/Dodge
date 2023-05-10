using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;    
    public float fireRateMin = 0.5f;
    public float fireRateMax = 3f;

    private Transform target;    
    private float spawnRate = 0f;
    private float timeAfterSpawn;
    
    void Start()
    {
        timeAfterSpawn = 0f;

        spawnRate = Random.Range(fireRateMin, fireRateMax);

        /*target = FindObjectOfType<PlayerController>().transform;*/
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        timeAfterSpawn = 0f;

        if (timeAfterSpawn >= spawnRate)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

            bullet.transform.LookAt(target);

            spawnRate = Random.Range(fireRateMin, fireRateMax);
        }
    }
}
