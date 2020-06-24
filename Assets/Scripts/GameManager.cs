using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public List<GameObject> islands;

    private void Start()
    {
        int template = PlayerPrefs.GetInt("IslandCount");
        islands[template].SetActive(true);
    }
    public void GameSave(Dictionary<GameObject, int> worldState) 
    {
        List<Vector3> positions = new List<Vector3>();
        List<Quaternion> rotations = new List<Quaternion>();
        List<Vector3> scales = new List<Vector3>();
        List<int> objectIndex = new List<int>();

        foreach(KeyValuePair<GameObject, int> gO in worldState) 
        {
            positions.Add(gO.Key.transform.position);
            rotations.Add(gO.Key.transform.rotation);
            scales.Add(gO.Key.transform.localScale);
            objectIndex.Add(gO.Value);
        }

        PlayerPrefsX.SetVector3Array("objectPositions", positions.ToArray());
        PlayerPrefsX.SetQuaternionArray("objectRotations", rotations.ToArray());
        PlayerPrefsX.SetVector3Array("objectScales", scales.ToArray());
        PlayerPrefsX.SetIntArray("objectsIndex", objectIndex.ToArray());


    } 

}
