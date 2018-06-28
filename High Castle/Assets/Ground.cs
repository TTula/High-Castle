using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {

    public bool collideWithOtherBuilding = false;

    private void OnTriggerEnter()
    {
        collideWithOtherBuilding = true;
    }

    private void OnTriggerExit()
    {
        collideWithOtherBuilding = false;
    }
}
