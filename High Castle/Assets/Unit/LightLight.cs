using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightLight : MonoBehaviour {

    private Light lightChild;
    private MeshRenderer meshRenderer;

    private void Start()
    {
        lightChild = GetComponentInChildren<Light>();
        meshRenderer = GetComponentInChildren<MeshRenderer>();
    }


    public void TurnOff()
    {
        lightChild.enabled = false;
        meshRenderer.enabled = false;
    }
    public void TurnOn()
    {
        lightChild.enabled = true;
        meshRenderer.enabled = true;
    }
}
