using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdMovement : MonoBehaviour
{
    public Transform[] target;
    Transform newTarget;

    Animator bassAnimation;

    bool isMoving = false;

    public float speed = 2.0f;

    public float smooth = 10f;

    public bool predator = false;

    void Update()
    {
        if (isMoving == false)
        {
            newTarget = target[Random.Range(0, target.Length)];
            isMoving = true;
        }

        float currentSpeed = speed;
        Vector3 tarpos = newTarget.position;
        if (newTarget.root == GG.mainChar.transform) {
            float dist = Vector3.Distance( transform.position, newTarget.position );
            float dampen = Mathf.InverseLerp( 1f, 10f, dist );
            currentSpeed *= dampen;
            //tarpos.y = transform.position.y; // < this would lock the copper's height
        }
        transform.position = Vector3.MoveTowards(transform.position, tarpos, currentSpeed * Time.deltaTime);

        if (transform.position == newTarget.position)
        {
            isMoving = false;
        }

        //transform.LookAt(newTarget);
        Vector3 dir = transform.VecTo(newTarget.position).normalized;
        if (dir != Vector3.zero) {
            transform.rotation = Quaternion.Slerp(
                transform.rotation, 
                Quaternion.LookRotation( dir, Vector3.up ),
                Time.deltaTime * smooth
            );
        }
    }
}
