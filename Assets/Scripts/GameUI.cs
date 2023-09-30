using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameUI : MonoBehaviour
{
    public static GameUI Instance;
    public float timeRemaining = 30;
    public TextMeshProUGUI timeText;

    public bool isGameStart = false;

    public void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        timeText.text = string.Format("{0:00}:{1:00}", 0, 0);

    }

    void Update()
    {
        if (isGameStart)
        {

            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timeRemaining = 0;
                // GAME ENDING WHEN TIME IS 0
                LidManager.Instance.EndGame();
            }
            DisplayRemainingTime(timeRemaining);
        }
    }

    void DisplayRemainingTime(float time_) 
    {
        int minutes = Mathf.FloorToInt(time_ / 60);
        int seconds = Mathf.FloorToInt(time_ % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }
}
