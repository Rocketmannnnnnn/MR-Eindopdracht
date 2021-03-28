using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comet : MonoBehaviour
{
    public float force = 100;
    
    private void Awake()
    {
        Rigidbody rb = this.GetComponent<Rigidbody>();
        Vector3 rotation = new Vector3(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360));
        transform.rotation = Quaternion.Euler(rotation);
        rb.AddForce(transform.forward * force, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(this.gameObject);
    }
}
