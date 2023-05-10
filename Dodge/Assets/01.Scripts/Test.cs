using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    //bullet creator
    public GameObject CubeObject;
    public GameObject[] gameObjects;    

    private Transform target;

    private int pivot = 0;

    void Start()
    {
        gameObjects = new GameObject[50];
        for (int i = 0; i < 50; i++)
        {
            GameObject gameObject = Instantiate(CubeObject);
            gameObjects[i] = gameObject;
            gameObject.SetActive(false);            
        }
        StartCoroutine("EnableCube");
    }
    IEnumerator EnableCube()
    {
        yield return new WaitForSeconds(2f);
        gameObjects[pivot++].SetActive(true);
        if (pivot == 50) pivot = 0;
        /*target = FindGameObjectWithTag("Player").transform;
        target.transform.LookAt(target);*/
        StartCoroutine("EnableCube");
    }
}