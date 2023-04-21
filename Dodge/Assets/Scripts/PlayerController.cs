using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    public float moveSpd = 8f;    
    
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();        
    }

    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");

        float xSpd = xInput * moveSpd;
        float zSpd = zInput * moveSpd;

        Vector3 playerVelocity = new Vector3(xSpd, 0f, zSpd);

        playerRigidbody.velocity = playerVelocity;
    }
    public void Die()
    {
        /*gameObject.SetActive(false);*/
        Destroy(gameObject);
    }
}
