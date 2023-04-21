using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverText;    
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI recordtext;

    private float surviveTime;
    private bool isGameover;

    void Start()
    {
        timeText = GetComponent<TextMeshProUGUI>();
        recordtext = GetComponent<TextMeshProUGUI>();

        surviveTime = 0;
        isGameover = false;
    }
    
    void Update()
    {
        
    }

    public void EndGame()
    {

    }
}
