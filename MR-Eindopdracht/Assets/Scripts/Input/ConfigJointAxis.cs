using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigJointAxis : InputComponent
{
    public ConfigurableJoint joint;
    
    [System.Serializable]
    public enum Axis { X, Y, Z}
    public Axis axis;
    
    //Returns the angle in a range between -1 and 1
    public override float GetNormalizedAxis()
    {
        switch (this.axis)
        {
            case Axis.X:
                return Mathf.InverseLerp(this.joint.lowAngularXLimit.limit, this.joint.highAngularXLimit.limit, GetJointRotation(this.joint).eulerAngles.x) * 2.0f - 1.0f;
            case Axis.Y:
                return Mathf.InverseLerp(-this.joint.angularYLimit.limit, this.joint.angularYLimit.limit, GetJointRotation(this.joint).eulerAngles.y) * 2.0f - 1.0f;
            default:
                return Mathf.InverseLerp(-this.joint.angularZLimit.limit, this.joint.angularZLimit.limit, GetJointRotation(this.joint).eulerAngles.z) * 2.0f - 1.0f;
        }
    }

    public Quaternion GetJointRotation(ConfigurableJoint joint)
    {
        return (Quaternion.FromToRotation(joint.axis, joint.connectedBody.transform.rotation.eulerAngles));
    }
}
