﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public void OpenMenu(GameObject openMenu)
    {
        openMenu.SetActive(true);
    }

    public void CloseMenu(GameObject closeMenu)
    {
        closeMenu.SetActive(false);
    }
}
