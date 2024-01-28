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
       
        SceneManager.LoadScene(0);
    }

}
