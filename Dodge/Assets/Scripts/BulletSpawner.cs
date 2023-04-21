using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;    
    public float fireRateMin = 0.5f;
    public float FireRateMax = 3f;

    private Transform target;    
    private float spawnRate = 0f;
    private float timeAfterSpawn;
    
    void Start()
    {
        timeAfterSpawn = 0f;
        
        spawnRate = Random.Range(fireRateMin, FireRateMax);
        
        target = FindObjectOfType<PlayerController>().transform;        
    }
    
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        if(timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;

            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);

            bullet.transform.LookAt(target);
            
            spawnRate = Random.Range(fireRateMin, FireRateMax);
        }
            
    }
}
