using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabPickup : MonoBehaviour
{

    public GameObject spawn;
    public GameObject thisobject;
    public AudioSource sound;

  
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            sound.Play();
            Instantiate(spawn, thisobject.transform.position, thisobject.transform.rotation);
            Destroy(GetComponent<GrabPickup>());
            Destroy(thisobject);

        }
    }
}
