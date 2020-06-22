using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public GameObject menu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menu.activeSelf == true)
            {
                menu.SetActive(false);
                Time.timeScale = 1;
            }

            else
            {
                menu.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}
