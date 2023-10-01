using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UIElements;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using TMPro;

public class LidManager : MonoBehaviour
{
    public static LidManager Instance;
    public GameObject GameStartPanel;
    public GameObject GameEndingPanel;

    public GameObject suitcaseClips;

    public TextMeshProUGUI GameEndingText;
    public TextMeshProUGUI GameEndingScoreText;
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
        gameObject.transform.DORotate(new Vector3(0, 0, 190), 2f, RotateMode.FastBeyond360);

    }

    public void EndGame(bool isWin, int score, int maxScore) 
    {
        GameStartPanel.SetActive(false);
        GameEndingPanel.SetActive(true);
        if (isWin) {
            GameEndingText.text = "You win!";
            GameEndingScoreText.text = "You packed "+score+" out of "+maxScore+" things.";
        }
        else
        {
            GameEndingText.text = "You lose!";
            GameEndingScoreText.text = "You packed " + score + " out of " + maxScore + " things.";
        }
        gameObject.transform.DORotate(lidStartRot, 1f, RotateMode.FastBeyond360);
    }
}
