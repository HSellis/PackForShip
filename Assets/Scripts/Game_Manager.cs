using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager Instance;
    public int maxAmountObjects;

    public float timeRemaining = 30;
    public bool isGameStart = false;

    public void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        maxAmountObjects = ObjectSpawner.Instance.spawnedItems.Count;
    }

    void Update()
    {
        if (isGameStart) {
            Debug.Log("timer going");
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timeRemaining = 0;
                isGameStart = false;
                GameEnd();
            }
            GameUI.Instance.DisplayRemainingTime(timeRemaining);
        }
    }
    public void StartGame() 
    {
        CameraMovement.Instance.GameStartMovement();
        LidManager.Instance.Invoke("StartGame", 1f);
        isGameStart = true;
    }

    public void GameEnd() {
        // tell lid to endgame
        LidManager.Instance.EndGame();
        // liigub kaamera
        CameraMovement.Instance.Invoke("GameEndMovement", 1f);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
