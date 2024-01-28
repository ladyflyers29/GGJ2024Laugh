using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fkaerrunman : MonoBehaviour
{
    void OnCollisionStay(Collision other)
    {
      

       
            GG.threat += 5 * Time.deltaTime;

        
    }

    
}

