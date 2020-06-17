using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IslandMenu : MonoBehaviour
{
    public Image displayimage;
    public Sprite[] IslandImages;
    public GameObject[] IslandTemplates;
    public int index;

    public void Start() 
    {
        displayimage.sprite = IslandImages[0];
}
    public void PreviousIsland() 
    {
        if (index > 0)
        {
            index -= 1;
        }
        displayimage.sprite = IslandImages[index];
    }
    public void NextIsland()
    {
        if (index < IslandImages.Length -1)
        {
            index += 1;
        }
        displayimage.sprite = IslandImages[index]; 
    }

    public void SelectIsland()
    {
        Debug.Log("Works");
        IslandTemplates[index].SetActive(true);
    }
}