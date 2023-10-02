using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vodka : Movable
{
    public AudioClip glassBreakClip;

    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);

        BowlingBall bowlingBall = collision.gameObject.GetComponent<BowlingBall>();
        Hammer hammer = collision.gameObject.GetComponent<Hammer>();
        if (bowlingBall != null || hammer != null)
        {
            Debug.Log("bowling ball");
            Shatter();
        }
    }

    public void Shatter()
    {
        audioSource.PlayOneShot(glassBreakClip);
        GameController.Instance.GameEndBegin(3, true);
        Invoke("ShatterEnd", 1f);
    }
    public void ShatterEnd() {
        Destroy(gameObject);

    }
}
