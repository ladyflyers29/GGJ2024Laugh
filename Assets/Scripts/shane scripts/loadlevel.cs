using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadlevel : MonoBehaviour
{
    [SerializeField] private List<Scene> _sceneList;

    int currentScene = SceneManager.GetActiveScene().buildIndex;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(1);
        }
        /*
            // SceneManager.LoadScene("ShaneTesting", LoadSceneMode.Additive);
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (SceneManager.sceneCountInBuildSettings > nextSceneIndex)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        */
    }

   



}
