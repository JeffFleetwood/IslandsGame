using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBuilding : MonoBehaviour
{
    /*public List<GameObject> buildingOptions;
    public float rayDistance = 100;
    public float rotateSpeed = 5f;
    public LayerMask environmentLayer;
    public LineRenderer renderer;

    public float smoothSpeed = 75f;
    public int maxClones;
    public bool useHoldMech;

    Vector3 rotation;

    int lastSelection;
    int currentSelection;

    float scrollWheel;

    bool buildingModeActive;
    bool destroyModeActive;
    bool useNormal = true;

    int clones;
    Vector3 previousPos;

    Camera cam;
    GameObject currentSelectionPreview;*/

    /*private void Start()
    {
        cam = Camera.main;
        currentSelectionPreview = Instantiate(buildingOptions[0]);
        currentSelectionPreview.gameObject.layer = LayerMask.NameToLayer("Default");
        currentSelectionPreview.gameObject.SetActive(false);

        renderer.SetPosition(0, Vector3.zero);
        renderer.SetPosition(1, Vector3.zero);
    }*/

    private void Update()
    {
        NotRealInput();

        /*if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            buildingModeActive = !buildingModeActive;
            destroyModeActive = false;

            renderer.startColor = Color.green;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            destroyModeActive = !destroyModeActive;
            buildingModeActive = false;

            renderer.startColor = Color.red;
        }

        currentSelectionPreview.gameObject.SetActive(currentSelectionPreview && buildingModeActive);

        Build();*/
    }

    void NotRealInput()
    {
        bool buildMode = false;
        bool selectionMode = false;
        bool rotateMode = true;
        bool scaleMode = false;
        bool destroyMode = false;
        bool mode = false;
        int progress = 0;

        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            progress = 0;
        }

        if (!destroyMode && !buildMode && Input.GetKeyDown(KeyCode.Alpha2))
        {
            progress = 1;
            mode = false;
        }

        if (!destroyMode && !buildMode && Input.GetKeyDown(KeyCode.Alpha1))
        {
            mode = true;
            progress = 1;
            Debug.Log("Menu progress: " + progress);
            return;
        }
        
        if (!selectionMode && Input.GetKeyDown(KeyCode.Alpha1))
        {
            progress = 2;
            Debug.Log("Menu progress: " + progress);
            return;
        }

        if (!rotateMode && Input.GetKeyDown(KeyCode.Alpha2))
        {
            progress = 2;
            Debug.Log("Menu progress: " + progress);
            return;
        }

        if (!scaleMode && Input.GetKeyDown(KeyCode.Alpha3))
        {
            progress = 2;
            Debug.Log("Menu progress: " + progress);
            return;
        }

        if (Input.GetKey(KeyCode.Alpha4))
        {
            if (progress < 1)
            {
                progress--;
            }
            else
            {
                Debug.LogError("Progress can not be less than zero you fool!");
            }
        }

        switch (progress)
        {
            case 0:
                buildMode = false;
                selectionMode = false;
                rotateMode = true;
                scaleMode = false;
                destroyMode = false;
                Debug.Log("Progress Values Reset!");
                break;
            case 1:
                if (!mode)
                {
                    destroyMode = true;
                    buildMode = false;
                    Debug.Log("Welcome to destory mode!");
                }
                else
                {
                    destroyMode = false;
                    buildMode = true;
                    selectionMode = false;
                    Debug.Log("Welcome to build mode!");
                }
                break;
            case 2:
                selectionMode = true;
                Debug.Log("Welcome to selection mode!");
                break;
            default:
                Debug.LogError("Progress is overflowing the switch!");
                break;
        }

        if (buildMode)
        {
            //BuildModeMethodHere

            if (selectionMode)
            {
                //SelectionModeMethodHere

                if (rotateMode)
                {
                    //RotateModeCodeHere
                }
                
                if (scaleMode)
                {
                    //ScaleModeCodeHere
                }
            }
        }

    }

    /*void Build()
    {
        if (buildingModeActive)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                useNormal = !useNormal;
            }

            ChangePreviewPiece();
            CreateBuildPiece();
        }

        if (destroyModeActive)
        {
            DestroyObject();
        }
    }

    void DestroyObject()
    {
        RaycastHit hit;
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);

        if (Physics.Raycast(ray, out hit, rayDistance, environmentLayer))
        {
            renderer.SetPosition(0, transform.position + new Vector3(0, 1f, 0));
            renderer.SetPosition(1, hit.point);

            if (Input.GetKey(KeyCode.Mouse0))
            {

                if (hit.collider.gameObject.tag == "DestroyMe")
                {
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }

    void ChangePreviewPiece()  //Changes the currently selected piece with MouseWheel and creates a new preview of it.
    {

        scrollWheel = Input.GetAxisRaw("Mouse ScrollWheel");

        Debug.Log(scrollWheel);

        if (scrollWheel >= .1)
        {
            Debug.Log(" > 1");
            if (currentSelection + 1 >= buildingOptions.Count)
                currentSelection = 0;
            else
                currentSelection++;
        }
        else if (scrollWheel <= -0.1)
        {
            Debug.Log("< 1");
            if (currentSelection - 1 < 0)
                currentSelection = buildingOptions.Count - 1;
            else
                currentSelection--;
        }

        scrollWheel = 0;

        if (currentSelection != lastSelection && currentSelectionPreview)
        {
            lastSelection = currentSelection;
            Destroy(currentSelectionPreview);
            currentSelectionPreview = Instantiate(buildingOptions[currentSelection].gameObject);
            currentSelectionPreview.gameObject.layer = LayerMask.NameToLayer("Default");
        }
    }

    void CreateBuildPiece()
    {
        RaycastHit hit;
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        if (Physics.Raycast(ray, out hit, rayDistance, environmentLayer))
        {
            renderer.SetPosition(0, transform.position + new Vector3(0, 1f, 0));
            renderer.SetPosition(1, hit.point);

            if (currentSelectionPreview)
            {
                currentSelectionPreview.transform.position = hit.point;

                if (useNormal)
                    currentSelectionPreview.transform.rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
                else
                    currentSelectionPreview.transform.rotation = Quaternion.Euler(Vector3.up);

                RotatePiece();
            }

            if (useHoldMech)
            {
                if (Input.GetKey(KeyCode.Mouse0))
                {

                    if (hit.collider.gameObject.tag != "DestroyMe")
                    {
                        if (clones < maxClones)
                        {
                            if (previousPos != hit.point)
                            {
                                Instantiate(buildingOptions[currentSelection], hit.point, currentSelectionPreview.transform.rotation);
                            }
                            previousPos = hit.point;
                            clones++;
                        }

                    }
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    Instantiate(buildingOptions[currentSelection], hit.point, currentSelectionPreview.transform.rotation);
                }
            }
            
        }
    }

    void RotatePiece()
    {
        scrollWheel += Input.mouseScrollDelta.y;

        if (currentSelectionPreview)
        {
            currentSelectionPreview.transform.Rotate(Vector3.up, scrollWheel * rotateSpeed);
        }

    }*/
}
