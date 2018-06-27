using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FortressButton : MonoBehaviour {

    private Fortress myFortress;
    private bool isFortressActive = false;
    private Transform panelChild;

    private void Start()
    {
        panelChild = transform.GetChild(0);
        foreach (Fortress fortress in FindObjectsOfType<Fortress>())
        {
            if (fortress.isFortressControlledByPlayer)
            {
                myFortress = fortress;
            }
        }
    }

    private void Update()
    {
        if (myFortress.GetComponent<Buildings>().isActivated)
        {
            panelChild.gameObject.SetActive(true);
            isFortressActive = true;
        } else
        {
            panelChild.gameObject.SetActive(false);
            isFortressActive = false;
        }

        if (isFortressActive)
        {
            GetComponent<RectTransform>().position = Camera.main.WorldToScreenPoint(myFortress.transform.position);
        }
    }


}
