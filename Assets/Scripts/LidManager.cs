using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UIElements;

public class LidManager : MonoBehaviour
{
    public void StartGame()
    {
        gameObject.transform.DORotate(new Vector3(0, 0, 230), 1f, RotateMode.FastBeyond360);
    }

}
