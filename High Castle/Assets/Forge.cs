using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forge : MonoBehaviour {

    public bool isForgeControlledByPlayer;
    public GameObject forgeButton;

    private GameObject fButton;
    private Ground ground;

    private void Start()
    {
        ground = GetComponentInChildren<Ground>();
        isForgeControlledByPlayer = true;
        fButton = Instantiate(forgeButton);
        fButton.GetComponent<ForgeButton>().AssignForge(transform);
        fButton.transform.parent = FindObjectOfType<Canvas>().transform;
    }

    public bool IsColliding()
    {
        return ground.collideWithOtherBuilding;
    }

    private void OnDestroy()
    {
        fButton.GetComponent<ForgeButton>().DestroyButton();
    }
}
