using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameStory : MonoBehaviour
{
    public Animator animator;
    void Start()
    {
        Invoke("FadeToLEvel", 5f);
    }
    public void FadeToLEvel() 
    {
        Debug.Log("fading out");
        animator.SetTrigger("FadeOut");
    }
    public void OnFadeComplete() {
        Debug.Log("new scene");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
