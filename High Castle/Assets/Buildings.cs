using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buildings : MonoBehaviour {

    public bool isActivated;
    public float activationDistanceTreshold;

    private CameraControler cameraControler;

    private void Start()
    {
        isActivated = false;
        cameraControler = FindObjectOfType<CameraControler>();
    }

    private void Update()
    {
        if (isActivated)
        {
            GetComponentInChildren<LightLight>().TurnOn();
        } else
        {
            GetComponentInChildren<LightLight>().TurnOff();
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Activation();
        }
    }

    private void Activation ()
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
