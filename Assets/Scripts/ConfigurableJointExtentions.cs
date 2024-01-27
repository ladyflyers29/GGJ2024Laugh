////////////////////////////////////////////////////////////////////////////////////////
// Code from https://gist.github.com/adriantut/0f36e21809b8fa3832077cdac57d904f
////////////////////////////////////////////////////////////////////////////////////////

using UnityEngine;
// and yes, I've tried https://gist.github.com/mstevenson/4958837 and it didn't work for me

public static class ConfigurableJointExtensions 
{
    public static Quaternion GetJointForwardInWorldSpace(this ConfigurableJoint joint)
    {
        Vector3 right = joint.axis, up = joint.secondaryAxis, forward;
        if(!joint.configuredInWorldSpace)
        {
            right = joint.transform.TransformDirection(joint.axis);
            up = joint.transform.TransformDirection(joint.secondaryAxis);
        }
        forward = Vector3.Cross(right, up);
        return Quaternion.LookRotation(forward, up);    
    }

    // only call this once when the joint has been created & cache it. it's needed for the SetTargetRotationWorld method
    public static Quaternion GetJointInitialRotation(this ConfigurableJoint joint)
    {
        return Quaternion.Inverse(joint.GetJointForwardInWorldSpace()) * joint.connectedBody.transform.rotation;
    }
    
    // set target rotation in world space
    public static void SetTargetRotationWorld(this ConfigurableJoint joint, Quaternion rot, Quaternion initialTargetRotation)
    {
        joint.targetRotation = Quaternion.Inverse(joint.GetJointForwardInWorldSpace()) * rot * Quaternion.Inverse(initialTargetRotation);
    }
}

////////////////////////////////////////////////////////////////////////////////////////