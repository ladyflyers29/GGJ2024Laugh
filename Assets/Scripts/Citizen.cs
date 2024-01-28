using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Citizen : MonoBehaviour {
    
    [Serializable] public enum CitizenType {
        Wander = 1,
        SitOnBench = 2,
        StandOnLadder = 3,
        HoldGlass = 4
    }

    static List<Vector3> cacheCorners;

    public Animator animator;
    public Rigidbody rb;
    public NavMeshAgent agent;
    public float pathSearchRadius = 30f;
    public Vector2 minMaxPathWait = new(2f,4f);
    public Timer waitInterval = new(3f);
    public LayerMask pathableLayers;


    void OnEnable() {}

    void Update() {
        bool reachedPath = Vector3.Distance( agent.pathEndPosition, transform.position ) < 1f;

        if ( reachedPath ) {
            if ( !waitInterval.isDone && waitInterval.Tick(false) ) {
                waitInterval.length = minMaxPathWait.RandomWithin();
                waitInterval.Reset();
                agent.path.ClearCorners();
            }
        }
        else {
            waitInterval.Reset();
            if ( !agent.path.IsComplete() ) {
                Vector3 checkPoint = Random.insideUnitSphere;
                checkPoint.y = transform.position.y + 20f;

                if ( Physics.Raycast(checkPoint, Vector3.down, out var rch, 50f, pathableLayers) ) {
                    NavMesh.CalculatePath( transform.position, rch.point, int.MaxValue, agent.path );
                }
            }
        }
    }

    void OnDrawGizmosSelected() {
        if (agent == null || agent.path == null) return;
        agent.path.DrawPath(Color.green);
    }


}
