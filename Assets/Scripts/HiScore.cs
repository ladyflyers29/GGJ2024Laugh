using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class HiScore : MonoBehaviour {

    const string LASTPLAYERID = "LastPlayerID";

    public TextMeshProUGUI scoreList;
    public TMP_InputField nameInput;
    public Timer holdRestartScore = new(3f);

    static int playerID;

    void Update() {
        if ( Input.GetKey(KeyCode.L) ) {
            if ( holdRestartScore.Tick( false, Time.unscaledDeltaTime ) ) {
                holdRestartScore.Reset();
                PlayerPrefs.DeleteAll();
            }
        }
        else holdRestartScore.Reset();

        var c = scoreList.color;
        c.a = 1f-holdRestartScore.ntime;
        scoreList.color = c;

        playerID = PlayerPrefs.GetInt(LASTPLAYERID, 0) + 1;

        string scoreText = "";
        for (int i = 0; i < playerID; i++) {
            try {
                string name = PlayerPrefs.GetString("player"+i+"Name", null);
                float score = PlayerPrefs.GetFloat("player"+i+"Score", 0);
                if (String.IsNullOrEmpty(name) || score <= 0) continue;
                scoreText += name+" - "+Mathf.FloorToInt(score)+"\n";
            } catch(Exception e){Debug.LogException(e);}
        }
        if (string.IsNullOrEmpty(scoreText)) scoreText = "No High Scores yet!";
        scoreList.text = scoreText;
    }

    void OnDisable() {
        string playername = nameInput.text;
        if ( string.IsNullOrEmpty(playername) ) playername = "Unknown "+playerID;
        PlayerPrefs.SetInt( LASTPLAYERID, playerID );
        PlayerPrefs.SetString("player"+playerID+"Name", playername);
    }

    public static void SubmitScore() {
        PlayerPrefs.SetFloat("player"+playerID+"Score", GG.score);
    }

}
