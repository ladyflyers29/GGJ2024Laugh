using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollPart : MonoBehaviour {
    ///////////////////////////////////////////////////////////////////////////////
    // this code is from https://github.com/Oladipupo/Active-Ragdolls-Unity/blob/master/Sub%20Rosa%20Reloaded/Assets/Scripts/JointFollowAnimRot.cs
    ///////////////////////////////////////////////////////////////////////////////

    public bool invert;

	public float torqueForce;
	public float angularDamping;
	public float maxForce;
	public float springForce;
	public float springDamping;

	public Vector3 targetVel;

	public Transform target;
	private GameObject limb;
	private JointDrive drive;
	private SoftJointLimitSpring spring;
	private ConfigurableJoint joint;
	private Quaternion startingRotation;
    Rigidbody rb;

	void Start () {

        TryGetComponent(out rb);

		torqueForce = 500f;
		angularDamping = 0f;
		maxForce = 500f;

		springForce = 0f;
		springDamping = 0f;

		targetVel = new Vector3(0f, 0f, 0f);

		//drive.positionSpring = torqueForce;
		//drive.positionDamper = angularDamping;
		//drive.maximumForce = maxForce;
//
		//spring.spring = springForce;
		//spring.damper = springDamping;

		joint = gameObject.GetComponent<ConfigurableJoint>();

		//joint.slerpDrive = drive;

		//joint.linearLimitSpring = spring;
		//joint.rotationDriveMode = RotationDriveMode.Slerp;
		//joint.projectionMode = JointProjectionMode.None;
		//joint.targetAngularVelocity = targetVel;
		//joint.configuredInWorldSpace = false;
		//joint.swapBodies = true;
//
		//joint.angularXMotion = ConfigurableJointMotion.Free;
		//joint.angularYMotion = ConfigurableJointMotion.Free;
		//joint.angularZMotion = ConfigurableJointMotion.Free;
		//joint.xMotion = ConfigurableJointMotion.Locked;
		//joint.yMotion = ConfigurableJointMotion.Locked;
		//joint.zMotion = ConfigurableJointMotion.Locked;

		startingRotation = Quaternion.Inverse(target.localRotation);
	}

	void LateUpdate() {
		//if (invert) 
		//	joint.targetRotation = Quaternion.Inverse(target.localRotation * startingRotation);
		//else
		//	joint.targetRotation = target.localRotation * startingRotation;
        //joint.targetRotation = target.localRotation * startingRotation;
        //joint.SetTargetRotationLocal( target.localRotation, startingRotation );
        //joint.SetTargetRotationWorld( target.rotation, startingRotation );
        //if (transform.childCount > 0) {
        //    Transform child = transform.GetChild(0);
        //    Vector3 childLpos = transform.InverseTransformPoint(child.position);
        //    Vector3 goalWpos = target.TransformPoint(childLpos);
        //    Debug.DrawLine( child.position, goalWpos, Color.yellow );
        //    Vector3 vel = Vector3.ClampMagnitude( child.position.VecTo(goalWpos) * torqueForce, 1f );
        //    rb.AddForceAtPosition( vel, child.position, ForceMode.Acceleration );
        //}
        transform.rotation = Quaternion.Slerp( transform.rotation, target.rotation, Time.deltaTime * 20f );
	}

}
