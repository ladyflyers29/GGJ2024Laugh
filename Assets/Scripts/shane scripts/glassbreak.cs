using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glassbreak : MonoBehaviour
{

    public AudioSource sound;
    public GameObject broken;
    public GameObject whole;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //TODO apply an amount of points to the score board
            GG.score += 1200;
            sound.Play();
            broken.SetActive(true);
            whole.SetActive(false);
          
        }
    }
}
