using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Book collidedBook = collision.gameObject.GetComponent<Book>();
        if (collidedBook != null)
        {
            MeshRenderer bookRenderer = collidedBook.GetComponent<MeshRenderer>();
            bookRenderer.material.color = Color.red;
        }
    }
}
