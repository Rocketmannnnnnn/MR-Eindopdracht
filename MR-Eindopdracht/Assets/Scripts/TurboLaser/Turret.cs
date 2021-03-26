using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField]
    private Transform raycastStart;
    [SerializeField]
    private GameObject xAxis;
    [SerializeField]
    private GameObject yAxis;
    [SerializeField]
    private TurretControl control;
    [SerializeField]
    private List<Transform> firePositions = new List<Transform>();
    [SerializeField]
    private Vector3 rotationOffset;
    [SerializeField]
    private GameObject laserPrefab;
    [SerializeField]
    private float firedelay = 0.5f;

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
        Vector3 turretLookDirection = this.control.Target.transform.position - this.raycastStart.position;

        Quaternion rotation = Quaternion.LookRotation(turretLookDirection);

        //Vector3 rotation = Vector3.RotateTowards(this.raycastStart.position, this.control.Target.transform.position, this.rotationSpeed * Time.fixedDeltaTime, 0.0f);
        this.xAxis.transform.localRotation = Quaternion.Euler(
            new Vector3(rotation.eulerAngles.x + rotationOffset.x, 
                        this.xAxis.transform.localRotation.y, 
                        this.xAxis.transform.localRotation.z));
        this.yAxis.transform.localRotation = Quaternion.Euler(
            new Vector3(this.xAxis.transform.localRotation.x,
                        rotation.eulerAngles.y + rotationOffset.y,
                        this.xAxis.transform.localRotation.z));
    }

    IEnumerator Fire()
    {
        while (true)
        {
            if (this.control.CanFire && this.control.Target)
            {
                Vector3 turretLookDirection = this.control.Target.transform.position - this.raycastStart.position;
                RaycastHit hit;

                if (Physics.Raycast(this.raycastStart.position, turretLookDirection, out hit))
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
