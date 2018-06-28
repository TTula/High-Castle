using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fortress : MonoBehaviour {

    public bool isFortressControlledByPlayer;
    public GameObject fortressButton;

    public GameObject forgeBuilding;
    private GameObject fBuilding;
    private bool isForgeBuilded = false;

    private GameObject fButton;
    private CameraControler cameraControler;
    private Terrain terrain;

    private void Start()
    {
        isFortressControlledByPlayer = true;
        fButton = Instantiate(fortressButton);
        fButton.transform.parent = FindObjectOfType<Canvas>().transform;
        cameraControler = FindObjectOfType<CameraControler>();
        terrain = FindObjectOfType<Terrain>();
    }

    private void Update()
    {
        if (isForgeBuilded)
        {
            float distanceToGround = cameraControler.DistanceToGround(Input.mousePosition.y);
            Vector3 mouseOnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f, 0f, distanceToGround));
            mouseOnPosition = new Vector3(mouseOnPosition.x, 50.1f + terrain.SampleHeight(mouseOnPosition), mouseOnPosition.z);
            bool goodPosition = Mathf.Abs(mouseOnPosition.x - transform.position.x) < 40f && Mathf.Abs(mouseOnPosition.x - transform.position.x) > 20f
                && Mathf.Abs(mouseOnPosition.z - transform.position.z) < 40f && Mathf.Abs(mouseOnPosition.z - transform.position.z) > 20f;
            MeshRenderer[] fMeshRenderers = fBuilding.transform.GetComponentsInChildren<MeshRenderer>();

            if (goodPosition)
            {
                foreach (MeshRenderer mRend in fMeshRenderers)
                {
                    mRend.material.color = Color.green;
                }
            } else
            {
                foreach (MeshRenderer mRend in fMeshRenderers)
                {
                    mRend.material.color = Color.red;
                }
            }
            fBuilding.transform.position = mouseOnPosition;
            if (Input.GetKey(KeyCode.Mouse0))
            {
                foreach (MeshRenderer mRend in fMeshRenderers)
                {
                    mRend.material.color = Color.white;
                }
                isForgeBuilded = false;
            }
        }
    }

    private void OnDestroy()
    {
        fButton.GetComponent<FortressButton>().DestroyButton();
    }

    public void OnBuildingForge()
    {
        GetComponent<Buildings>().isActivated = false;
        fBuilding = Instantiate(forgeBuilding);
        fBuilding.transform.SetParent(transform.parent);
        isForgeBuilded = true;
    }
}
