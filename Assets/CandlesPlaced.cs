using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CandlesPlaced : MonoBehaviour
{
    void Start()
    {
        GetComponent<Text>().text = "Candles Placed:  " + PlayerPrefs.GetInt("candlesPlaced").ToString();

    }
}
