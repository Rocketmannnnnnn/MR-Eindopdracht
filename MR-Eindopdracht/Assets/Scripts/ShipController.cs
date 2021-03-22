using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShipController
{
    void Move(Vector3 movement);
    void Rotate(Vector3 rotation);
}

public class ShipController : MonoBehaviour, IShipController
{
    private Rigidbody rb;
    public float movementSpeed = 1.0f;
    public float rotationSpeed = 1.0f;

    private void Awake()
    {
        this.rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 movement)
    {
        Vector3 move = new Vector3(0,0,0);
        move += movement.x * transform.right;
        move += movement.y * transform.up;
        move += movement.z * transform.forward;
        rb.MovePosition(transform.position + move * this.movementSpeed);
    }

    public void Rotate(Vector3 rotation)
    {
        Vector3 rot = new Vector3(0,0,0);
        rot.x += rotation.x * this.rotationSpeed;
        rot.y += rotation.y * this.rotationSpeed;
        rot.z += rotation.z * this.rotationSpeed;
        transform.Rotate(rot);
    }
}
