using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSpawner : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject bulletPrefab;    
    private float timeAfterSpawn;
    private float spawnRate;
     Transform target;
    
    void Start()
    {
        //gameManager = GetComponent<GameManager>();
        gameManager = FindObjectOfType<GameManager>();
      
        if (!gameManager.isGameOver)
        {
            timeAfterSpawn = 0f;
            spawnRate = Random.Range(1f, 2f);
            target = FindObjectOfType<PlayerController>().transform;      
           
        }      
        /*timeAfterSpawn = 0f;
        spawnRate = Random.Range(1f, 3f);
        target = GetComponent<PlayerController>().transform;*/

    }

    void Update()
    {
      
        timeAfterSpawn += Time.deltaTime;
        
        if (timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;
            GameObject gameObject = Instantiate(bulletPrefab, transform.position, transform.rotation);
            gameObject.transform.LookAt(target);
            spawnRate = Random.Range(1f, 2f);
            
           
        }
       

    }
    
}
