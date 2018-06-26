using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {

    private Soldier[] soldiers;

    public bool isActivated = false;

    private void Start()
    {
        soldiers = GetComponentsInChildren<Soldier>();
        isActivated = false;
    }

    private void Update()
    {
        if (isActivated)
        {
            foreach (Soldier soldier in soldiers)
            {
                soldier.GetComponentInChildren<LightLight>().TurnOn();
            }
        }
        if (!isActivated)
        {
            foreach (Soldier soldier in soldiers)
            {
                soldier.GetComponentInChildren<LightLight>().TurnOff();
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            
        }

    }

}
