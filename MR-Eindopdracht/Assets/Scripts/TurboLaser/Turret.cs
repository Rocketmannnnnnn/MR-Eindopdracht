using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField]
    private Transform raycastStart;
    [SerializeField]
    private GameObject turretModel;
    [SerializeField]
    private TurretControl control;
    [SerializeField]
    private List<Transform> firePositions = new List<Transform>();
    [SerializeField]
    private GameObject laserPrefab;
    [SerializeField]
    private float firedelay = 0.5f;
    [SerializeField]
    private float rotationSpeed = 10;

    void Start()
    {
        StartCoroutine(Fire());
    }

    private void FixedUpdate()
    {
        if (control.Target)
        {
            RotateToTarget();
        }
    }

    private void RotateToTarget()
    {
        Vector3 turretLookDirection = (this.control.Target.transform.position - this.raycastStart.position).normalized;
        Quaternion rotation = Quaternion.LookRotation(turretLookDirection);
        turretModel.transform.rotation = Quaternion.Slerp(turretModel.transform.rotation, rotation, Time.fixedDeltaTime * rotationSpeed);
    }

    IEnumerator Fire()
    {
        while (true)
        {
            if (this.control.CanFire && this.control.Target)
            {
                Ray ray = new Ray(this.raycastStart.position, this.raycastStart.forward);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, float.MaxValue))
                {
                    if (hit.transform.root.gameObject == this.control.Target.transform.gameObject)
                    {
                        foreach (Transform firePos in this.firePositions)
                        {
                            Instantiate(this.laserPrefab, firePos.position, firePos.rotation);
                        }
                    }
                }
            }
            yield return new WaitForSeconds(this.firedelay);
        }
    }
}
