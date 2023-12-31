using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameController : MonoBehaviour
{
    public static GameController Instance;
    public int maxAmountObjects;

    public float timeRemaining = 30;
    public bool isGameStart = false;
    public bool isGameEnd = false;

    public GameObject winStory;
    public GameObject loseStory;
    public bool isWin=false;
    public int score = 0;
    private bool isEarlyEnd=false;

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
        if (isGameStart && !isGameEnd) {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timeRemaining = 0;
                isGameStart = false;
                if (!isGameEnd) {
                    GameEndBegin(1f, false);
                }
                
                 
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

    public void GameEndBegin(float whenContinue, bool isEarlyLose) {
        if (!isGameEnd) {
            isGameEnd = true;
            // tell object spawner to stop
            ObjectSpawner.Instance.isGameEnd = true;
            score = BoxInside.Instance.objectCount;
            score -= BoxLidChecker.Instance.movablesOutside.Count;
            isWin = score >= maxAmountObjects*0.75 ? true : false;
            isEarlyEnd = isEarlyLose;
            if (isEarlyEnd)
            {
                score = -1;
                isWin = false;
            }
            else {
                BoxLidChecker.Instance.MarkMovablesOutside();

            }
            Invoke("GameEndContinue", whenContinue);
        }
    }

    public void GameEndContinue()
    {
        // cutscenes
        if (isWin)
        {
            winStory.SetActive(true);
            loseStory.SetActive(false);
        }
        else
        {
            loseStory.SetActive(true);
            winStory.SetActive(false);
        }
        Invoke("GameEndFinish", 5f);
    }
    public void GameEndFinish() {
        winStory.SetActive(false);
        loseStory.SetActive(false);
        // tell lid to endgame
        LidManager.Instance.EndGame(isWin, score, maxAmountObjects, isEarlyEnd);
        
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
