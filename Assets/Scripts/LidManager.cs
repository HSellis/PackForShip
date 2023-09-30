using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UIElements;
using Unity.VisualScripting;

public class LidManager : MonoBehaviour
{
    public static LidManager Instance;
    public Vector3 lidStartPos = new Vector3(0.5f, 0.04f, 0);
    public Vector3 lidStartRot = new Vector3(0, 0, 0);
    private void Awake()
    {
        Instance = this;
    }
    public void StartGame()
    {
        gameObject.transform.DORotate(new Vector3(0, 0, 230), 1f, RotateMode.FastBeyond360);
    }

    public void EndGame() 
    {
        gameObject.transform.DORotate(lidStartRot, 1f, RotateMode.FastBeyond360);
        CameraMovement.Instance.Invoke("GameEndMovement", 1f);

    }
}
