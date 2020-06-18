using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void OpenMenu(GameObject openMenu)
    {
        openMenu.SetActive(true);
    }

    public void CloseMenu(GameObject closeMenu)
    {
        closeMenu.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
