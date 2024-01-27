using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pie : MonoBehaviour
{
   public AudioSource sound;
    public GameObject spawn;
    public GameObject thisobject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pie")
        {

            sound.Play();
            Instantiate(spawn, thisobject.transform.position, thisobject.transform.rotation);
            Destroy(thisobject);
            //TODO apply a amount of points to the score board. the points should be different depending on where the npc is hit
            //TODO destroy the pie object. Dont know if this is done here or in a script attached to the pie

        }
    }
}
