using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject objectHeightPlane;
    public string movableTag = "Movable";
    public string heightPlaneTag = "HeightPlane";

    public float movableRotatingSpeed = 1;

    //private Plane targetPlane;
    private Movable currentMovable;
    private Vector3 movablePosition;
    private bool isHovering;
    private bool isDragging;


    // Start is called before the first frame update
    void Start()
    {
        //targetPlane = new Plane(objectHeightPlane.transform.up, objectHeightPlane.transform.position);
        isHovering = false;
        isDragging = false;
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Find which movable item player is hovering
        RaycastHit[] hits;
        hits = Physics.RaycastAll(ray, 5);

        isHovering = false;
        Debug.Log(hits.Length);
        foreach (RaycastHit hit in hits)
        {
            if (hit.collider.CompareTag(movableTag))
            {
                currentMovable = hit.collider.gameObject.GetComponent<Movable>();
                isHovering = true;
                
                
            } else if (hit.collider.CompareTag(heightPlaneTag))
            {
                movablePosition = hit.point;
            }
        }
       

        if (isHovering && !isDragging && Input.GetMouseButtonDown(0))
        {
            StartDragging(currentMovable);
            
        }
        if (isHovering && isDragging && Input.GetMouseButtonUp(0))
        {
            StopDragging(currentMovable);
        }
        if (isDragging && Input.GetMouseButton(0))
        {
            currentMovable.transform.position = movablePosition;

            // Rotating
            Transform currentMovableTransform = currentMovable.transform;

            // Tilt
            if (Input.GetKey(KeyCode.W))
            {
                RotateMovable(currentMovableTransform, currentMovableTransform.right, 1);
            }
            if (Input.GetKey(KeyCode.S))
            {
                RotateMovable(currentMovableTransform, currentMovableTransform.right, -1);
            }

            // Left-Right
            if (Input.GetKey(KeyCode.A))
            {
                RotateMovable(currentMovableTransform, currentMovableTransform.up, 1);
            }
            if (Input.GetKey(KeyCode.D))
            {
                RotateMovable(currentMovableTransform, currentMovableTransform.up, -1);
            }

            // Roll
            if (Input.GetKey(KeyCode.Q))
            {
                RotateMovable(currentMovableTransform, currentMovableTransform.forward, 1);
            }
            if (Input.GetKey(KeyCode.E))
            {
                RotateMovable(currentMovableTransform, currentMovableTransform.forward, -1);
            }
        }
    }

    private void RotateMovable(Transform movableTrans, Vector3 rotationAxis, int modifier)
    {
        movableTrans.RotateAround(movableTrans.position, rotationAxis, Time.deltaTime * modifier * movableRotatingSpeed * 90f);
    }

    private void StartDragging(Movable movable)
    {
        isDragging = true;
        movable.SwitchGravity(false);
    }

    private void StopDragging(Movable movable)
    {
        isDragging = false;
        movable.SwitchGravity(true);
    }
}
