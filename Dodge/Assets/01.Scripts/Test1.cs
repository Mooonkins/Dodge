using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test1 : MonoBehaviour
{
    /****Cube bullet****/
    public GameObject cubeObject;
    public GameObject bulletPrefab;
    public float bltFireRateMin = 1f;
    public float bltFireRateMax = 3f;
    public float moveSpd = 10f;
    
    private Rigidbody cubeRgd;
    private float spawnRate = 0f;
    private float timeAfterSpawn;

    private GameManager gameManager;

    Transform target;

    private void Awake()
    {
        cubeRgd = GetComponent<Rigidbody>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnEnable()
    {
        StartCoroutine("DisableObject");
    }
    void Start()
    {
        if (!gameManager.isGameOver)
        {
            timeAfterSpawn = 0f;
            spawnRate = Random.Range(bltFireRateMin, bltFireRateMax);
            target = FindObjectOfType<PlayerController>().transform;
        }

        StartCoroutine("DisableObject");
    }
    void Update()
    {        
        cubeRgd.velocity = transform.forward * moveSpd;
        cubeObject.transform.LookAt(target);
        /*transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpd * Time.deltaTime);*/
        
        timeAfterSpawn += Time.deltaTime;
        
        timeAfterSpawn = 0f;

        if (timeAfterSpawn >= spawnRate)
        {
            GameObject gameObject = Instantiate(bulletPrefab, transform.position, transform.rotation);
            gameObject.transform.LookAt(target);
            spawnRate = Random.Range(bltFireRateMin, bltFireRateMax);
        }

    }
    
    IEnumerator DisableObject()
    {        
        yield return new WaitForSeconds(2.0f);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            TestSpawner testSpawner = other.GetComponent<TestSpawner>();

            if (playerController != null)
            {
                playerController.Die();
                
               // testSpawner.gameObject.SetActive(false);
            }
        }
    }
}
