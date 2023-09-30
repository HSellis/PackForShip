using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraMovement : MonoBehaviour
{
    public static CameraMovement Instance;
    public Vector3 cameraGameStartPos = new Vector3(-0.5f, 1.5f, 0f);
    public Vector3 cameraGameStartRot = new Vector3(90, 0, 0);

    public Vector3 cameraMoveToPos = new Vector3(0.05f,1.5f,-1f);
    public Vector3 cameraMoveToRot = new Vector3(45, 0, 0);

    public float rotationMinX = 40;
    public float rotationMaxX = 70;
    public float rotationMinY = -45f;
    public float rotationMaxY = 45f;

    public float cameraRotationSpeed = 250;
    public void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        gameObject.transform.position = cameraGameStartPos;
        Quaternion rot = Quaternion.Euler(cameraGameStartRot);
        gameObject.transform.rotation = rot;
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Quaternion rotationBefore = transform.rotation;

            float rotationX = Input.GetAxis("Mouse X");
            float rotationY = Input.GetAxis("Mouse Y");
            transform.RotateAround(transform.position, Vector3.up, Time.deltaTime * cameraRotationSpeed * rotationX);
            transform.RotateAround(transform.position, Vector3.right, Time.deltaTime * cameraRotationSpeed * -rotationY);

            Vector3 eulerRotation = transform.rotation.eulerAngles;
            if (eulerRotation.x > 180) eulerRotation.x -= 360;
            if (eulerRotation.y > 180) eulerRotation.y -= 360;

            if (eulerRotation.x < rotationMinX || eulerRotation.x > rotationMaxX || eulerRotation.y < rotationMinY || eulerRotation.y > rotationMaxY)
            {
                transform.rotation = rotationBefore;
            }
        }
    }

    public void GameStartMovement() // Moving camera after lid is down
    {
        gameObject.transform.DOMove(cameraMoveToPos, 2f);
        gameObject.transform.DORotate(cameraMoveToRot,2f);
    }

    public void GameEndMovement() 
    {
        gameObject.transform.DOMove(cameraGameStartPos, 2f);
        gameObject.transform.DORotate(cameraGameStartRot, 2f);
    }
}
