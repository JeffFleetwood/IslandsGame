using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public List<GameObject> islands;

    private void Awake()
    {
        instance = this;
    }
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

    public Dictionary<GameObject, int> GameLoad(List <GameObject> buildingOptions) 
    {
        Dictionary<GameObject, int> worldState = new Dictionary<GameObject, int>();
        List<Vector3> positions = PlayerPrefsX.GetVector3Array("objectPositions").ToList();
        List<Quaternion> rotations = PlayerPrefsX.GetQuaternionArray("objectRotations").ToList();
        List<Vector3> scales = PlayerPrefsX.GetVector3Array("objectScales").ToList();
        List<int> objectIndex = PlayerPrefsX.GetIntArray("objectsIndex").ToList();

        for (int currentIndex = 0; currentIndex < objectIndex.Count; currentIndex++)
        {
            GameObject loadedObject = Instantiate(buildingOptions[objectIndex[currentIndex]]);
            loadedObject.transform.position = positions[currentIndex];
            loadedObject.transform.rotation = rotations[currentIndex];
            loadedObject.transform.localScale = scales[currentIndex];

            worldState.Add(loadedObject, objectIndex[currentIndex]);
        }
        return worldState;
    }

}
