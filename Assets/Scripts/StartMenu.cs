using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    private int nextSceneNumber = 1;
    public void StartGame() {
        SceneManager.LoadScene(nextSceneNumber);
    }
    public void QuitGame() {
        Application.Quit();
    }
}
