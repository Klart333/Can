using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMap : MonoBehaviour
{
    private void Start()
    {
        try
        {
            StartCoroutine("GenerateMap", int.Parse(EnterMapSizeScript.mapSizeString));
        }
        catch (System.FormatException)
        {
            StartCoroutine("GenerateMap", 8);
        }
     
        
        //GenerateMapInstant(int.Parse(EnterMapSizeScript.mapSizeString));
    }


    public IEnumerator GenerateMap(int n)
    {
        GameObject hexagon = (GameObject)Resources.Load("Hexagon/HexagonBase");
        Vector2 position = new Vector2();

        for (int rowNum = 1; rowNum <= n; rowNum++) // Antalet
        {
            if (rowNum >= n / 2)
            {
                position.x = 0 - hexagon.transform.localScale.x / 2 * rowNum;

                for (int g = 0; g < rowNum; g++) // Kör antalet
                {
                    GameObject boardHex = (GameObject)Instantiate(hexagon, gameObject.transform);
                    boardHex.transform.position = new Vector3(position.x, position.y, 0);
                    position.x += hexagon.transform.localScale.x;
                    yield return new WaitForEndOfFrame();
                }
                position.y -= 0.85f; // JUMP DOWN 
                position.x = 0 - hexagon.transform.localScale.x / 2 * rowNum;

            }
            
        }

        position.x += hexagon.transform.localScale.x;
        for (int rowNum = n - 1; rowNum > 0; rowNum--) // DOWN
        {
            if (rowNum >= n / 2)
            {
                position.x = 0 - hexagon.transform.localScale.x / 2 * (rowNum); // Go to left

                for (int g = 0; g < rowNum; g++)
                {
                    GameObject boardHex = (GameObject)Instantiate(hexagon, gameObject.transform);
                    boardHex.transform.position = new Vector3(position.x, position.y, 0);
                    position.x += hexagon.transform.localScale.x;
                    yield return new WaitForEndOfFrame();
                }
                position.y -= 0.85f; // jump down
            }
        }
        Hexagons.TitleMap();
    }

    public  void GenerateMapInstant(int n)
    {
        GameObject hexagon = (GameObject)Resources.Load("Hexagon/HexagonBase");
        Vector2 position = new Vector2();

        for (int rowNum = 1; rowNum <= n; rowNum++) // Antalet
        {
            if (rowNum >= n / 2)
            {
                position.x = 0 - hexagon.transform.localScale.x / 2 * rowNum;

                for (int g = 0; g < rowNum; g++) // Kör antalet
                {
                    GameObject boardHex = (GameObject)Instantiate(hexagon, gameObject.transform);
                    boardHex.transform.position = new Vector3(position.x, position.y, 0);
                    position.x += hexagon.transform.localScale.x;
                }
                position.y -= hexagon.transform.localScale.y / 1.18f;
                position.x = 0 - hexagon.transform.localScale.x / 2 * rowNum;

            }

        }

        position.x += hexagon.transform.localScale.x;
        for (int rowNum = n - 1; rowNum > 0; rowNum--) // DOWN
        {
            if (rowNum >= n / 2)
            {
                position.x = 0 - hexagon.transform.localScale.x / 2 * (rowNum); // Go to left

                for (int g = 0; g < rowNum; g++)
                {
                    GameObject boardHex = (GameObject)Instantiate(hexagon, gameObject.transform);
                    boardHex.transform.position = new Vector3(position.x, position.y, 0);
                    position.x += hexagon.transform.localScale.x;
                }
                position.y -= hexagon.transform.localScale.y / 0.875f; // jump down
            }
        }


        Hexagons.TitleMap();
        
    }
}
