using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour {

    public bool collideWithOtherBuilding = false;

    private void OnTriggerStay(Collider other)
    {
        collideWithOtherBuilding = true;
    }

    private void OnTriggerExit()
    {
        collideWithOtherBuilding = false;
    }

    public void OnBuildingStarted()
    {
        GetComponent<MeshCollider>().convex = true;
        GetComponent<MeshCollider>().isTrigger = true;
    }
}
