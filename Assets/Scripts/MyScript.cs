using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyScript : MonoBehaviour
{
    public Text MyTextVariable;
    public string Spencer;

    public void MyTextScript()
    {
        MyTextVariable.text = Spencer; 
    }
    public void MyMoves()
    {
        MyTextVariable.text = "";
    }
}