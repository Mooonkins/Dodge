using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody bulletRgd;
    public float bulletSpd = 8f;
    
    void Start()
    {
        bulletRgd = GetComponent<Rigidbody>();

        bulletRgd.velocity = transform.forward * bulletSpd;

        Destroy(gameObject, 2f);
    }

    private void OnTriggerEnter(Collider other)
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
