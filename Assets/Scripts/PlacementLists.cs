using System.Collections.Generic;
using UnityEngine;

public class PlacementLists : MonoBehaviour
{
    public static List<Vector3> roadPlacementList = new List<Vector3>(); // The first two are the coordinates then the third is the type of road that will be used (the tilt)
    public static List<Vector2> housePlacementList = new List<Vector2>();
    public static List<Vector2> housePlacementListALL = new List<Vector2>();
    public static List<Vector2> candlePlacementList = new List<Vector2>();
    public static List<Vector2> cityPlacementList = new List<Vector2>();
    public static List<GameObject> thiefPlacementList = new List<GameObject>();
    public static List<Vector2> dynamitePlacementList = new List<Vector2>();

    private void Start()
    {
        roadPlacementList = new List<Vector3>(); 
        housePlacementList = new List<Vector2>();
        housePlacementListALL = new List<Vector2>();
        candlePlacementList = new List<Vector2>();
        cityPlacementList = new List<Vector2>();
        thiefPlacementList = new List<GameObject>();
        dynamitePlacementList = new List<Vector2>();
    }

    public static void UpdateAvailableThiefs()
    {
        foreach (Hexagons.Tile hexagon in Hexagons.hexagons)
        {
            if (!thiefPlacementList.Contains(hexagon.gameObject))
            {
                thiefPlacementList.Add(hexagon.gameObject);
            }
        }
    }

    public static void UpdateAvailableRoads()
    {
        List<Vector3> killList = new List<Vector3>();
        foreach (Hexagons.Tile hexagon in Hexagons.hexagons)
        {

            #region Left & Right

            float straightLeftRoadx = hexagon.gameObject.transform.position.x - 0.5f;
            float straightLeftRoady = hexagon.gameObject.transform.position.y;
            if (!roadPlacementList.Contains(new Vector3(straightLeftRoadx, straightLeftRoady, 1)))
            {
                roadPlacementList.Add(new Vector3(straightLeftRoadx, straightLeftRoady, 1));
            }

            float rightRoadx = hexagon.gameObject.transform.position.x + 0.5f;
            float rightRoady = hexagon.gameObject.transform.position.y;
            if (!roadPlacementList.Contains(new Vector3(rightRoadx, rightRoady, 1)))
            {
                roadPlacementList.Add(new Vector3(rightRoadx, rightRoady, 1));
            }
            #endregion

            #region Top Left & Right

            float topLeftRoadx = hexagon.gameObject.transform.position.x - 0.25f;
            float topLeftRoady = hexagon.gameObject.transform.position.y + 0.425f;
            if (!roadPlacementList.Contains(new Vector3(topLeftRoadx, topLeftRoady, 3)))
            {
                roadPlacementList.Add(new Vector3(topLeftRoadx, topLeftRoady, 3));
            }

            float topRightRoadx = hexagon.gameObject.transform.position.x + 0.25f;
            float topRightRoady = hexagon.gameObject.transform.position.y + 0.425f;
            if (!roadPlacementList.Contains(new Vector3(topRightRoadx, topRightRoady, 2)))
            {
                roadPlacementList.Add(new Vector3(topRightRoadx, topRightRoady, 2));
            }
            #endregion

            #region Bot Left & Right

            float botLeftRoadx = hexagon.gameObject.transform.position.x - 0.25f;
            float botLeftRoady = hexagon.gameObject.transform.position.y - 0.425f;
            if (!roadPlacementList.Contains(new Vector3(botLeftRoadx, botLeftRoady, 2)))
            {
                roadPlacementList.Add(new Vector3(botLeftRoadx, botLeftRoady, 2));
            }

            float botRightRoadx = hexagon.gameObject.transform.position.x + 0.25f;
            float botRightRoady = hexagon.gameObject.transform.position.y - 0.425f;
            if (!roadPlacementList.Contains(new Vector3(botRightRoadx, botRightRoady, 3)))
            {
                roadPlacementList.Add(new Vector3(botRightRoadx, botRightRoady, 3));
            }
            #endregion



        }

        #region Remove If Not Next To House, City, Road or Candle + Has 
        foreach (Vector3 roadVector in roadPlacementList)
        {
            int num = 0;
            int maxNum = ObjectOnBoardLists.housesOnBoard.Count + ObjectOnBoardLists.citiesOnBoard.Count + ObjectOnBoardLists.roadsOnBoard.Count + ObjectOnBoardLists.candlesOnBoard.Count;
            foreach (ObjectOnBoardLists.House bigHouse in ObjectOnBoardLists.housesOnBoard)
            {
                GameObject house = bigHouse.gameObject;
                if ((house.transform.position == new Vector3(roadVector.x, roadVector.y + 0.35f, 0) || house.transform.position == new Vector3(roadVector.x, roadVector.y - 0.35f, 0) || house.transform.position == new Vector3(roadVector.x - 0.25f, roadVector.y + 0.075f, 0) || house.transform.position == new Vector3(roadVector.x + 0.25f, roadVector.y - 0.075f, 0) || house.transform.position == new Vector3(roadVector.x, roadVector.y - 0.35f, 0) || house.transform.position == new Vector3(roadVector.x - 0.25f, roadVector.y - 0.075f, 0) || house.transform.position == new Vector3(roadVector.x + 0.25f, roadVector.y + 0.075f, 0)) && bigHouse.player.colour == PlayerScript.activePlayer.colour)
                {
                    //woo you passed
                }
                else
                {
                    num++;
                }
            }
            foreach (ObjectOnBoardLists.Candle bigCandle in ObjectOnBoardLists.candlesOnBoard)
            {
                GameObject candle = bigCandle.gameObject;
                if ((candle.transform.position == new Vector3(roadVector.x, roadVector.y + 0.35f, 0) || candle.transform.position == new Vector3(roadVector.x, roadVector.y - 0.35f, 0) || candle.transform.position == new Vector3(roadVector.x - 0.25f, roadVector.y + 0.075f, 0) || candle.transform.position == new Vector3(roadVector.x + 0.25f, roadVector.y - 0.075f, 0) || candle.transform.position == new Vector3(roadVector.x, roadVector.y - 0.35f, 0) || candle.transform.position == new Vector3(roadVector.x - 0.25f, roadVector.y - 0.075f, 0) || candle.transform.position == new Vector3(roadVector.x + 0.25f, roadVector.y + 0.075f, 0)) && bigCandle.player.colour == PlayerScript.activePlayer.colour)
                {
                    //woo you passed
                }
                else
                {
                    num++;
                }
            }
            foreach (ObjectOnBoardLists.City bigCity in ObjectOnBoardLists.citiesOnBoard)
            {
                GameObject city = bigCity.gameObject;
                if ((city.transform.position == new Vector3(roadVector.x, roadVector.y + 0.35f, 0) || city.transform.position == new Vector3(roadVector.x, roadVector.y - 0.35f, 0) || city.transform.position == new Vector3(roadVector.x - 0.25f, roadVector.y + 0.075f, 0) || city.transform.position == new Vector3(roadVector.x + 0.25f, roadVector.y - 0.075f, 0) || city.transform.position == new Vector3(roadVector.x, roadVector.y - 0.35f, 0) || city.transform.position == new Vector3(roadVector.x - 0.25f, roadVector.y - 0.075f, 0) || city.transform.position == new Vector3(roadVector.x + 0.25f, roadVector.y + 0.075f, 0)) && bigCity.player.colour == PlayerScript.activePlayer.colour)
                {
                    //woo you passed
                }
                else
                {
                    num++;
                }
            }
            foreach (ObjectOnBoardLists.Road bigRoad in ObjectOnBoardLists.roadsOnBoard)
            {
                GameObject road = bigRoad.gameObject;
                if ((road.transform.position == new Vector3(roadVector.x + 0.25f, roadVector.y + 0.425f, 0) || road.transform.position == new Vector3(roadVector.x - 0.25f, roadVector.y - 0.425f, 0) || road.transform.position == new Vector3(roadVector.x - 0.25f, roadVector.y + 0.425f, 0) || road.transform.position == new Vector3(roadVector.x + 0.25f, roadVector.y - 0.425f, 0) || road.transform.position == new Vector3(roadVector.x, roadVector.y - 0.35f, 0) || road.transform.position == new Vector3(roadVector.x + 0.5f, roadVector.y, 0) || road.transform.position == new Vector3(roadVector.x - 0.5f, roadVector.y, 0)) && bigRoad.player.colour == PlayerScript.activePlayer.colour)
                {
                    //woo you passed
                }
                else
                {
                    num++;
                }
            }
            if (num >= maxNum)
            {
                killList.Add(roadVector);
            }
        }

        #endregion


        #region Remove If There Is A Road There

        foreach (Vector3 roadVector in roadPlacementList)
        {
            foreach (ObjectOnBoardLists.Road bigRoad in ObjectOnBoardLists.roadsOnBoard)
            {
                GameObject road = bigRoad.gameObject;
                if (new Vector2(roadVector.x, roadVector.y) == new Vector2(road.transform.position.x, road.transform.position.y))
                {
                    killList.Add(roadVector);
                }
            }
        }

        #endregion
        foreach (Vector3 item in killList)
        {
            roadPlacementList.Remove(item);
        }

        
    }

    public static void UpdateAvailableHouses()
    {
        List<Vector2> killList = new List<Vector2>();
        List<Vector2> killListForAll = new List<Vector2>();

        foreach (Hexagons.Tile hexagon in Hexagons.hexagons)
        {
            #region Up & Down

            float straightUpHousex = hexagon.gameObject.transform.position.x;
            float straightUpHousey = hexagon.gameObject.transform.position.y + hexagon.gameObject.transform.localScale.y / 2;

            if (!housePlacementList.Contains(new Vector2(straightUpHousex, straightUpHousey)))
            {
                housePlacementList.Add(new Vector2(straightUpHousex, straightUpHousey));
            }

            float straightDownHousex = hexagon.gameObject.transform.position.x;
            float straightDownHousey = hexagon.gameObject.transform.position.y - hexagon.gameObject.transform.localScale.y / 2;

            if (!housePlacementList.Contains(new Vector2(straightDownHousex, straightDownHousey)))
            {
                housePlacementList.Add(new Vector2(straightDownHousex, straightDownHousey));
            }

            #endregion

            #region Top Left & Right

            float leftUpHousex = hexagon.gameObject.transform.position.x - hexagon.gameObject.transform.localScale.x / 2;
            float leftUpHousey = hexagon.gameObject.transform.position.y + 0.35f;

            if (!housePlacementList.Contains(new Vector2(leftUpHousex, leftUpHousey)))
            {
                housePlacementList.Add(new Vector2(leftUpHousex, leftUpHousey));
                housePlacementListALL.Add(new Vector2(leftUpHousex, leftUpHousey));
            }

            float rightUpHousex = hexagon.gameObject.transform.position.x + hexagon.gameObject.transform.localScale.x / 2;
            float rightUpHousey = hexagon.gameObject.transform.position.y + 0.35f;

            if (!housePlacementList.Contains(new Vector2(rightUpHousex, rightUpHousey)))
            {
                housePlacementList.Add(new Vector2(rightUpHousex, rightUpHousey));
                housePlacementListALL.Add(new Vector2(rightUpHousex, rightUpHousey));
            }


            #endregion

            #region Bot Left & Right

            float leftDownHousex = hexagon.gameObject.transform.position.x - hexagon.gameObject.transform.localScale.x / 2;
            float leftDownHousey = hexagon.gameObject.transform.position.y - 0.35f;

            if (!housePlacementList.Contains(new Vector2(leftDownHousex, leftDownHousey)))
            {
                housePlacementList.Add(new Vector2(leftDownHousex, leftDownHousey));
                housePlacementListALL.Add(new Vector2(leftDownHousex, leftDownHousey));
            }

            float rightDownHousex = hexagon.gameObject.transform.position.x + hexagon.gameObject.transform.localScale.x / 2;
            float rightDownHousey = hexagon.gameObject.transform.position.y - 0.35f;

            if (!housePlacementList.Contains(new Vector2(rightDownHousex, rightDownHousey)))
            {
                housePlacementList.Add(new Vector2(rightDownHousex, rightDownHousey));
                housePlacementListALL.Add(new Vector2(rightDownHousex, rightDownHousey));
            }

            #endregion


        }
        #region Remove If Too Close To/On Anther House, City or Candle

        foreach (ObjectOnBoardLists.House bigHouse in ObjectOnBoardLists.housesOnBoard)
        {
            GameObject house = bigHouse.gameObject;
            foreach (Vector2 pos in housePlacementList)
            {
                if (pos == new Vector2(house.transform.position.x, house.transform.position.y) || pos == new Vector2(house.transform.position.x + 0.5f, house.transform.position.y + 0.15f) || pos == new Vector2(house.transform.position.x - 0.5f, house.transform.position.y + 0.15f) || pos == new Vector2(house.transform.position.x + 0.5f, house.transform.position.y - 0.15f) || pos == new Vector2(house.transform.position.x - 0.5f, house.transform.position.y - 0.15f) || pos == new Vector2(house.transform.position.x, house.transform.position.y + 0.7f) || pos == new Vector2(house.transform.position.x, house.transform.position.y - 0.7f))
                {
                    killList.Add(pos);
                    killListForAll.Add(pos);
                }
            }
        }

        foreach (ObjectOnBoardLists.City bigHouse in ObjectOnBoardLists.citiesOnBoard)
        {
            GameObject house = bigHouse.gameObject;
            foreach (Vector2 pos in housePlacementList)
            {
                if (pos == new Vector2(house.transform.position.x, house.transform.position.y) || pos == new Vector2(house.transform.position.x + 0.5f, house.transform.position.y + 0.15f) || pos == new Vector2(house.transform.position.x - 0.5f, house.transform.position.y + 0.15f) || pos == new Vector2(house.transform.position.x + 0.5f, house.transform.position.y - 0.15f) || pos == new Vector2(house.transform.position.x - 0.5f, house.transform.position.y - 0.15f) || pos == new Vector2(house.transform.position.x, house.transform.position.y + 0.7f) || pos == new Vector2(house.transform.position.x, house.transform.position.y - 0.7f))
                {
                    killList.Add(pos);
                    killListForAll.Add(pos);

                }
            }
        }

        foreach (ObjectOnBoardLists.Candle bigCandle in ObjectOnBoardLists.candlesOnBoard)
        {
            GameObject candle = bigCandle.gameObject;
            foreach (Vector2 pos in housePlacementList)
            {
                if (pos == new Vector2(candle.transform.position.x, candle.transform.position.y))
                {
                    killList.Add(pos);
                    killListForAll.Add(pos);
                }
            }
        }
        #endregion

        #region Remove If Not Next To Road
        foreach (Vector2 pos in housePlacementList)
        {
            int maxNum = ObjectOnBoardLists.roadsOnBoard.Count;
            int num = 0;

            foreach (ObjectOnBoardLists.Road bigRoad in ObjectOnBoardLists.roadsOnBoard)
            {
                GameObject road = bigRoad.gameObject;
                if ((pos == new Vector2(road.transform.position.x + 0.25f, road.transform.position.y + 0.075f) || pos == new Vector2(road.transform.position.x - 0.25f, road.transform.position.y + 0.075f) || pos == new Vector2(road.transform.position.x + 0.25f, road.transform.position.y - 0.075f) || pos == new Vector2(road.transform.position.x - 0.25f, road.transform.position.y - 0.075f) || pos == new Vector2(road.transform.position.x, road.transform.position.y + 0.35f) || pos == new Vector2(road.transform.position.x, road.transform.position.y - 0.35f)) && bigRoad.player.colour == PlayerScript.activePlayer.colour)
                {
                    //woo we passed ^^ We want that to be positive, else it will probs get deleted
                }
                else
                {
                    num++;
                }

                
            }
            if (num >= maxNum)
            {
                if (PlayerScript.activePlayer.twoFreeHouses < 2)
                {

                }
                else
                {
                    killList.Add(pos);
                }
            }
        }

        #endregion

        foreach (Vector2 item in killList)
        {
            housePlacementList.Remove(item);
        }
        killList.Clear();

        foreach (Vector2 item in killListForAll)
        {
            housePlacementListALL.Remove(item);
        }
        killListForAll.Clear();
    }


    public static void UpdateAvailableCities()
    {
        cityPlacementList.Clear();
        foreach (ObjectOnBoardLists.House bigHouse in ObjectOnBoardLists.housesOnBoard) // Adds a potential place for each house
        {
            GameObject house = bigHouse.gameObject;

            if ((!cityPlacementList.Contains(new Vector2(house.transform.position.x, house.transform.position.y))) && bigHouse.player.colour == PlayerScript.activePlayer.colour)
            {
                cityPlacementList.Add(new Vector2(house.transform.position.x, house.transform.position.y));
            }
        }

        foreach (ObjectOnBoardLists.City bigCity in ObjectOnBoardLists.citiesOnBoard) // Removes the placement if there is a city there
        {
            GameObject city = bigCity.gameObject;
            if (cityPlacementList.Contains(new Vector2(city.transform.position.x, city.transform.position.y)))
            {
                cityPlacementList.Remove(new Vector2(city.transform.position.x, city.transform.position.y));
            }
        }

        
    } 

    public static void UpdateAvailableCandles()
    {
        List<Vector2> killList = new List<Vector2>();
        foreach (Hexagons.Tile hexagon in Hexagons.hexagons)
        {
            #region Up & Down

            float straightUpHousex = hexagon.gameObject.transform.position.x;
            float straightUpHousey = hexagon.gameObject.transform.position.y + hexagon.gameObject.transform.localScale.y / 2;

            if (!candlePlacementList.Contains(new Vector2(straightUpHousex, straightUpHousey)))
            {
                candlePlacementList.Add(new Vector2(straightUpHousex, straightUpHousey));
            }

            float straightDownHousex = hexagon.gameObject.transform.position.x;
            float straightDownHousey = hexagon.gameObject.transform.position.y - hexagon.gameObject.transform.localScale.y / 2;

            if (!candlePlacementList.Contains(new Vector2(straightDownHousex, straightDownHousey)))
            {
                candlePlacementList.Add(new Vector2(straightDownHousex, straightDownHousey));
            }

            #endregion

            #region Top Left & Right

            float leftUpHousex = hexagon.gameObject.transform.position.x - hexagon.gameObject.transform.localScale.x / 2;
            float leftUpHousey = hexagon.gameObject.transform.position.y + 0.35f;

            if (!candlePlacementList.Contains(new Vector2(leftUpHousex, leftUpHousey)))
            {
                candlePlacementList.Add(new Vector2(leftUpHousex, leftUpHousey));
            }

            float rightUpHousex = hexagon.gameObject.transform.position.x + hexagon.gameObject.transform.localScale.x / 2;
            float rightUpHousey = hexagon.gameObject.transform.position.y + 0.35f;

            if (!candlePlacementList.Contains(new Vector2(rightUpHousex, rightUpHousey)))
            {
                candlePlacementList.Add(new Vector2(rightUpHousex, rightUpHousey));
            }


            #endregion

            #region Bot Left & Right

            float leftDownHousex = hexagon.gameObject.transform.position.x - hexagon.gameObject.transform.localScale.x / 2;
            float leftDownHousey = hexagon.gameObject.transform.position.y - 0.35f;

            if (!candlePlacementList.Contains(new Vector2(leftDownHousex, leftDownHousey)))
            {
                candlePlacementList.Add(new Vector2(leftDownHousex, leftDownHousey));
            }

            float rightDownHousex = hexagon.gameObject.transform.position.x + hexagon.gameObject.transform.localScale.x / 2;
            float rightDownHousey = hexagon.gameObject.transform.position.y - 0.35f;

            if (!candlePlacementList.Contains(new Vector2(rightDownHousex, rightDownHousey)))
            {
                candlePlacementList.Add(new Vector2(rightDownHousex, rightDownHousey));
            }

            #endregion


        }

        #region Remove if not in shape

        foreach (Vector2 pos in candlePlacementList)
        {
            int num = 0;
            int maxNum = ObjectOnBoardLists.candlesOnBoard.Count;
            foreach (ObjectOnBoardLists.Candle bigCandle in ObjectOnBoardLists.candlesOnBoard)
            {
                Vector3 candle = bigCandle.gameObject.transform.position;
                if (/*TOP CANDLE*/ (pos == new Vector2(candle.x - 1.5f, candle.y - 0.85f) || pos == new Vector2(candle.x + 1.5f, candle.y - 0.85f) || pos == new Vector2(candle.x - 1f, candle.y - 2.4f) || pos == new Vector2(candle.x + 1f, candle.y - 2.4f) /*TOP LEFT CANDLE*/ || pos == new Vector2(candle.x + 1.5f, candle.y + 0.85f) || pos == new Vector2(candle.x + 3f, candle.y) || pos == new Vector2(candle.x + 0.5f, candle.y - 1.55f) || pos == new Vector2(candle.x + 2.5f, candle.y - 1.55f) /*TOP RIGHT CANDLE*/ || pos == new Vector2(candle.x - 1.5f, candle.y + 0.85f) || pos == new Vector2(candle.x - 3f, candle.y) || pos == new Vector2(candle.x - 0.5f, candle.y - 1.55f) || pos == new Vector2(candle.x - 2.5f, candle.y - 1.55f) /*BOT LEFT CANDLE*/ || pos == new Vector2(candle.x - 0.5f, candle.y + 1.55f) || pos == new Vector2(candle.x + 2.5f, candle.y + 1.55f) || pos == new Vector2(candle.x + 2f, candle.y) || pos == new Vector2(candle.x + 1f, candle.y + 2.4f) /*BOT RIGHT CANDLE*/ || pos == new Vector2(candle.x - 2.5f, candle.y + 1.55f) || pos == new Vector2(candle.x + 0.5f, candle.y + 1.55f) || pos == new Vector2(candle.x - 2f, candle.y) || pos == new Vector2(candle.x - 1f, candle.y + 2.4f)) && bigCandle.player.colour == PlayerScript.activePlayer.colour)
                {

                }
                else
                {
                    num++;
                }

                if (num >= maxNum)
                {
                    if (PlayerScript.activePlayer.oneFreeCandle >= 1)
                    {
                        killList.Add(pos);
                    }
                    

                }

                if (pos == new Vector2(candle.x, candle.y))
                {
                    killList.Add(pos);
                }
            }
        }

        #region Remove If There Is A House Or City There
        foreach (Vector2 pos in candlePlacementList)
        {
            foreach (ObjectOnBoardLists.House bigHouse in ObjectOnBoardLists.housesOnBoard)
            {
                GameObject house = bigHouse.gameObject;
                if (pos == new Vector2(house.transform.position.x, house.transform.position.y))
                {
                    killList.Add(pos);
                    break;
                }

            }
            foreach (ObjectOnBoardLists.City bigCity in ObjectOnBoardLists.citiesOnBoard)
            {
                GameObject city = bigCity.gameObject;
                if (pos == new Vector2(city.transform.position.x, city.transform.position.y))
                {
                    killList.Add(pos);
                    break;
                }

            }
        }
        

        #endregion



        #endregion
        foreach (Vector2 pos in killList)
        {
            candlePlacementList.Remove(pos);
        }
        killList.Clear();
    }

    public static void UpdateDynamitePlacement()
    {
        dynamitePlacementList.Clear();
        foreach (ObjectOnBoardLists.House item in ObjectOnBoardLists.housesOnBoard)
        {
            dynamitePlacementList.Add(item.gameObject.transform.position);
        }
        foreach (ObjectOnBoardLists.Road item in ObjectOnBoardLists.roadsOnBoard)
        {
            dynamitePlacementList.Add(item.gameObject.transform.position);
        }
        foreach (ObjectOnBoardLists.City item in ObjectOnBoardLists.citiesOnBoard)
        {
            dynamitePlacementList.Add(item.gameObject.transform.position);
        }
        foreach (ObjectOnBoardLists.Candle item in ObjectOnBoardLists.candlesOnBoard)
        {
            dynamitePlacementList.Add(item.gameObject.transform.position);
        }
    }
}
