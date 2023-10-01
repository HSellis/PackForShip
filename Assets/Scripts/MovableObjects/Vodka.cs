using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vodka : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip glassBreakClip;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        BowlingBall bowlingBall = collision.gameObject.GetComponent<BowlingBall>();
        Hammer hammer = collision.gameObject.GetComponent<Hammer>();
        if (bowlingBall != null || hammer != null)
        {
            Shatter();
        }
    }

    public void Shatter()
    {
        audioSource.PlayOneShot(glassBreakClip);
        GameController.Instance.GameEnd();
        Destroy(gameObject);
    }
}
