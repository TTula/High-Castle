using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour {

    public float cameraSpeedLR;
    public float cameraSpeedUD;
    public float cameraRotSpeed;
    [Tooltip("How far from screen border cursor must be to scroll the camera.")]
    [Range(0f,1f)]
    public float borderCameraScroll;

    private bool hasCameraChangedRotation = false;
    private Vector3 directionOfCameraScrollingUD;
    private Vector3 directionOfCameraScrollingLR;

    private float firstPositionOfMouseCameraRotation;
    private float firstRotationOfCamera;

    private void Start()
    {
        ChangeDirectionOfCameraScrolling();
    }

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

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            firstPositionOfMouseCameraRotation = Input.mousePosition.x;
            firstRotationOfCamera = transform.rotation.eulerAngles.y;
            hasCameraChangedRotation = true;
        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            hasCameraChangedRotation = false;
        }

        if (hasCameraChangedRotation)
        {
            transform.rotation = Quaternion.Euler(45f, firstRotationOfCamera + (Input.mousePosition.x - firstPositionOfMouseCameraRotation) * cameraRotSpeed, 0f);
            ChangeDirectionOfCameraScrolling();
        }
    }

    private void ChangeDirectionOfCameraScrolling()
    {
        float arc = transform.rotation.eulerAngles.y * Mathf.PI / 180f;
        directionOfCameraScrollingUD = new Vector3(Mathf.Sin(arc), 0f, Mathf.Cos(arc));
        directionOfCameraScrollingLR = new Vector3(Mathf.Cos(arc), 0f, -Mathf.Sin(arc));
    }
}
