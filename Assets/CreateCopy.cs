using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCopy : MonoBehaviour
{
    static GameObject dumbGameObject;
    static bool there = false;
    private void Start()
    {
        dumbGameObject = gameObject;
    }
    public static void GenerateMapInstant(float n)
    {
        if (there)
        {
            for (int i = 0; i < dumbGameObject.transform.childCount; i++)
            {
                Destroy(dumbGameObject.transform.GetChild(i).gameObject);
            }
            there = false;
        }
        GameObject hexagon = (GameObject)Resources.Load("Hexagon/HexagonBaseSmol");
        hexagon.transform.localScale = new Vector2(1 / (n / 2.5f), 1 / (n / 2.5f));

        Vector2 position = new Vector2(0, 2.8f);


        for (int rowNum = 1; rowNum <= n; rowNum++) // Antalet
        {
            if (rowNum >= n / 2)
            {
                position.x = 0 - hexagon.transform.localScale.x / 2 * rowNum;

                for (int g = 0; g < rowNum; g++) // Kör antalet
                {
                    GameObject boardHex = (GameObject)Instantiate(hexagon, dumbGameObject.transform);
                    boardHex.transform.position = new Vector3(position.x, position.y, 0);
                    boardHex.transform.localScale = new Vector2(1 / (n / 2.5f), 1 / (n / 2.5f));
                    position.x += hexagon.transform.localScale.x;
                }
                position.y -= hexagon.transform.localScale.y / 1.17647f;
                position.x = 0 - hexagon.transform.localScale.x / 2 * rowNum;

            }

        }

        position.x += hexagon.transform.localScale.x;
        for (float rowNum = n - 1; rowNum > 0; rowNum--) // DOWN
        {
            if (rowNum >= n / 2)
            {
                position.x = 0 - hexagon.transform.localScale.x / 2 * (rowNum); // Go to left

                for (int g = 0; g < rowNum; g++)
                {
                    GameObject boardHex = (GameObject)Instantiate(hexagon, dumbGameObject.transform);
                    boardHex.transform.localScale = new Vector2(1f / (n/ 2.5f) , 1f / (n / 2.5f));
                    boardHex.transform.position = new Vector3(position.x, position.y, 0);
                    position.x += hexagon.transform.localScale.x;
                }
                position.y -= hexagon.transform.localScale.y / 1.17647f;
            }
        }

        there = true;

    }
}
