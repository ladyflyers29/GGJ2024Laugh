using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIStuff : MonoBehaviour {

    public TextMeshProUGUI hiScoresList;

    public TextMeshProUGUI scoreText;

    public GameObject menu;

    public GameObject gameOver;

    public Image threatIndicator;

    public string pauseButton;

    public int mainLevelBuildIndex = 0;

    public int tutorialLevelBuildIndex = 1;

    public bool isTutorial;

    void OnEnable() {
        if (GG.uiStuff == null) GG.uiStuff = this;
        else Debug.LogError("MULTIPLE UIs IN THE SCENE! BRUH");
    }

    void Update() {
        // toggle pause menu
        if ( Input.GetButtonDown(pauseButton) ) {
            menu.SetActive( !menu.activeSelf );
        }

        bool isInAMenu = menu.activeInHierarchy || gameOver.activeInHierarchy;

        // TODO set timescale if paused, so the game actually pauses?

        // set cursor visible based on if paused
        if ( isInAMenu ) {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
    
    void LateUpdate() {
        // update score text
        scoreText.text = GG.score.ToString();

        // set threat indicator opacity
        var threatCol = threatIndicator.color;
        threatCol.a = GG.normalizedThreat;
        threatIndicator.color = threatCol;
    }

}
