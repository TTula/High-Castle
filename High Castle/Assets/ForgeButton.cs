using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForgeButton : MonoBehaviour {

    private Forge thisForge;
    private bool isForgeActive = false;
    private Transform panelChild;

    private void Start()
    {
        panelChild = transform.GetChild(0);       
    }

    private void Update()
    {
        if (thisForge.GetComponent<Buildings>().isActivated)
        {
            panelChild.gameObject.SetActive(true);
            isForgeActive = true;
        }
        else
        {
            panelChild.gameObject.SetActive(false);
            isForgeActive = false;
        }

        if (isForgeActive)
        {
            GetComponent<RectTransform>().position = Camera.main.WorldToScreenPoint(thisForge.transform.position);
        }
    }

    public void AssignForge (Transform forge)
    {
        thisForge = forge.GetComponent<Forge>();
    }

    public void DestroyButton()
    {
        Destroy(gameObject);
    }
}
