using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPositionPrinter : MonoBehaviour
{
    public InputComponent moveX;
    public InputComponent moveY;
    public InputComponent moveZ;
    public InputComponent rotationX;
    public InputComponent rotationY;
    public InputComponent rotationZ;

    private void FixedUpdate()
    {
        Vector3 motion = new Vector3(moveX?.GetNormalizedAxis() ?? 0, moveY?.GetNormalizedAxis() ?? 0, moveZ?.GetNormalizedAxis() ?? 0);
        Vector3 angular = new Vector3(rotationX?.GetNormalizedAxis() ?? 0, rotationY?.GetNormalizedAxis() ?? 0, rotationZ?.GetNormalizedAxis() ?? 0);
        Debug.Log("Motion: " + motion + ". Angular motion: " + angular);
    }
}
