using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class ActiveRagdoll : MonoBehaviour {

    //public RagdollPart template;
    public Transform original;
    public Rigidbody rbTemplate;
    public ConfigurableJoint jointTemplate;
    //public Transform root;
    public float autoColliderRadius = 0.1f;
    public float leafBoneLength = 0.2f;
    public float perBoneMass = 1f;
    public float perBoneMassScale = 1f;

    public Transform placeDuplicateHere;

    List<RagdollPart> joints = new();

    void OnEnable() {
        //if ( root == null ) throw new("Assign the root of the character's rig to the "+nameof(root)+" field plz");
        //if ( template == null ) throw new("Assign a "+nameof(RagdollPart)+" component to the "+nameof(template)+" field plz"+
                //"(The component can be attached to anything, like a prefab somewhere. doesn't need to be in scene)");

        /*int iter = 0;
        void Recurse(Transform parent, Transform bone) {
            iter++;
            if (iter > 100) throw new("Bro somethin iz wrong here");
            
            var newJointGO = Instantiate(template.gameObject, bone.position, bone.rotation, parent);

            #if UNITY_EDITOR
            newJointGO.name = bone.name+" Copy";
            #endif

            var newJoint = newJointGO.GetComponent<RagdollPart>();
            newJoint.copyFrom = bone;
            newJoint.joint.connectedBody = parent?.GetComponent<Rigidbody>();

            joints.Add( newJoint );

            foreach (Transform child in bone) {
                Recurse(newJointGO.transform, child);
            }
        }*/
        //Recurse(null, root);
        //var topmost = joints[0];
        //topmost.copyFrom = root;
        //topmost.transform.localRotation = Quaternion.identity;
        //topmost.transform.localPosition = Vector3.zero;
        //topmost.transform.localScale = Vector3.one;

    }

    void OnValidate() {
        #if UNITY_EDITOR
        if (EditorApplication.isPlaying) return;
        #endif
        if ( placeDuplicateHere != null ) {
            if (jointTemplate == null) throw new("Cannot complete duplicate without a "+nameof(jointTemplate)+" assigned!");
            if (rbTemplate == null) throw new("Cannot complete duplicate without a "+nameof(rbTemplate)+" assigned!");

            int iter = 0;
            void Recurse(Transform parent, Transform bone) {
                iter++;
                if (iter > 1000) throw new("Bro somethin iz sus here, too many recursions");

                Vector3 calculatedBoneTail = Vector3.zero;
                if ( bone.childCount > 0 ) {
                    foreach( Transform child in bone ) {
                        calculatedBoneTail += child.position;
                    }
                    calculatedBoneTail /= bone.childCount;
                }
                else calculatedBoneTail = bone.position + (bone.forward * leafBoneLength);

                Utils.ApplyCapsule(bone, bone.position, calculatedBoneTail, autoColliderRadius);

                Rigidbody boneRB;
                if ( !bone.TryGetComponent(out boneRB) ) boneRB = bone.gameObject.AddComponent<Rigidbody>();
                boneRB.mass = perBoneMass;

                RagdollPart bonePart;
                if ( !bone.TryGetComponent(out bonePart) ) bonePart = bone.gameObject.AddComponent<RagdollPart>();
                bonePart.target = original.FindRecursive(bone.name);

                ConfigurableJoint boneJoint;
                if ( !bone.TryGetComponent(out boneJoint) ) boneJoint = bone.gameObject.AddComponent<ConfigurableJoint>();
                boneJoint.connectedBody = parent?.GetComponent<Rigidbody>();
                boneJoint.xMotion = boneJoint.yMotion = boneJoint.zMotion = ConfigurableJointMotion.Locked;
                boneJoint.projectionMode = JointProjectionMode.PositionAndRotation;
                boneJoint.massScale = perBoneMassScale;

                foreach (Transform child in bone) {
                    Recurse(bone, child);
                }
            }
            Recurse(null, placeDuplicateHere.GetChild(0));
        }
    }

    void Update() {
        
    }

    void LateUpdate() {
        
    }

}
