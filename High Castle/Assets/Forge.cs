using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forge : MonoBehaviour {

    public bool isForgeControlledByPlayer;
    public GameObject forgeButton;

    private GameObject fButton;

    private void Start()
    {
        isForgeControlledByPlayer = true;
        fButton = Instantiate(forgeButton);
        fButton.GetComponent<ForgeButton>().AssignForge(transform);
        fButton.transform.parent = FindObjectOfType<Canvas>().transform;
    }

    private void OnDestroy()
    {
        fButton.GetComponent<ForgeButton>().DestroyButton();
    }
}
