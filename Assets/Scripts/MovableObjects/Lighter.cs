using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighter : Movable
{
    private ParticleSystem fireParticles;
    // Start is called before the first frame update
    void Start()
    {
        fireParticles = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Grab()
    {
        GetComponent<Rigidbody>().useGravity = false;
        //base.SwitchGravity(isGravity); // doesnt work

        var emitParams = new ParticleSystem.EmitParams();
        fireParticles.Emit(emitParams, 10);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Book collidedBook = collision.gameObject.GetComponent<Book>();
        Towel collidedTowel = collision.gameObject.GetComponent<Towel>();
        MeshRenderer collidedRenderer = null;
        if (collidedBook != null || collidedTowel != null)
        {
           collidedRenderer = collision.gameObject.GetComponent<MeshRenderer>();
        }
        if (collidedRenderer != null)
        {
            Color currentColor = collidedRenderer.material.color;
            collidedRenderer.material.color = new Color(currentColor.r, currentColor.g, currentColor.b, 180);
        }
    }
}
