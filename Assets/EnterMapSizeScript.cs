using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class EnterMapSizeScript : MonoBehaviour
{
    bool writable = false;
    public static string mapSizeString = "";
    [SerializeField]
    Text infoText;
    private void Start()
    {
        mapSizeString = "";
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            writable = false;
        }

        if (writable)
        {
            if (mapSizeString.Length != 0 && Input.GetKeyDown(KeyCode.Backspace))
            {
                mapSizeString = mapSizeString.Remove(mapSizeString.Length - 1);
                WriteText();
            }
            else if (Input.anyKeyDown)
            {
                mapSizeString += Input.inputString;
                WriteText();
            }
        }

    }



    public void EnterText()
    {
        writable = true;
    }

    void WriteText()
    {
        try
        {

            transform.GetChild(0).GetComponent<Text>().text = mapSizeString;
            if (mapSizeString.Length != 0 && int.Parse(mapSizeString) > 100)
            {
                mapSizeString = "100";
                WriteText();
            }
            if (mapSizeString.Length != 0 && int.Parse(mapSizeString) > 3)
            {
                if (int.Parse(mapSizeString) > 0 && int.Parse(mapSizeString) <= 8)
                {
                    infoText.text = "Small";
                    infoText.color = Color.green;
                }
                else if (int.Parse(mapSizeString) > 8 && int.Parse(mapSizeString) <= 16)
                {
                    infoText.text = "Moderate";
                    infoText.color = Color.yellow;
                }
                else if (int.Parse(mapSizeString) > 16 && int.Parse(mapSizeString) <= 50)
                {
                    infoText.text = "Large";
                    infoText.color = Color.red;
                }
                else if (int.Parse(mapSizeString) > 50)
                {
                    infoText.text = "Impossible";
                    infoText.color = Color.black;
                }
                CreateCopy.GenerateMapInstant(int.Parse(mapSizeString));
            }
        }
        catch (System.FormatException)
        {
            mapSizeString = "12";
            transform.GetChild(0).GetComponent<Text>().text = mapSizeString;

            if (mapSizeString.Length != 0 && int.Parse(mapSizeString) > 3)
            {
                if (int.Parse(mapSizeString) > 0 && int.Parse(mapSizeString) <= 8)
                {
                    infoText.text = "Small";
                    infoText.color = Color.green;
                }
                else if (int.Parse(mapSizeString) > 8 && int.Parse(mapSizeString) <= 16)
                {
                    infoText.text = "Moderate";
                    infoText.color = Color.yellow;
                }
                else if (int.Parse(mapSizeString) > 16 && int.Parse(mapSizeString) <= 50)
                {
                    infoText.text = "Large";
                    infoText.color = Color.red;
                }
                else if (int.Parse(mapSizeString) > 50)
                {
                    infoText.text = "Impossible";
                    infoText.color = Color.black;
                }
                CreateCopy.GenerateMapInstant(int.Parse(mapSizeString));
            }
            
        }
        

    }
}
