using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clearfixedjoint : MonoBehaviour
{
   

    
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            Destroy(GetComponent<FixedJoint>());
        }
       
    }
    
}
