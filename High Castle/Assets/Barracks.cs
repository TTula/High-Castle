using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barracks : MonoBehaviour {

    public bool isBarracksControlledByPlayer;
    public GameObject barracksButton;

    private GameObject bButton;

    private void Start()
    {
        isBarracksControlledByPlayer = true;
        bButton = Instantiate(barracksButton);
        bButton.GetComponent<BarracksButton>().AssignBarracks(transform);
        bButton.transform.parent = FindObjectOfType<Canvas>().transform;
    }

    private void OnDestroy()
    {
        bButton.GetComponent<BarracksButton>().DestroyButton();
    }
}
