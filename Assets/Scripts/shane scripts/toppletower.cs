using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toppletower : MonoBehaviour
{
    public AudioSource topple;

  
    public int count = 0;
    public int setnumber = 3;

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "CanBeGrabbed")
        {

            count++;

        }

     

        if (count == setnumber)
        {
            topple.Play();
            //TODO apply a amount of points to the score board. 
            GG.score += 1200;
            Destroy(GetComponent<toppletower>());
        }
    }
}
