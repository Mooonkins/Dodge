using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject CubeObject;
    public GameObject[] gameObjects;
    private int pivot = 0;
    void Start()
    {
        gameObjects = new GameObject[500];
        for(int i = 0; i < 500; i++)
        {
            GameObject gameObject= Instantiate(CubeObject);
            gameObjects[i] = gameObject;
            gameObject.SetActive(false);
        }
        StartCoroutine("EnableCube");
    }
    IEnumerator EnableCube()
    {
        yield return new WaitForSeconds(1f);
        gameObjects[pivot++].SetActive(true);
        if (pivot == 500) pivot = 0;
        StartCoroutine("EnableCube");
    }
}
