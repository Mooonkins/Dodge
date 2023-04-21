using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public float rotateSpd = 60f;

    void Update()
    {
        transform.Rotate(0f, rotateSpd * Time.deltaTime, 0f);
    }
}
