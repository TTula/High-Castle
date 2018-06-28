using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barracks : MonoBehaviour {

    public bool isBarracksControlledByPlayer;
    public GameObject barracksButton;

    private GameObject bButton;
    private Ground ground;

    private void Start()
    {
        ground = GetComponentInChildren<Ground>();
        isBarracksControlledByPlayer = true;
        bButton = Instantiate(barracksButton);
        bButton.GetComponent<BarracksButton>().AssignBarracks(transform);
        bButton.transform.parent = FindObjectOfType<Canvas>().transform;
    }

    public bool IsColliding()
    {
        return ground.collideWithOtherBuilding;
    }

    private void OnDestroy()
    {
        bButton.GetComponent<BarracksButton>().DestroyButton();
    }
}
