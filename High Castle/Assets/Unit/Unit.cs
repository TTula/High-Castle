using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {

    private Soldier[] soldiers;
    private CameraControler cameraControler;

    public bool isActivated = false;
    public float activationDistanceTreshold;

    private void Start()
    {
        cameraControler = FindObjectOfType<CameraControler>();
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
            Activation();
        }

    }

    private void Activation()
    {
        float distanceToGround = cameraControler.DistanceToGround(Input.mousePosition.y);
        Vector3 mouseClickedPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f, 0f, distanceToGround));
        float distanceToUnit = (mouseClickedPosition - transform.position).magnitude;
        if (distanceToUnit < activationDistanceTreshold)
        {
            isActivated = true;
        }
        else
        {
            isActivated = false;
        }
    }

}
