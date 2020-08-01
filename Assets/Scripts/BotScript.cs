using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotScript : MonoBehaviour
{
    public static int botAmount;
    public static bool botTurn = false;
    


    public static void BotPlaceThief()
    {
        foreach (ObjectOnBoardLists.House house in ObjectOnBoardLists.housesOnBoard)
        {
            if (house.player.colour != PlayerScript.activePlayer.colour)
            {
                foreach (GameObject light in ThiefScript.thiefLights)
                {
                    if (light.transform.position == new Vector3(house.gameObject.transform.position.x, house.gameObject.transform.position.y + 0.5f, 0) || light.transform.position == new Vector3(house.gameObject.transform.position.x, house.gameObject.transform.position.y - 0.5f, 0))
                    {
                        light.GetComponent<PlaceThief>().TheifPlacement();
                        break;
                    }
                }
            }
        }
    }
    
    public static Vector2 FindBestHousePlacement()
    {
        Vector2 vectorToReturn = new Vector2();
        float lowestSum = 1000;
        foreach (Vector2 housePlacement in PlacementLists.housePlacementList)
        {
            List<float> hexNums = new List<float>();
            int hexSum = 0;

            List<int> testlist = new List<int>();
            foreach (Hexagons.Tile hexagon in Hexagons.hexagons)
            {
                Vector2 hex = new Vector2(hexagon.gameObject.transform.position.x, hexagon.gameObject.transform.position.y);

                if (housePlacement == new Vector2(hex.x, hex.y + 0.5f) || housePlacement == new Vector2(hex.x, hex.y - 0.5f) || housePlacement == new Vector2(hex.x - 0.5f, hex.y + 0.35f) || housePlacement == new Vector2(hex.x + 0.5f, hex.y + 0.35f) || housePlacement == new Vector2(hex.x - 0.5f, hex.y - 0.35f) || housePlacement == new Vector2(hex.x - 0.5f, hex.y + 0.35f))
                {
                    testlist.Add(hexagon.diceNumber);

                    float x = hexagon.diceNumber - 7;
                    x *= x;

                    hexNums.Add(x);
                }
            }

            if (testlist.Count == 3)
            {
                //print("The position: " + housePlacement + " has the number: " + testlist[0] + "  " + testlist[1] + "  " + testlist[2]);
            }

            if (hexNums.Count == 3)
            {
                foreach (int num in hexNums)
                {
                    hexSum += num;
                }

                if (hexSum < lowestSum)
                {
                    lowestSum = hexSum;
                    vectorToReturn = housePlacement;
                    //print("The placement:" + housePlacement + " has the differemtial sum of " + hexSum + " with a " + hexNums[0] + " " + hexNums[1] + " " + hexNums[2] + " ");
                }

            }
            
        }
        

        return vectorToReturn;
    }

    public static Vector2 FindBestHousePlacementALL()
    {
        Vector2 vectorToReturn = new Vector2();
        float lowestSum = 1000;
        foreach (Vector2 housePlacement in PlacementLists.housePlacementListALL)
        {
            List<float> hexNums = new List<float>();
            int hexSum = 0;

            List<int> testlist = new List<int>();
            foreach (Hexagons.Tile hexagon in Hexagons.hexagons)
            {
                Vector2 hex = new Vector2(hexagon.gameObject.transform.position.x, hexagon.gameObject.transform.position.y);

                if (housePlacement == new Vector2(hex.x, hex.y + 0.5f) || housePlacement == new Vector2(hex.x, hex.y - 0.5f) || housePlacement == new Vector2(hex.x - 0.5f, hex.y + 0.35f) || housePlacement == new Vector2(hex.x + 0.5f, hex.y + 0.35f) || housePlacement == new Vector2(hex.x - 0.5f, hex.y - 0.35f) || housePlacement == new Vector2(hex.x - 0.5f, hex.y + 0.35f))
                {
                    testlist.Add(hexagon.diceNumber);

                    float x = hexagon.diceNumber - 7;
                    x *= x;

                    hexNums.Add(x);
                }
            }

            if (testlist.Count == 3)
            {
                //print("The position: " + housePlacement + " has the number: " + testlist[0] + "  " + testlist[1] + "  " + testlist[2]);
            }

            if (hexNums.Count == 3)
            {
                foreach (int num in hexNums)
                {
                    hexSum += num;
                }

                if (hexSum < lowestSum)
                {
                    lowestSum = hexSum;
                    vectorToReturn = housePlacement;
                    //print("The placement:" + housePlacement + " has the differemtial sum of " + hexSum + " with a " + hexNums[0] + " " + hexNums[1] + " " + hexNums[2] + " ");
                }

            }

        }


        return vectorToReturn;
    }

    public static void BotPlaceCandle(Vector3 candlePos)
    {
        if (PlayerScript.activePlayer.sheepAmount >= 10)
        {
            
            ResourceScript.GiveSheep(-10);

            GameObject candle = (GameObject)Instantiate(Resources.Load("Candle/CandleFaded"), candlePos, Quaternion.identity);
            ObjectOnBoardLists.Candle bigCandle = new ObjectOnBoardLists.Candle();
            bigCandle.gameObject = candle;
            bigCandle.player = PlayerScript.activePlayer;
            ObjectOnBoardLists.candlesOnBoard.Add(bigCandle);

            PlayerScript.activePlayer.oneFreeCandle++;
            if (PlayerScript.activePlayer.colour == PlayerScript.player1.colour)
            {
                candle.GetComponent<SpriteRenderer>().color = PlayerScript.player1.colour;
                PlayerScript.player1.oneFreeCandle++;
            }
            else if (PlayerScript.activePlayer.colour == PlayerScript.player2.colour)
            {
                candle.GetComponent<SpriteRenderer>().color = PlayerScript.player2.colour;
                PlayerScript.player2.oneFreeCandle++;

            }
            else if (PlayerScript.activePlayer.colour == PlayerScript.player3.colour)
            {
                candle.GetComponent<SpriteRenderer>().color = PlayerScript.player3.colour;
                PlayerScript.player3.oneFreeCandle++;

            }
            else if (PlayerScript.activePlayer.colour == PlayerScript.player4.colour)
            {
                candle.GetComponent<SpriteRenderer>().color = PlayerScript.player4.colour;
                PlayerScript.player4.oneFreeCandle++;
            }


            #region Win
            int candleCount = 0;
            foreach (ObjectOnBoardLists.Candle otherCandle in ObjectOnBoardLists.candlesOnBoard)
            {
                if (otherCandle.player.colour == PlayerScript.activePlayer.colour)
                {
                    candleCount++;
                }
            }
            GameObject candlePog = new GameObject();
            if (candleCount >= 5)
            {
                int winNum = 0;
                foreach (ObjectOnBoardLists.Candle Anothercandle in ObjectOnBoardLists.candlesOnBoard)
                {
                    if (Anothercandle.player.colour == PlayerScript.activePlayer.colour)
                    {
                        if (Anothercandle.gameObject.transform.position == new Vector3(PlayerScript.activePlayer.winningPosition[0].x, PlayerScript.activePlayer.winningPosition[0].y, 0))
                        {
                            candlePog = Anothercandle.gameObject;
                        }
                    }
                }

                foreach (ObjectOnBoardLists.Road road in ObjectOnBoardLists.roadsOnBoard)
                {
                    if (road.player.colour == PlayerScript.activePlayer.colour)
                    {
                        Vector3 rPos = road.gameObject.transform.position;
                        Vector3 cPos = candlePog.gameObject.transform.position;

                        if (cPos == new Vector3(rPos.x + 0.25f, rPos.y - 0.075f, 0) || cPos == new Vector3(rPos.x + 0.75f, rPos.y - 0.075f, 0) || cPos == new Vector3(rPos.x + 1f, rPos.y + 0.35f, 0) || cPos == new Vector3(rPos.x + 1.25f, rPos.y + 0.775f, 0) || cPos == new Vector3(rPos.x + 1.5f, rPos.y + 1.2f, 0) || cPos == new Vector3(rPos.x + 1.25f, rPos.y + 1.625f, 0) || cPos == new Vector3(rPos.x + 1f, rPos.y + 2.05f, 0) || cPos == new Vector3(rPos.x + 0.75f, rPos.y + 2.475f, 0) || cPos == new Vector3(rPos.x + 0.25f, rPos.y + 2.475f, 0) || cPos == new Vector3(rPos.x - 0.25f, rPos.y + 2.475f, 0) || cPos == new Vector3(rPos.x - 0.75f, rPos.y + 2.475f, 0) || cPos == new Vector3(rPos.x - 1f, rPos.y + 2.05f, 0) || cPos == new Vector3(rPos.x - 1.25f, rPos.y + 1.625f, 0) || cPos == new Vector3(rPos.x - 1.5f, rPos.y + 1.2f, 0) || cPos == new Vector3(rPos.x - 1.25f, rPos.y + 0.775f, 0) || cPos == new Vector3(rPos.x - 1f, rPos.y + 0.35f, 0) || cPos == new Vector3(rPos.x - 0.75f, rPos.y - 0.075f, 0) || cPos == new Vector3(rPos.x - 0.25f, rPos.y - 0.075f, 0))
                        {
                            winNum++;
                        }
                    }
                    
                }

                if (winNum >= 18)
                {
                    WinScript.Win();
                }
            }
            #endregion

            PlacementLists.UpdateAvailableRoads();
            PlacementLists.UpdateAvailableHouses();
            PlacementLists.UpdateAvailableCandles();

        }
    }

    public static void BotPlaceRoad(Vector3 roadPos)
    {
        #region Cost

        ResourceScript.GiveClay(-1);
        ResourceScript.GiveWood(-1);

        #endregion

        GameObject road = new GameObject();
        if (roadPos.z == 1)
        {
            road = (GameObject)Instantiate(Resources.Load("Roads/StraightRoad"), new Vector2(roadPos.x, roadPos.y), Quaternion.Euler(Resources.Load<GameObject>("Roads/StraightRoad").transform.eulerAngles));
        }
        else if (roadPos.z == 2)
        {
            road = (GameObject)Instantiate(Resources.Load("Roads/TiltedRoadLeft"), new Vector2(roadPos.x, roadPos.y), Quaternion.Euler(Resources.Load<GameObject>("Roads/TiltedRoadLeft").transform.eulerAngles));
        }
        else if (roadPos.z == 3)
        {
            road = (GameObject)Instantiate(Resources.Load("Roads/TiltedRoadRight"), new Vector2(roadPos.x, roadPos.y), Quaternion.Euler(Resources.Load<GameObject>("Roads/TiltedRoadRight").transform.eulerAngles));
        }
        ObjectOnBoardLists.Road bigRoad = new ObjectOnBoardLists.Road();
        bigRoad.gameObject = road;

        if (PlayerScript.activePlayer.colour == PlayerScript.player1.colour)
        {
            road.GetComponent<SpriteRenderer>().color = PlayerScript.player1.colour;
            bigRoad.player = PlayerScript.player1;
        }
        else if (PlayerScript.activePlayer.colour == PlayerScript.player2.colour)
        {
            road.GetComponent<SpriteRenderer>().color = PlayerScript.player2.colour;
            bigRoad.player = PlayerScript.player2;
        }
        else if (PlayerScript.activePlayer.colour == PlayerScript.player3.colour)
        {
            road.GetComponent<SpriteRenderer>().color = PlayerScript.player3.colour;
            bigRoad.player = PlayerScript.player3;

        }
        else if (PlayerScript.activePlayer.colour == PlayerScript.player4.colour)
        {
            road.GetComponent<SpriteRenderer>().color = PlayerScript.player4.colour;
            bigRoad.player = PlayerScript.player4;

        }

        ObjectOnBoardLists.roadsOnBoard.Add(bigRoad);

        PlacementLists.UpdateAvailableRoads();
        PlacementLists.UpdateAvailableHouses();


        #region Win
        GameObject candlePog = new GameObject();

        int winNum = 0;
        foreach (ObjectOnBoardLists.Candle Anothercandle in ObjectOnBoardLists.candlesOnBoard)
        {
            if (Anothercandle.player.colour == PlayerScript.activePlayer.colour)
            {
                if (Anothercandle.gameObject.transform.position == new Vector3(PlayerScript.activePlayer.winningPosition[0].x, PlayerScript.activePlayer.winningPosition[0].y, 0))
                {
                    candlePog = Anothercandle.gameObject;
                }
            }
        }

        foreach (ObjectOnBoardLists.Road aRoad in ObjectOnBoardLists.roadsOnBoard)
        {
            if (aRoad.player.colour == PlayerScript.activePlayer.colour)
            {
                Vector3 rPos = aRoad.gameObject.transform.position;
                Vector3 cPos = candlePog.gameObject.transform.position;

                if (cPos == new Vector3(rPos.x + 0.25f, rPos.y - 0.075f, 0) || cPos == new Vector3(rPos.x + 0.75f, rPos.y - 0.075f, 0) || cPos == new Vector3(rPos.x + 1f, rPos.y + 0.35f, 0) || cPos == new Vector3(rPos.x + 1.25f, rPos.y + 0.775f, 0) || cPos == new Vector3(rPos.x + 1.5f, rPos.y + 1.2f, 0) || cPos == new Vector3(rPos.x + 1.25f, rPos.y + 1.625f, 0) || cPos == new Vector3(rPos.x + 1f, rPos.y + 2.05f, 0) || cPos == new Vector3(rPos.x + 0.75f, rPos.y + 2.475f, 0) || cPos == new Vector3(rPos.x + 0.25f, rPos.y + 2.475f, 0) || cPos == new Vector3(rPos.x - 0.25f, rPos.y + 2.475f, 0) || cPos == new Vector3(rPos.x - 0.75f, rPos.y + 2.475f, 0) || cPos == new Vector3(rPos.x - 1f, rPos.y + 2.05f, 0) || cPos == new Vector3(rPos.x - 1.25f, rPos.y + 1.625f, 0) || cPos == new Vector3(rPos.x - 1.5f, rPos.y + 1.2f, 0) || cPos == new Vector3(rPos.x - 1.25f, rPos.y + 0.775f, 0) || cPos == new Vector3(rPos.x - 1f, rPos.y + 0.35f, 0) || cPos == new Vector3(rPos.x - 0.75f, rPos.y - 0.075f, 0) || cPos == new Vector3(rPos.x - 0.25f, rPos.y - 0.075f, 0))
                {
                    winNum++;
                }
            }

        }

        if (winNum >= 18)
        {
            WinScript.Win();
        }
        
        #endregion

    }
}
