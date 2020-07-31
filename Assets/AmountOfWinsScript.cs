using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AmountOfWinsScript : MonoBehaviour
{
    void Start()
    {
        GetComponent<Text>().text = "Wins:  " + PlayerPrefs.GetInt("wins").ToString();
    }


}
