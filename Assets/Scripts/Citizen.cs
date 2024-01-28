using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Citizen : MonoBehaviour {
    
    [Serializable] public enum CitizenType {
        Wander = 1,
        SitOnBench = 2,
        StandOnLadder = 3,
        HoldGlass = 4
    }
    

}
