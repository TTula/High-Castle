using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fortress : MonoBehaviour {

    public bool isFortressControlledByPlayer;
    public GameObject fortressButton;

    private GameObject fButton;

    private void Start()
    {
        isFortressControlledByPlayer = true;
        fButton = Instantiate(fortressButton);
        fButton.transform.parent = FindObjectOfType<Canvas>().transform;
    }

    private void OnDestroy()
    {
        fButton.GetComponent<FortressButton>().DestroyButton();
    }
}
