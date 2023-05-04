using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public GameObject CubeObject;
    public GameObject[] gameObjects;
    public int Cube = 100;
    private int pivot = 0;
    void Start()
    {
        gameObjects = new GameObject[Cube];
        for(int i = 0; i < Cube; i++)
        {
            GameObject gameObject = Instantiate(CubeObject);
            gameObjects[i] = gameObject;
            gameObject.SetActive(false);
        }
        StartCoroutine("EnableCube");
    }
    IEnumerator EnableCube()
    {        
        yield return new WaitForSeconds(4f);
        gameObjects[pivot++].SetActive(true);
        if (pivot == Cube) pivot = 0;
        StartCoroutine("EnableCube");
    }
}
