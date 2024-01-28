using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabPickup : MonoBehaviour
{

    public GameObject spawn;
    public GameObject thisobject;
    public AudioSource sound;

    public GameObject fullparent;


    public GameObject pie;
    public GameObject whoopee;
    public GameObject feathers;
    public GameObject glue;

    int rand = Random.Range(0, 4);

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            rand = Random.Range(0, 4);

            if (rand == 0)
            {
                if (pie.activeSelf == true)
                {
                    rand = Random.Range(0, 4);
                }

                else if (pie.activeSelf == false)
                {
                    sound.Play();
                    Instantiate(spawn, thisobject.transform.position, thisobject.transform.rotation);
                    // Destroy(GetComponent<GrabPickup>());
                    // Destroy(thisobject);

                    fullparent.SetActive(false);
                    pie.SetActive(true);
                    rand = 2;
                }
            }

            else if (rand == 1)
            {
                if (whoopee.activeSelf == true)
                {
                    rand = Random.Range(0, 4);

                }

                else if (whoopee.activeSelf == false)
                {
                    sound.Play();
                    Instantiate(spawn, thisobject.transform.position, thisobject.transform.rotation);
                    // Destroy(GetComponent<GrabPickup>());
                    // Destroy(thisobject);

                    fullparent.SetActive(false);
                    whoopee.SetActive(true);
                    rand = 3;
                }
            }

            else if (rand == 2)
            {
                if (glue.activeSelf == true)
                {
                    rand = Random.Range(0, 4);
                }

                else if (glue.activeSelf == false)
                {
                    sound.Play();
                    Instantiate(spawn, thisobject.transform.position, thisobject.transform.rotation);
                    // Destroy(GetComponent<GrabPickup>());
                    // Destroy(thisobject);

                    fullparent.SetActive(false);
                    glue.SetActive(true);

                    rand = 1;
                }
            }

            else if (rand == 3)
            {
                if (feathers.activeSelf == true)
                {
                    rand = Random.Range(0, 4);
                }

                else if (feathers.activeSelf == false)
                {
                    sound.Play();
                    Instantiate(spawn, thisobject.transform.position, thisobject.transform.rotation);
                    // Destroy(GetComponent<GrabPickup>());
                    // Destroy(thisobject);

                    fullparent.SetActive(false);
                    feathers.SetActive(true);
                    rand = 0;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            rand = Random.Range(0, 4);

            if (rand == 0)
            {
                if (pie.activeSelf == true)
                {
                    rand = Random.Range(0, 4);
                }

                else if (pie.activeSelf == false)
                {
                    sound.Play();
                    Instantiate(spawn, thisobject.transform.position, thisobject.transform.rotation);
                    // Destroy(GetComponent<GrabPickup>());
                    // Destroy(thisobject);

                    fullparent.SetActive(false);
                    pie.SetActive(true);
                     rand = 2;
                }
            }

            else if (rand == 1)
            {
                if (whoopee.activeSelf == true)
                {
                    rand = Random.Range(0, 4);

                }

                else if (whoopee.activeSelf == false)
                {
                    sound.Play();
                    Instantiate(spawn, thisobject.transform.position, thisobject.transform.rotation);
                    // Destroy(GetComponent<GrabPickup>());
                    // Destroy(thisobject);

                    fullparent.SetActive(false);
                    whoopee.SetActive(true);
                     rand = 3;
                }
            }

            else if (rand == 2)
            {
                if (glue.activeSelf == true)
                {
                    rand = Random.Range(0, 4);
                }

                else if (glue.activeSelf == false)
                {
                    sound.Play();
                    Instantiate(spawn, thisobject.transform.position, thisobject.transform.rotation);
                    // Destroy(GetComponent<GrabPickup>());
                    // Destroy(thisobject);

                    fullparent.SetActive(false);
                    glue.SetActive(true);

                    rand = 1;
                }
            }

            else if (rand == 3)
            {
                if (feathers.activeSelf == true)
                {
                    rand = Random.Range(0, 4);
                }

                else if (feathers.activeSelf == false)
                {
                    sound.Play();
                    Instantiate(spawn, thisobject.transform.position, thisobject.transform.rotation);
                    // Destroy(GetComponent<GrabPickup>());
                    // Destroy(thisobject);

                    fullparent.SetActive(false);
                    feathers.SetActive(true);
                     rand = 0;
                }
            }
        }
          
        
        
        /*

        if (other.tag == "Player")
        {

            sound.Play();
            Instantiate(spawn, thisobject.transform.position, thisobject.transform.rotation);
            // Destroy(GetComponent<GrabPickup>());
            // Destroy(thisobject);

            fullparent.SetActive(false);

        }
        */
    }
}
