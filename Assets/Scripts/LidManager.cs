using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UIElements;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class LidManager : MonoBehaviour
{
    public static LidManager Instance;
    public GameObject GameStartPanel;
    public GameObject GameEndingPanel;
    public Vector3 lidStartPos = new Vector3(0.5f, 0.04f, 0);
    public Vector3 lidStartRot = new Vector3(0, 0, 0);
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        GameEndingPanel.SetActive(false);
        GameStartPanel.SetActive(true);
    }
    public void StartGame()
    {
        gameObject.transform.DORotate(new Vector3(0, 0, 230), 1f, RotateMode.FastBeyond360);
    }

    public void EndGame() 
    {
        GameStartPanel.SetActive(false);
        GameEndingPanel.SetActive(true);
        gameObject.transform.DORotate(lidStartRot, 1f, RotateMode.FastBeyond360);
    }

    public void RestartGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // RESTART GAME LOAD IN MAIN SCENE AGAIN
    }

    public void QuitGame() {
        Application.Quit();
    }
}
