using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
public class Hexagons : MonoBehaviour
{

    public class Tile
    {
        public GameObject gameObject { get; set; }
        public string resource { get; set; }
        public int diceNumber { get; set; }
        public int cityMultiplier { get; set; }

    }
    public static List<Tile> hexagons = new List<Tile>();

    static GameObject dumbGameObject;
    private void Start()
    {
        dumbGameObject = gameObject;
    }

    public static void TitleMap()
    {
        hexagons = new List<Tile>();
        for (int i = 0; i < dumbGameObject.transform.childCount; i++)
        {
            GameObject child = dumbGameObject.transform.GetChild(i).gameObject;

            int randNumr = Random.Range(1, 6);
            if (randNumr == 1)
            {
                child.name = "Wood";
            }
            else if (randNumr == 2)
                child.name = "Clay";
            else if (randNumr == 3)
                child.name = "Sheep";
            else if (randNumr == 4)
                child.name = "Wheat";
            else if (randNumr == 5)
                child.name = "Stone";
            child.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Hexagon/Hexagon" + child.name);

            int randNumDice = Random.Range(2, 13);
            while (randNumDice == 7)
            {
                randNumDice = Random.Range(2, 13);
            }
            child.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Numbers/" + randNumDice);

            hexagons.Add(new Tile());
            Tile hexagon = hexagons[i];

            hexagon.gameObject = child;
            hexagon.resource = child.name;
            hexagon.diceNumber = randNumDice;

            
        }
        //After the map is created and after it is given values, we do the placement lists
        PlacementLists.UpdateAvailableRoads();
        PlacementLists.UpdateAvailableHouses();
        PlacementLists.UpdateAvailableCities();
        PlacementLists.UpdateAvailableThiefs();
        PlacementLists.UpdateAvailableCandles();
        PlacementLists.UpdateDynamitePlacement();

        if (BotScript.botAmount == 4)
        {
            GameObject.Find("NextPlayerPanel").GetComponent<NextTurnScript>().NextTurn();
        }

    }

}
