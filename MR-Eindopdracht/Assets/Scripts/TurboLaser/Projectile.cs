using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float destroyAfter = 5;
    public float force = 100;
    public string targetTag = "Target";

    private void Awake()
    {
        Destroy(this.gameObject, destroyAfter);
        Rigidbody rb = this.GetComponent<Rigidbody>();
        rb.AddForce(transform.up * force, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            Destroy(collision.transform.root.gameObject);
            Destroy(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
