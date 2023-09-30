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
        ObjectSpawner.Instance.Invoke("SpawnObject", 3);
    }

    public void GameEnd() {
        // tell object spawner to stop
        ObjectSpawner.Instance.isGameEnd = true;
        int score = BoxInside.Instance.objectCount;
        bool isWin = score >= maxAmountObjects ? true : false;
        // tell lid to endgame
        LidManager.Instance.EndGame(isWin, score, maxAmountObjects);
        // move camera to end screen
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
