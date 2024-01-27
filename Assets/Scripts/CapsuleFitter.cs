using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils {
    public static void ApplyCapsule( Transform targetBone, Vector3 headPoint, Vector3 tailPoint, float radius ) {
        // Get or create capsule on target
        CapsuleCollider collider = targetBone.GetComponent<CapsuleCollider>();
        if (collider == null) collider = targetBone.gameObject.AddComponent<CapsuleCollider>();

        Vector3 P1 = targetBone.InverseTransformPoint(headPoint);
        Vector3 P2 = targetBone.InverseTransformPoint(tailPoint);

        ///////////////////////////////////////////// the following was mostly made by ChatGPT
        // Calculate the distance between two points
        float distance = Vector3.Distance(P1, P2);

        // Determine the best axis to use based on the vector from P1 to P2
        Vector3 vector = P2 - P1;
        Vector3 absVector = new Vector3(Mathf.Abs(vector.x), Mathf.Abs(vector.y), Mathf.Abs(vector.z));
        int axis = absVector.x < absVector.y ? 1 : 0;
        axis = absVector[axis] < absVector.z ? 2 : axis;

        // Calculate the position of the GameObject
        Vector3 midpoint = Vector3.Lerp(P1, P2, 0.5f);//(P1 + P2) / 2;

        // Set the position of the GameObject
        collider.center = midpoint;

        // Set the size and radius of the CapsuleCollider
        collider.radius = radius;
        collider.height = distance + radius * 2;

        // Set the orientation of the CapsuleCollider based on the axis
        if (axis == 0) collider.direction = 0; // X-axis
        else if (axis == 1) collider.direction = 1; // Y-axis
        else collider.direction = 2; // Z-axis
        /////////////////////////////////////////////////////////////
        // we're screwed bruh
    }
}