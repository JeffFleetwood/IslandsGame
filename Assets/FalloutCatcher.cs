using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalloutCatcher : MonoBehaviour
{
    public float maxFall = -25;
    public float spwnHeight = 75;
    private PlayerController PlyrCtrlDisable;

    // Update is called once per frame
    private void Start()
    {
        PlyrCtrlDisable = GetComponent<PlayerController>();
    }

    void Update()
    {
        if (transform.position.y < maxFall)
        {
            Debug.Log("fell to far reset");
            PlyrCtrlDisable.enabled = false;
            transform.position = new Vector3(transform.position.x, spwnHeight, transform.position.z);
            PlyrCtrlDisable.enabled = true;
        } 
    }
}
