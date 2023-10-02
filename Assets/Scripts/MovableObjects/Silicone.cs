using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Silicone : Movable
{
    public float explosionForce = 10.0f;
    public float explosionRadius = 5.0f;

    public AudioClip explosionClip;
    public ParticleSystem explosionParticlesPrefab;

    // Start is called before the first frame update
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);

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

            GameObject tempAudio = Instantiate(new GameObject(), transform.position, transform.rotation);
            AudioSource tempSource = tempAudio.AddComponent<AudioSource>();
            tempSource.PlayOneShot(explosionClip);

            ParticleSystem explosionParticles = Instantiate(explosionParticlesPrefab, transform.position, transform.rotation);
            explosionParticles.Emit(1);
            Destroy(explosionParticles.gameObject, explosionParticles.main.duration);

            Destroy(gameObject);

            GameController.Instance.GameEndBegin(3, true);
        }
    }
}
