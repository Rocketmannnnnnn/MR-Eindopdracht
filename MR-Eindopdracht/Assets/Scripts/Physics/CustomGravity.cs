using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class CustomGravity : MonoBehaviour
{
    List<Rigidbody> bodies;
    public Vector3 gravityConstant = new Vector3(0, -9.81f, 0);

    private void Awake()
    {
        bodies = new List<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.attachedRigidbody;
        bodies.Add(rb);
    }

    private void OnTriggerExit(Collider other)
    {
        Rigidbody rb = other.attachedRigidbody;
        bodies.Remove(rb);
    }

    private void FixedUpdate()
    {
        foreach(Rigidbody body in this.bodies)
        {
            body.AddForce(body.mass * gravityConstant);
        }
    }
}
