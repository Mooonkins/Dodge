using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawner : MonoBehaviour
{
    GameManager gameManager;
    Transform target;
    public GameObject bulletPrefab;    
    public float timeAfterSpawn;
    public float spawnRate;
    void Start()
    {
        if (!gameManager.isGameOver)
        {
            gameManager = GetComponent<GameManager>();
            timeAfterSpawn = 0f;
            spawnRate = Random.Range(1f, 3f);
            target = GetComponent<PlayerController>().transform;
        }
    }
    
    void Update()
    {
        timeAfterSpawn = 0f;
        timeAfterSpawn += Time.deltaTime;
        if(timeAfterSpawn >= spawnRate)
        {
            GameObject gameObject = Instantiate(bulletPrefab, transform.position, transform.rotation);
            gameObject.transform.LookAt(target);
            spawnRate = Random.Range(1f, 3f);
        }
    }
}
