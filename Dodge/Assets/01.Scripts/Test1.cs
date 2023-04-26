using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test1 : MonoBehaviour
{
    public GameObject cubeObject;
    private Vector3 direction;
    public Rigidbody cubeRgd;
    Transform target;
    public float moveSpd = 0f;
    private void OnEnable()
    {
        cubeRgd = GetComponent<Rigidbody>();
        transform.position = new Vector3(0, 0, 0);
        StartCoroutine("DisableObject");
    }
    void Start()
    {
        cubeRgd.velocity = transform.forward * moveSpd;
        target = FindObjectOfType<PlayerController>().transform;
        direction = new Vector3(, 0f, 0f);
        StartCoroutine("DisableObject");        

    private void FixedUpdate()
    {
        /*transform.position += direction;*/
        cubeObject.transform.LookAt(target);
    }
    IEnumerator DisableObject()
    {
        yield return new WaitForSeconds(1.0f);
        gameObject.SetActive(false);
    }
}
