using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GG {

    public static float score;

    public static float timeElapsed;

    ///<summary> How close player is to losing, where 0 = no threat, 100 = max threat (game over) </summary>
    public static float threat { get => _threat; set => _threat = Mathf.Clamp( value, 0f, 100f ); }
    static float _threat;

    ///<summary> How close player is to losing, where 0 = no threat, 1 = max threat (game over) </summary>
    public static float normalizedThreat => threat / 100f;

    public static Funnyman mainChar;

    public static CameraController camera;

    public static UIStuff uiStuff;

    public static bool IsPlayer(Collision other) {
        if ( other.gameObject.tag == "Player" ) return true;
        else return false;
    }

    /*
    void OnCollisionStay(Collision other) {
        if ( GG.IsPlayer(other) ) {
            GG.threat += someRatePerSecond * Time.deltaTime;
        }
    }

    bool hasSpawned;

        if ( GG.score > 10000 && !hasSpawned ) {
            hasSpawned = true;
            var child = transform.GetChild( UnityEngine.Random.Range(0, transform.childCount) );
            child.gameObject.SetActive(true);
        }
    */


    public static void RestartGame() {
        // TODO load tutorial scene
        // TODO unpause game
    }


    public static void GameOver() {
        uiStuff.gameOver.SetActive(true);
        HiScore.SubmitScore();
    }


    // Only the funnyman should call this
    public static void InitGame() {
        threat = 0;
        score = 0;
        timeElapsed = 0;
        uiStuff.threatIndicator.gameObject.SetActive(true);
        uiStuff.gameOver.SetActive(false);
        uiStuff.menu.SetActive( uiStuff.isTutorial );
    }

}
