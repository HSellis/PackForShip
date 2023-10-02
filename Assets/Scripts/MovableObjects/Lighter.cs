using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighter : Movable
{
    public ParticleSystem fireParticles;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Grab()
    {
        //GetComponent<Rigidbody>().useGravity = false;
        base.Grab();

        //var emitParams = new ParticleSystem.EmitParams();
        ParticleSystem fireParticleObj = Instantiate(fireParticles, transform.position, transform.rotation);
        fireParticleObj.Emit(1);
        Destroy(fireParticleObj.gameObject, fireParticleObj.main.duration);
    }

    public override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);

        Book collidedBook = collision.gameObject.GetComponent<Book>();
        Towel collidedTowel = collision.gameObject.GetComponent<Towel>();
        
        //MeshRenderer collidedRenderer = null;
        if (collidedBook != null || collidedTowel != null)
        {
            Transform collidedTrans = collidedBook != null ? collidedBook.transform : collidedTowel.transform;
            /*
            collidedRenderer = collision.gameObject.GetComponent<MeshRenderer>();
            Color currentColor = collidedRenderer.material.color;
            collidedRenderer.material.color = new Color(currentColor.r, currentColor.g, currentColor.b, 225);
            */

            ParticleSystem fireParticleObj = Instantiate(fireParticles, collidedTrans.position, collidedTrans.rotation);
            fireParticleObj.Emit(1);
            Destroy(fireParticleObj.gameObject, fireParticleObj.main.duration);
            Destroy(collidedTrans.gameObject);

            GameController.Instance.GameEndBegin(3, true);
        }
        
    }
}
