using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class featherandglue : MonoBehaviour
{
    public AudioSource feathersound;
    public AudioSource gluesound;

    public GameObject glueeffect;

    public bool isglued = false;

    // public int oneisgluetwoiffeather = 1;

    private void OnTriggerEnter(Collider other)
    {
        
            if (other.tag == "glue")
            {

                gluesound.Play();
                isglued = true;
            glueeffect.SetActive(true);
                GG.score += 250;
                Destroy(other.transform.parent.gameObject);
                //TODO apply a small amount of points to the score board.
                //TODO destroy the glue object. Dont know if this is done here or in a script attached to the glue

            }
        
        else if (other.tag == "feathers")
        {
            feathersound.Play();
            GG.score += 100;
            Destroy(other.transform.parent.gameObject);


            if (isglued == true)
            {
                GG.score += 5500;
                isglued = false;
                glueeffect.SetActive(false);
                Destroy(other.transform.parent.gameObject);
            }

            Destroy(other);
            //TODO apply a very slight amount of points to the score board.
            //TODO if isglued is true then increase the amount of points significantly
            //TODO destroy the feather object. Dont know if this is done here or in a script attached to the feathers
        }
    } }
