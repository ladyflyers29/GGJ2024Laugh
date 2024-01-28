using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : MonoBehaviour
{
    public GameObject spawn;
    public GameObject thisobject;
    public AudioSource sound;
    public float targetTime = 10.0f;

    public GameObject Target;
    public float Speed;


  

  

    
    void Update()
    {
        this.transform.LookAt(Target.transform.position);
        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f)
        {
            Instantiate(spawn, thisobject.transform.position, thisobject.transform.rotation);
            sound.Play();
            targetTime = 10.0f;
        }




    }
    


}
