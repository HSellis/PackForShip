using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Silicone : MonoBehaviour
{
    public float explosionForce = 10.0f;
    public float explosionRadius = 5.0f;

    public AudioClip explostionClip;
    private AudioSource audioSource;

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
        Lighter lighter = collision.gameObject.GetComponent<Lighter>();
        if (lighter != null)
        {
            // Detect nearby colliders within the explosion radius.
            Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

            foreach (Collider col in colliders)
            {
                // Check if the object has a Rigidbody.
                Rigidbody rb = col.GetComponent<Rigidbody>();
                if (rb != null)
                {
                    // Calculate the direction away from the explosion point.
                    Vector3 direction = col.transform.position - transform.position;

                    // Apply force to the object.
                    rb.AddForce(direction.normalized * explosionForce, ForceMode.Impulse);
                }
            }

            audioSource.PlayOneShot(explostionClip);
            GameController.Instance.Invoke("GameEnd",0.5f);
        }
    }
}
