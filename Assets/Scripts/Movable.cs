using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour
{
    private Rigidbody rigidBody;
    public float rotatingSpeed = 1;
    public float velocityModifier = 5;



    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchGravity(bool isGravity)
    {
        rigidBody.useGravity = isGravity;
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
}
