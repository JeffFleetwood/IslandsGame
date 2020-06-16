using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBuilding : MonoBehaviour
{
    public List<GameObject> buildingOptions;
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
    bool useNormal = true;

    int clones;
    Vector3 previousPos;

    Camera cam;
    GameObject currentSelectionPreview;

    private void Start()
    {
        cam = Camera.main;
        currentSelectionPreview = Instantiate(buildingOptions[0]);
        currentSelectionPreview.gameObject.layer = LayerMask.NameToLayer("Default");
        currentSelectionPreview.gameObject.SetActive(false);

        renderer.SetPosition(0, Vector3.zero);
        renderer.SetPosition(1, Vector3.zero);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            buildingModeActive = !buildingModeActive;
        }

        currentSelectionPreview.gameObject.SetActive(currentSelectionPreview && buildingModeActive);

        if (!buildingModeActive) return;

        if (Input.GetKeyDown(KeyCode.Tab))
            useNormal = !useNormal;
           
        ChangePreviewPiece();
        CreateBuildPiece();
    }

    void ChangePreviewPiece()  //Changes the currently selected piece with MouseWheel and creates a new preview of it.
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentSelection + 1 >= buildingOptions.Count)
                currentSelection = 0;
            else
                currentSelection++;
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            if (currentSelection - 1 < 0)
                currentSelection = buildingOptions.Count - 1;
            else
                currentSelection--;
        }

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

                    if (clones < maxClones)
                    {
                        if (previousPos != hit.point)
                        {
                            Instantiate(buildingOptions[currentSelection], hit.point, currentSelectionPreview.transform.rotation);
                        }
                        previousPos = hit.point;
                        clones++;
                    }
                    else
                    {
                        Debug.Log("There are too many clones in the scene! " + clones + " " + maxClones);
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

    }
}
