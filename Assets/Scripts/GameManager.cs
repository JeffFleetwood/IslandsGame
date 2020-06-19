using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> islands;

    private void Start()
    {
        int template = PlayerPrefs.GetInt("IslandCount");
        islands[template].SetActive(true);
    }
}
