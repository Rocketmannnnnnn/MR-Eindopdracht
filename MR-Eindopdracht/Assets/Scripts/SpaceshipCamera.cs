using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipCamera : MonoBehaviour
{
    public Transform playerCamera;
    public Transform spaceshipOffset;
    public Transform playerViewPane;

    // Update is called once per frame
    void Update()
    {
        Vector3 playerOffsetFromViewPane = playerCamera.position - playerViewPane.position;
        transform.position = spaceshipOffset.position + playerOffsetFromViewPane;

        float angularDifferenceBetweenViewRotation = Quaternion.Angle(spaceshipOffset.rotation, playerViewPane.rotation);

        Quaternion viewRotationalDifference = Quaternion.AngleAxis(angularDifferenceBetweenViewRotation, Vector3.up);
        Vector3 newCameraDirection = viewRotationalDifference * playerCamera.forward;
        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
    }
}
