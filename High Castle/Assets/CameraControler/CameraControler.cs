using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour {

    public float cameraSpeedLR;
    public float cameraSpeedUD;
    [Tooltip("How far from screen border cursor must be to scroll the camera.")]
    public float borderCameraScroll;

    private bool hasCameraChangedRotation = true;
    private Vector3 directionOfCameraScrollingUD;
    private Vector3 directionOfCameraScrollingLR;

    private void Update()
    {
        if (Input.mousePosition.x < borderCameraScroll * Screen.width)
        {
            gameObject.transform.position += directionOfCameraScrollingLR * Time.deltaTime * cameraSpeedLR;
        }
        if (Input.mousePosition.x > (1f - borderCameraScroll) * Screen.width)
        {
            gameObject.transform.position -= directionOfCameraScrollingLR * Time.deltaTime * cameraSpeedLR;
        }
        if (Input.mousePosition.y < borderCameraScroll * Screen.height)
        {
            gameObject.transform.position += directionOfCameraScrollingUD * Time.deltaTime * cameraSpeedUD;
        }
        if (Input.mousePosition.y > (1f - borderCameraScroll) * Screen.height)
        {
            gameObject.transform.position -= directionOfCameraScrollingUD * Time.deltaTime * cameraSpeedUD;
        }

        if (hasCameraChangedRotation)
        {
            ChangeDirectionOfCameraScrolling();
            hasCameraChangedRotation = false;
            print(directionOfCameraScrollingLR);
            print(directionOfCameraScrollingUD);
        }
    }

    private void ChangeDirectionOfCameraScrolling()
    {
        float arc = transform.rotation.eulerAngles.y * Mathf.PI / 180f;
        print(arc);
        directionOfCameraScrollingUD = new Vector3(-Mathf.Sin(arc), 0f, -Mathf.Cos(arc));
        directionOfCameraScrollingLR = new Vector3(-Mathf.Cos(arc), 0f, Mathf.Sin(arc));
    }
}
