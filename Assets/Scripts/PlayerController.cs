using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public string movableTag = "Movable";
    public string heightPlaneTag = "HeightPlane";

    //private Plane targetPlane;
    private Movable currentMovable;
    private Vector3 movablePosition;
    private bool isHovering;
    private bool isDragging;


    // Start is called before the first frame update
    void Start()
    {
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
        if (isDragging && Input.GetMouseButtonUp(0))
        {
            StopDragging(currentMovable);
        }
        if (isDragging && Input.GetMouseButton(0))
        {
            currentMovable.AddForceTowards(movablePosition);

            // Rotating
            Transform currentMovableTransform = currentMovable.transform;

            // Tilt
            if (Input.GetKey(KeyCode.W))
            {
                currentMovable.Rotate(currentMovableTransform.right, 1);
            }
            if (Input.GetKey(KeyCode.S))
            {
                currentMovable.Rotate(currentMovableTransform.right, -1);
            }

            // Left-Right
            if (Input.GetKey(KeyCode.A))
            {
                currentMovable.Rotate(currentMovableTransform.up, 1);
            }
            if (Input.GetKey(KeyCode.D))
            {
                currentMovable.Rotate(currentMovableTransform.up, -1);
            }

            // Roll
            if (Input.GetKey(KeyCode.Q))
            {
                currentMovable.Rotate(currentMovableTransform.forward, 1);
            }
            if (Input.GetKey(KeyCode.E))
            {
                currentMovable.Rotate(currentMovableTransform.forward, -1);
            }
        }
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
