using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarthideMenu : MonoBehaviour
{
    public GameObject gameover;
    public GameObject player;
    public GameObject music;

    // Start is called before the first frame update
    void Start()
    {
        gameover.SetActive(false);
        player.SetActive(true);
        music.SetActive(true);
    }


    private void Update()
    {
        gameover.SetActive(false);
        player.SetActive(true);
        music.SetActive(true);
    }

}
