using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverText;
    public Text recordText;
    public Text timeText;

    private float surviveTime;
    public bool isGameOver;

    void Start()
    {
        surviveTime = 0;
        isGameOver = false;
    }
    
    void Update()
    {
        if (!isGameOver)
        {
            surviveTime += Time.deltaTime;
            timeText.text = "Time : " + (int) surviveTime;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");
                Time.timeScale = 1f;
            }
        }
    }

    public void EndGame()
    {
        //Time.timeScale = 0f;
        isGameOver = true;
        //Test
        /*TestSpawner tr = GetComponent<TestSpawner>();
        tr.target = null;*/


        gameOverText.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("BestTime");

        if(surviveTime > bestTime)
        {
            bestTime = surviveTime;

            PlayerPrefs.SetFloat("BestTime", bestTime);
        }
        recordText.text = "Best Time : " + (int) bestTime;
    }
}
