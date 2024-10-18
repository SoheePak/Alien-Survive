using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject gameoverText;
    public Text timeText;
    public Text recordText;

    float surviveTime;
    bool isGameover;

    // Start is called before the first frame update
    void Start()
    {
        surviveTime = 0;
        isGameover = false;
    }
    public void EndGame()
    {
        isGameover=true;

        gameoverText.SetActive(true);

        float b = PlayerPrefs.GetFloat("BestTime");
        if(surviveTime > b )
        {
            b = surviveTime;
            PlayerPrefs.SetFloat("BestTime",b);
        }
        recordText.text = "Best Time: " + (int)b;
    }
        public void Retry()
        {
            SceneManager.LoadScene("SampleScene");
        }

    // Update is called once per frame
    void Update()
    {
        if (!isGameover) 
        {
            surviveTime += Time.deltaTime;
            timeText.text = "Time:" +(int) surviveTime;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }
}
