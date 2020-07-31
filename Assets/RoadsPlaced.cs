using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoadsPlaced : MonoBehaviour
{
    void Start()
    {
        GetComponent<Text>().text = "Roads Placed:  " + PlayerPrefs.GetInt("roadsPlaced").ToString();

    }
}
