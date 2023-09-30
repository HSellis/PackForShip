using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameUI : MonoBehaviour
{
    public static GameUI Instance;
    public TextMeshProUGUI timeText;
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
        
    }

    public void DisplayRemainingTime(float time_) 
    {
        int minutes = Mathf.FloorToInt(time_ / 60);
        int seconds = Mathf.FloorToInt(time_ % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

    }
}
