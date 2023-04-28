using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test1 : MonoBehaviour
{
    public GameObject cubeObject;
    private Vector3 direction;
    private Rigidbody cubeRgd;
    public float moveSpd = 4f;
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
        /*PlayerController playerController = GetComponent<PlayerController>();*/
        
        /*direction = new Vector3(Random.Range(0.1f, 0.1f),0f);*/
        StartCoroutine("DisableObject");
    }
    private void FixedUpdate()
    {
        cubeRgd.velocity = transform.forward * moveSpd;
        /*transform.position += direction;*/
        cubeObject.transform.LookAt(target);
    }
    IEnumerator DisableObject()
    {
        yield return new WaitForSeconds(1.0f);
        gameObject.SetActive(false);
    }
}
