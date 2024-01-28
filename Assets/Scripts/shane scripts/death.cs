using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class death : MonoBehaviour
{
    public GameObject endstate;

    public GameObject player;
    public GameObject music;
    public GameObject creditsmusic;
    public GameObject damageIcon;
    public float targetTime = 13.0f;



    private void Start()
    {
         player.SetActive(false);
         music.SetActive(false);
        damageIcon.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        targetTime -= Time.deltaTime;
        if (endstate.activeSelf == true)
        {
           // player.SetActive(false);
           // music.SetActive(false);
            damageIcon.SetActive(false);
        }
        if (targetTime <= 0.0f)
        {
            creditsmusic.SetActive(true);
        }
    }


}

   
