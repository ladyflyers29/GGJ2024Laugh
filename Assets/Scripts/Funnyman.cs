using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Funnyman : MonoBehaviour {

    [SerializeField] float threatLevelDecayPerSecond = 0.2f;

    [NonSerialized] public APRController apr;

    ///<summary> Item held in player's left hand </summary>
    public GameObject leftGrab => apr.GrabLeft.gameObject;

    ///<summary> Item held in player's right hand </summary>
    public GameObject rightGrab => apr.GrabRight.gameObject;
    
    void OnEnable() {
        TryGetComponent(out apr);

        // Set main character to this.
        if (GG.mainChar == null) { GG.mainChar = this; }
        else Debug.LogError("MULTIPLE MAIN CHARS IN SCENE!");

        IEnumerator DelayedInit() {
            yield return new WaitForSecondsRealtime(0.1f);
            GG.InitGame();
        }
        StartCoroutine(DelayedInit());
    }

    void LateUpdate() {
        GG.timeElapsed += Time.unscaledDeltaTime;

        // reduce threat over time
        GG.threat -= Time.deltaTime * threatLevelDecayPerSecond;

        // lose at max threat
        if (GG.normalizedThreat >= 0.98) {
            GG.GameOver();
        }



    }

}
