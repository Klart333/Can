using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

public class ObjectOnBoardLists : MonoBehaviour
{
    public class House
    {
        public GameObject gameObject { get; set; }
        public PlayerScript.Player player { get; set; }
    }
    public class Candle
    {
        public GameObject gameObject { get; set; }
        public PlayerScript.Player player { get; set; }
        public int placementNumber { get; set; }
    }
    public class Road
    {
        public GameObject gameObject { get; set; }
        public PlayerScript.Player player { get; set; }
    }
    public class City
    {
        public GameObject gameObject { get; set; }
        public PlayerScript.Player player { get; set; }
    }
    public class Dynamite
    {
        public GameObject gameObject { get; set; }
        public PlayerScript.Player player { get; set; }
    }


    public static List<Hexagons.Tile> usedHexagons = new List<Hexagons.Tile>();

    public static List<House> housesOnBoard = new List<House>();
    public static List<Road> roadsOnBoard = new List<Road>();
    public static List<City> citiesOnBoard = new List<City>();
    public static List<Candle> candlesOnBoard = new List<Candle>();
    public static List<Dynamite> dynamitesOnBoard = new List<Dynamite>();
    public static List<GameObject> knightsOnBoard = new List<GameObject>();

    private void Start()
    {
        usedHexagons = new List<Hexagons.Tile>();

        housesOnBoard = new List<House>();
        roadsOnBoard = new List<Road>();
        citiesOnBoard = new List<City>();
        candlesOnBoard = new List<Candle>();
        dynamitesOnBoard = new List<Dynamite>();
        knightsOnBoard = new List<GameObject>();
    }

    public static void AddHouseOnBoard(GameObject house)
    {
        House bigHouse = new House();
        bigHouse.gameObject = house;

        if (PlayerScript.activePlayer.colour == PlayerScript.player1.colour)
        {
            bigHouse.player = PlayerScript.player1;
        }
        else if (PlayerScript.activePlayer.colour == PlayerScript.player2.colour)
        {
            bigHouse.player = PlayerScript.player2;

        }
        else if (PlayerScript.activePlayer.colour == PlayerScript.player3.colour)
        {
            bigHouse.player = PlayerScript.player3;

        }
        else if (PlayerScript.activePlayer.colour == PlayerScript.player4.colour)
        {
            bigHouse.player = PlayerScript.player4;

        }
        housesOnBoard.Add(bigHouse);


        foreach (Hexagons.Tile tile in Hexagons.hexagons)
        {
            GameObject gTile = tile.gameObject;
            if (gTile.transform.position == new Vector3(house.transform.position.x, house.transform.position.y + gTile.transform.localScale.y/2, 0) || gTile.transform.position == new Vector3(house.transform.position.x, house.transform.position.y - gTile.transform.localScale.y / 2, 0) || gTile.transform.position == new Vector3(house.transform.position.x + gTile.transform.localScale.x/2, house.transform.position.y + 0.35f) || gTile.transform.position == new Vector3(house.transform.position.x - gTile.transform.localScale.x / 2, house.transform.position.y + 0.35f) || gTile.transform.position == new Vector3(house.transform.position.x + gTile.transform.localScale.x / 2, house.transform.position.y - 0.35f) || gTile.transform.position == new Vector3(house.transform.position.x - gTile.transform.localScale.x / 2, house.transform.position.y - 0.35f))
            {
                if (PlayerScript.activePlayer.colour == PlayerScript.player1.colour)
                {
                    PlayerScript.player1.tileList.Add(tile);
                }
                else if (PlayerScript.activePlayer.colour == PlayerScript.player2.colour)
                {
                    PlayerScript.player2.tileList.Add(tile);
                }
                else if (PlayerScript.activePlayer.colour == PlayerScript.player3.colour)
                {
                    PlayerScript.player3.tileList.Add(tile);
                }
                else if (PlayerScript.activePlayer.colour == PlayerScript.player4.colour)
                {
                    PlayerScript.player4.tileList.Add(tile);
                }
            }

        }
    }

    public static void RemoveHouseFromBoard(GameObject house)
    {
        House bigHouse = new House();
        bigHouse.gameObject = house;

        foreach (House item in housesOnBoard)
        {
            if (item.gameObject == house)
            {
                housesOnBoard.Remove(item);
                break;
            }
        }

        foreach (Hexagons.Tile tile in Hexagons.hexagons)
        {
            GameObject gTile = tile.gameObject;
            if (gTile.transform.position == new Vector3(house.transform.position.x, house.transform.position.y + gTile.transform.localScale.y / 2, 0) || gTile.transform.position == new Vector3(house.transform.position.x, house.transform.position.y - gTile.transform.localScale.y / 2, 0) || gTile.transform.position == new Vector3(house.transform.position.x + gTile.transform.localScale.x / 2, house.transform.position.y + 0.35f) || gTile.transform.position == new Vector3(house.transform.position.x - gTile.transform.localScale.x / 2, house.transform.position.y + 0.35f) || gTile.transform.position == new Vector3(house.transform.position.x + gTile.transform.localScale.x / 2, house.transform.position.y - 0.35f) || gTile.transform.position == new Vector3(house.transform.position.x - gTile.transform.localScale.x / 2, house.transform.position.y - 0.35f))
            {
                if (PlayerScript.activePlayer.colour == PlayerScript.player1.colour)
                {
                    PlayerScript.player1.tileList.Remove(tile);
                }
                else if (PlayerScript.activePlayer.colour == PlayerScript.player2.colour)
                {
                    PlayerScript.player2.tileList.Remove(tile);
                }
                else if (PlayerScript.activePlayer.colour == PlayerScript.player3.colour)
                {
                    PlayerScript.player3.tileList.Remove(tile);
                }
                else if (PlayerScript.activePlayer.colour == PlayerScript.player4.colour)
                {
                    PlayerScript.player4.tileList.Remove(tile);
                }
            }

        }

        for (int i = 0; i < 4; i++)
        {
            int rand = Random.Range(1, 4);
            if (rand == 2)
            {
                ResourceScript script = new ResourceScript();

                MethodInfo method = script.GetType().GetTypeInfo().GetMethod("Give" + ResourceScript.resourceStringsCap[i]);

                object[] parameter = new object[] { 1 };

                method.Invoke(script.GetType(), parameter);
            }
        }

        Destroy(house);

        PlacementLists.UpdateAvailableCandles();
        PlacementLists.UpdateAvailableCities();
        PlacementLists.UpdateAvailableHouses();
        PlacementLists.UpdateAvailableRoads();
    }

    public static void RemoveCityFromBoard(GameObject city)
    {
        City bigHouse = new City();
        bigHouse.gameObject = city;

        foreach (City item in citiesOnBoard)
        {
            if (item.gameObject == city)
            {
                citiesOnBoard.Remove(item);
                break;
            }
        }

        foreach (Hexagons.Tile tile in Hexagons.hexagons)
        {
            GameObject gTile = tile.gameObject;
            if (gTile.transform.position == new Vector3(city.transform.position.x, city.transform.position.y + gTile.transform.localScale.y / 2, 0) || gTile.transform.position == new Vector3(city.transform.position.x, city.transform.position.y - gTile.transform.localScale.y / 2, 0) || gTile.transform.position == new Vector3(city.transform.position.x + gTile.transform.localScale.x / 2, city.transform.position.y + 0.35f) || gTile.transform.position == new Vector3(city.transform.position.x - gTile.transform.localScale.x / 2, city.transform.position.y + 0.35f) || gTile.transform.position == new Vector3(city.transform.position.x + gTile.transform.localScale.x / 2, city.transform.position.y - 0.35f) || gTile.transform.position == new Vector3(city.transform.position.x - gTile.transform.localScale.x / 2, city.transform.position.y - 0.35f))
            {
                if (PlayerScript.activePlayer.colour == PlayerScript.player1.colour)
                {
                    PlayerScript.player1.tileList.Remove(tile);
                }
                else if (PlayerScript.activePlayer.colour == PlayerScript.player2.colour)
                {
                    PlayerScript.player2.tileList.Remove(tile);
                }
                else if (PlayerScript.activePlayer.colour == PlayerScript.player3.colour)
                {
                    PlayerScript.player3.tileList.Remove(tile);
                }
                else if (PlayerScript.activePlayer.colour == PlayerScript.player4.colour)
                {
                    PlayerScript.player4.tileList.Remove(tile);
                }
            }

        }

        for (int i = 3; i < 5; i++)
        {
            int rand = Random.Range(1, 2);
            if (rand == 2)
            {
                ResourceScript script = new ResourceScript();

                MethodInfo method = script.GetType().GetTypeInfo().GetMethod("Give" + ResourceScript.resourceStringsCap[i]);

                object[] parameter = new object[] { 1 };

                method.Invoke(script.GetType(), parameter);
            }
        }

        Destroy(city);

        PlacementLists.UpdateAvailableCandles();
        PlacementLists.UpdateAvailableCities();
        PlacementLists.UpdateAvailableHouses();
        PlacementLists.UpdateAvailableRoads();
    }


    public static void RemoveRoadFromBoard(GameObject road)
    {
        Road bigRoad = new Road();
        bigRoad.gameObject = road;

        foreach (Road item in roadsOnBoard)
        {
            if (item.gameObject == road)
            {
                roadsOnBoard.Remove(item);
                break;
            }
        }

        for (int i = 0; i < 2; i++)
        {
            int rand = Random.Range(1, 3);
            if (rand == 2)
            {
                ResourceScript script = new ResourceScript();

                MethodInfo method = script.GetType().GetTypeInfo().GetMethod("Give" + ResourceScript.resourceStringsCap[i]);

                object[] parameter = new object[] { 1 };

                method.Invoke(script.GetType(), parameter);
            }
        }

        Destroy(road);

        PlacementLists.UpdateAvailableCities();
        PlacementLists.UpdateAvailableHouses();
        PlacementLists.UpdateAvailableRoads();
    }

    public static void RemoveDynamiteFromBoard(GameObject dynamite)
    {
        Dynamite bigDynamite = new Dynamite();
        bigDynamite.gameObject = dynamite;

        foreach (Dynamite item in dynamitesOnBoard)
        {
            if (item.gameObject.transform.position == dynamite.transform.position)
            {
                dynamitesOnBoard.Remove(item);
                break;
            }
        }

        Destroy(dynamite);

    }

    public static void RemoveCandleFromBoard(GameObject candle)
    {
        Candle bigCandle = new Candle();
        bigCandle.gameObject = candle;

        foreach (Candle item in candlesOnBoard)
        {
            if (item.gameObject == candle)
            {
                candlesOnBoard.Remove(item);
                break;
            }
        }

        Destroy(candle);

        PlacementLists.UpdateAvailableCandles();
        PlacementLists.UpdateAvailableCities();
        PlacementLists.UpdateAvailableHouses();
        PlacementLists.UpdateAvailableRoads();
    }


}
