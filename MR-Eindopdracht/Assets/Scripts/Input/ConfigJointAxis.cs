using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigJointAxis : InputComponent
{
    public ConfigurableJoint joint;
    public bool invert = false;
    
    [System.Serializable]
    public enum Axis { X, Z}
    public Axis axis;
    
    //Returns the angle in a range between -1 and 1
    public override float GetNormalizedAxis()
    {
        float normalized = 0;
        if (axis == Axis.X)
            normalized = Mathf.InverseLerp(this.joint.lowAngularXLimit.limit, this.joint.highAngularXLimit.limit, GetJointAngle());
        else
            normalized = Mathf.InverseLerp(-this.joint.angularZLimit.limit, this.joint.angularZLimit.limit, GetJointAngle());

        normalized = normalized * 2.0f - 1.0f;

        if (this.invert)
            normalized *= -1;

        return normalized;
    }

    public float GetJointAngle()
    {
        float deltaMove;
        if(this.axis == Axis.X)
        {
            deltaMove = this.joint.connectedBody.transform.localPosition.x;
        }
        else
        {
            deltaMove = this.joint.connectedBody.transform.localPosition.z;
        }

        float angle = Mathf.Atan2(this.joint.connectedBody.transform.localPosition.y, deltaMove) * Mathf.Rad2Deg;
        angle -= 90;
        return angle;
    }
}
