using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhoopeeCushion : MonoBehaviour
{
    public AudioSource fart;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC")
        {

            fart.Play();
            GG.score += 50;
        }
    }
}
