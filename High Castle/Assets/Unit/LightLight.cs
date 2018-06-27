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
        if (lightChild) { lightChild.enabled = false; }
        if (meshRenderer) { meshRenderer.enabled = false; }
    }
    public void TurnOn()
    {
        if (lightChild) { lightChild.enabled = true; }
        if (meshRenderer) { meshRenderer.enabled = true; }
    }
}
