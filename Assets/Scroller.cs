using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour
{
    public float scrollSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, scrollSpeed * Time.deltaTime, 0);
    }
}
