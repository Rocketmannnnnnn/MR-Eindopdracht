using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Lever : InputComponent
{
    private CircularDrive circularDrive;
    public float minAngle = -60;
    public float maxAngle = 60;
    
    void Start()
    {
        this.circularDrive = GetComponent<CircularDrive>();
        this.circularDrive.minAngle = this.minAngle;
        this.circularDrive.maxAngle = this.maxAngle;
    }

    //Returns the angle in a range between -1 and 1
    public override float GetNormalizedAxis()
    {
        return Mathf.InverseLerp(this.minAngle, this.maxAngle, this.circularDrive.outAngle) * 2.0f - 1.0f;
    }
}
