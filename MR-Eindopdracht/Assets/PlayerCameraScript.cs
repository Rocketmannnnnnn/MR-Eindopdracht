using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraScript : MonoBehaviour
{
    public Transform playerCamera;
    public Transform playerView;
    public Transform shipView;

    // Update is called once per frame
    void Update()
    {
        Vector3 playerOffsetFromShip = playerCamera.position - shipView.position;
        transform.position = playerView.position + playerOffsetFromShip;

        float angularDifferenceBetweenViewRotations = Quaternion.Angle(playerView.rotation, shipView.rotation);

        Quaternion viewRotationDifference = Quaternion.AngleAxis(angularDifferenceBetweenViewRotations, Vector3.up);
        Vector3 newCameraDirection = viewRotationDifference * playerCamera.forward;
        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
    }
}

