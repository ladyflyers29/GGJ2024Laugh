using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PieHeadShot : MonoBehaviour
{
    public AudioSource sound;
    public GameObject spawn;
    public GameObject thisobject;

    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Pie")
        {

            sound.Play();
            Instantiate(spawn, thisobject.transform.position, thisobject.transform.rotation);
            Destroy(other.transform.parent.gameObject);
            GG.score += 1500;
            //TODO destroy the pie object. Dont know if this is done here or in a script attached to the pie

        }
    }
    */
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Pie")
        {

            sound.Play();
            Instantiate(spawn, thisobject.transform.position, thisobject.transform.rotation);
            Destroy(other.transform.parent.gameObject);
            GG.score += 1500;
            //TODO destroy the pie object. Dont know if this is done here or in a script attached to the pie

        }
    }
}
