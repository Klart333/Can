using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ThiefScript : MonoBehaviour
{
    public static GameObject gun;
    public static List<GameObject> thiefLights = new List<GameObject>();

    private void Start()
    {
        thiefLights = new List<GameObject>();
        gun = gameObject;
    }
    public static void PlaceThief()
    {

        foreach (GameObject placement in PlacementLists.thiefPlacementList)
        {
            thiefLights.Add((GameObject)Instantiate(Resources.Load("Thief/ThiefLight"), placement.transform.position, Quaternion.identity));
        }
        CostPanelScript.CreateCostPanel(new List<Vector2>(), "Place Gun");
    }
}
