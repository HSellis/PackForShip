using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxInside : MonoBehaviour
{
    public static BoxInside Instance;
    public int objectCount = 0;
    private void Awake()
    {
        Instance = this;
    }
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
        if (collidedMovable != null && !collidedMovable.isDeactivated)
        {
            objectCount++;
            collidedMovable.Deactivate();
            Debug.Log("object count:" + objectCount);
        }
    }
}
