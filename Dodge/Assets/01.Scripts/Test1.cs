using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test1 : MonoBehaviour
{
    /*chase a player*/
    private GameObject cubeObject;
    private Vector3 direction;
    public Rigidbody cubeRgd;
    public float moveSpd = 4f;
    public float bulletSrvTime = 1.0f;
    Transform target;
    private void OnEnable()
    {
        cubeRgd = GetComponent<Rigidbody>();
        transform.position = new Vector3(0, 1, 0);
        StartCoroutine("DisableObject");
    }
    void Start()
    {
        target = FindObjectOfType<PlayerController>().transform;        
        
        /*direction = new Vector3(Random.Range(0.1f, 0.1f),0f);*/
        cubeRgd.velocity = transform.forward * moveSpd;
        StartCoroutine("DisableObject");
    }
    private void FixedUpdate()
    {
        /*transform.position += direction;*/
        cubeObject.transform.LookAt(target);
    }
    IEnumerator DisableObject()
    {        
        yield return new WaitForSeconds(bulletSrvTime);
        gameObject.SetActive(false);        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            
            if (playerController != null)
            {               
                playerController.Die();                
            }
        }
    }
}
