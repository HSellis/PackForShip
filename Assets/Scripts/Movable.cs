using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour
{
    private Rigidbody rigidBody;
    private AudioSource audioSource;

    public float rotatingSpeed = 1;
    public float velocityModifier = 5;
    public string deactivatedTag = "Untagged";
    public AudioClip grabClip;
    public AudioClip collisionClip;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        Debug.Log(grabClip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void Grab()
    {
        rigidBody.useGravity = false;
        audioSource.PlayOneShot(grabClip);
    }

    public virtual void Release()
    {
        rigidBody.useGravity = true;
    }

    public void Rotate(Vector3 rotationAxis, int modifier)
    {
        transform.RotateAround(transform.position, rotationAxis, Time.deltaTime * modifier * rotatingSpeed * 90f);
    }

    public void AddForceTowards(Vector3 targetPos)
    {
        Vector3 toTargetPos = targetPos - transform.position;
        rigidBody.velocity = toTargetPos * velocityModifier;
    }

    public void Deactivate()
    {
        gameObject.tag = deactivatedTag;
    }

    public virtual void OnCollisionEnter(Collision collision)
    {
        audioSource.PlayOneShot(collisionClip);
    }
}
