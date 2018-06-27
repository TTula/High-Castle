using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarracksButton : MonoBehaviour {

    private Barracks thisBarracks;
    private bool isBarracksActive = false;
    private Transform panelChild;

    private void Start()
    {
        panelChild = transform.GetChild(0);
    }

    private void Update()
    {
        if (thisBarracks.GetComponent<Buildings>().isActivated)
        {
            panelChild.gameObject.SetActive(true);
            isBarracksActive = true;
        }
        else
        {
            panelChild.gameObject.SetActive(false);
            isBarracksActive = false;
        }

        if (isBarracksActive)
        {
            GetComponent<RectTransform>().position = Camera.main.WorldToScreenPoint(thisBarracks.transform.position);
        }
    }

    public void AssignBarracks(Transform barracks)
    {
        thisBarracks = barracks.GetComponent<Barracks>();
    }

    public void DestroyButton()
    {
        Destroy(gameObject);
    }
}
