using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxLidChecker : MonoBehaviour
{
    public static BoxLidChecker Instance;
    public List<Movable> movablesOutside;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        movablesOutside = new List<Movable>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Movable collidedMovable = other.gameObject.GetComponent<Movable>();
        if (collidedMovable != null)
        {
            movablesOutside.Add(collidedMovable);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Movable collidedMovable = other.gameObject.GetComponent<Movable>();
        if (collidedMovable != null)
        {
            movablesOutside.Remove(collidedMovable);
        }
        
    }

    public void MarkMovablesOutside()
    {
        foreach (Movable movable in movablesOutside)
        {
            MeshRenderer renderer = movable.GetComponentInChildren<MeshRenderer>();
            Color currentColor = renderer.material.color;
            renderer.material.color = new Color(255, currentColor.g, currentColor.b, currentColor.a);
        }
    }
}
