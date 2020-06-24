using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowsXPControl : MonoBehaviour
{
    public GameObject lights;
    public Vector3 rotationModifires;

    void Update()
    {
        lights.transform.Rotate(rotationModifires);
    }
}
