using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingGGStuff : MonoBehaviour {

    public LayerMask detect;
    public float addThreat = 5;
    public float addScore;

    void OnTriggerEnter(Collider other) {
        if ( detect.Contains(other.gameObject.layer) ) {
            GG.score += addScore;
            GG.threat += addThreat;
        }
    }
}
