using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bench : MonoBehaviour
{

    public AudioSource sound;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC")
        {

            sound.Play();
            GG.score += 900;
            //TODO apply a amount of points to the score board when the npc sitting on the bench hits the trigger box below it
         

        }
    }
}
