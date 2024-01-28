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
            GG.score += 500;
            //TODO destroy the pie object. Dont know if this is done here or in a script attached to the pie

        }
    }
}
