using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneloader : MonoBehaviour
{


    public void LoadSceneByName()
    {
       // player.SetActive(true);
       // music.SetActive(true);
       if ( SceneManager.GetActiveScene().buildIndex == 0 ) {
            GG.uiStuff.menu.SetActive(false);
       }
        else SceneManager.LoadScene(0);
    }

}
