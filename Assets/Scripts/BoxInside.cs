using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxInside : MonoBehaviour
{
    private int objectCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Movable collidedMovable = other.gameObject.GetComponent<Movable>();
        objectCount++;
        collidedMovable.Deactivate();
        Debug.Log("object count:" + objectCount);
    }
}
