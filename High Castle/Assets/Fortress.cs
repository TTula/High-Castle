using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fortress : MonoBehaviour {

    public bool isFortressControlledByPlayer;
    public GameObject fortressButton;
    public float buildingRotationSpeed;

    public static bool buildMode = false; 

    public GameObject forgeBuilding;
    public GameObject barracksBuilding;
    private GameObject fBuilding;
    private GameObject bBuilding;
    private bool isForgeBuilded = false;
    private bool isBarracksBuilded = false;

    private GameObject fButton;
    private CameraControler cameraControler;
    private Terrain terrain;

    private void Start()
    {
        GetComponent<Buildings>().Building();
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
            WhileBuildingForge();
        }
        if (isBarracksBuilded)
        {
            WhileBuildingBarracks();
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

    public void OnBuildingBarracks()
    {
        GetComponent<Buildings>().isActivated = false;
        bBuilding = Instantiate(barracksBuilding);
        bBuilding.transform.SetParent(transform.parent);
        isBarracksBuilded = true;
    }

    private void WhileBuildingForge()
    {
        buildMode = true;
        cameraControler.isCameraZoomEnabled = false;
        float distanceToGround = cameraControler.DistanceToGround(Input.mousePosition.y);
        Vector3 mouseOnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f, 0f, distanceToGround));
        mouseOnPosition = new Vector3(mouseOnPosition.x, 50.1f + terrain.SampleHeight(mouseOnPosition), mouseOnPosition.z);
        bool goodPosition = Mathf.Abs(mouseOnPosition.x - transform.position.x) > 20f || Mathf.Abs(mouseOnPosition.z - transform.position.z) > 20f;
        goodPosition = goodPosition && !fBuilding.GetComponent<Forge>().IsColliding();
        MeshRenderer[] fMeshRenderers = new MeshRenderer[4];
        int h = 0;
        foreach (Transform children in fBuilding.transform)
        {
            if (children.GetComponent<MeshRenderer>())
            {
                fMeshRenderers[h] = children.GetComponent<MeshRenderer>();
                h++;
            }
        }

        if (goodPosition)
        {
            foreach (MeshRenderer mRend in fMeshRenderers)
            {
                mRend.material.color = Color.green;
            }
        }
        else
        {
            foreach (MeshRenderer mRend in fMeshRenderers)
            {
                mRend.material.color = Color.red;
            }
        }
        fBuilding.transform.position = new Vector3(Mathf.Clamp(mouseOnPosition.x, transform.position.x - 40f, transform.position.x + 40f),
            mouseOnPosition.y, Mathf.Clamp(mouseOnPosition.z, transform.position.z - 40f, transform.position.z + 40f));

        fBuilding.transform.Rotate(new Vector3(0f, buildingRotationSpeed * Input.GetAxis("Mouse ScrollWheel")));

        if (Input.GetKey(KeyCode.Mouse0) && goodPosition)
        {
            foreach (MeshRenderer mRend in fMeshRenderers)
            {
                mRend.material.color = Color.white;
            }
            isForgeBuilded = false;
            cameraControler.isCameraZoomEnabled = true;
            buildMode = false;
            fBuilding.GetComponent<Buildings>().Building();
            fBuilding.GetComponentInChildren<Ground>().OnBuildingStarted();
        }
    }

    private void WhileBuildingBarracks()
    {
        buildMode = true;
        cameraControler.isCameraZoomEnabled = false;
        float distanceToGround = cameraControler.DistanceToGround(Input.mousePosition.y);
        Vector3 mouseOnPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0f, 0f, distanceToGround));
        mouseOnPosition = new Vector3(mouseOnPosition.x, 50.1f + terrain.SampleHeight(mouseOnPosition), mouseOnPosition.z);
        bool goodPosition = Mathf.Abs(mouseOnPosition.x - transform.position.x) > 25f || Mathf.Abs(mouseOnPosition.z - transform.position.z) > 25f;
        goodPosition = goodPosition && !bBuilding.GetComponent<Barracks>().IsColliding();
        MeshRenderer[] fMeshRenderers = new MeshRenderer[8];
        int h = 0;
        foreach (Transform children in bBuilding.transform)
        {
            if (children.GetComponent<MeshRenderer>())
            {
                fMeshRenderers[h] = children.GetComponent<MeshRenderer>();
                h++;
            }
        }

        if (goodPosition)
        {
            foreach (MeshRenderer mRend in fMeshRenderers)
            {
                mRend.material.color = Color.green;
            }
        }
        else
        {
            foreach (MeshRenderer mRend in fMeshRenderers)
            {
                mRend.material.color = Color.red;
            }
        }
        bBuilding.transform.position = new Vector3(Mathf.Clamp(mouseOnPosition.x, transform.position.x - 35f, transform.position.x + 35f),
            mouseOnPosition.y, Mathf.Clamp(mouseOnPosition.z, transform.position.z - 35f, transform.position.z + 35f));

        bBuilding.transform.Rotate(new Vector3(0f, buildingRotationSpeed * Input.GetAxis("Mouse ScrollWheel")));

        if (Input.GetKey(KeyCode.Mouse0) && goodPosition)
        {
            foreach (MeshRenderer mRend in fMeshRenderers)
            {
                mRend.material.color = Color.white;
            }
            isBarracksBuilded = false;
            cameraControler.isCameraZoomEnabled = true;
            buildMode = false;
            bBuilding.GetComponent<Buildings>().Building();
            bBuilding.GetComponentInChildren<Ground>().OnBuildingStarted();
        }
    }
}
