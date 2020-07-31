using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CitiesPlaced : MonoBehaviour
{
    void Start()
    {
        GetComponent<Text>().text = "Cities Placed:  " + PlayerPrefs.GetInt("citiesPlaced").ToString();

    }


}
