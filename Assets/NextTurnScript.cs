using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using System;
public class NextTurnScript : MonoBehaviour
{
    [SerializeField]
    Image player1;
    [SerializeField]
    Image player2;
    [SerializeField]
    Image player3;
    [SerializeField]
    Image player4;

    [SerializeField]
    GameObject diePanel;

    public void NextTurn()
    {
        DieRoll.rolled = false;

        if (PlayerScript.activePlayer.colour == PlayerScript.player1.colour)
        {
            PlayerScript.activePlayer = PlayerScript.player2;

            player1.color = Color.gray;
            player2.color = Color.white;
            player3.color = Color.grey;
            player4.color = Color.grey;
        }
        else if (PlayerScript.activePlayer.colour == PlayerScript.player2.colour)
        {
            PlayerScript.activePlayer = PlayerScript.player3;

            player1.color = Color.gray;
            player2.color = Color.grey;
            player3.color = Color.white;
            player4.color = Color.grey;
        }
        else if (PlayerScript.activePlayer.colour == PlayerScript.player3.colour)
        {
            PlayerScript.activePlayer = PlayerScript.player4;

            player1.color = Color.gray;
            player2.color = Color.grey;
            player3.color = Color.grey;
            player4.color = Color.white;
        }
        else if (PlayerScript.activePlayer.colour == PlayerScript.player4.colour)
        {
            PlayerScript.activePlayer = PlayerScript.player1;

            player1.color = Color.white;
            player2.color = Color.grey;
            player3.color = Color.grey;
            player4.color = Color.grey;
        }

        PlacementLists.UpdateAvailableCities();
        PlacementLists.UpdateAvailableHouses();
        PlacementLists.UpdateAvailableRoads();
        PlacementLists.UpdateAvailableCandles();


        ResourceScript.GiveWood(0);
        ResourceScript.GiveClay(0);
        ResourceScript.GiveSheep(0);
        ResourceScript.GiveWheat(0);
        ResourceScript.GiveStone(0);

        #region Dynamite Explosion
        ObjectOnBoardLists.Dynamite theDynamiteThatCould = new ObjectOnBoardLists.Dynamite();

    LoopStartOver:
        int num = 0;
        foreach (ObjectOnBoardLists.Dynamite dynamite in ObjectOnBoardLists.dynamitesOnBoard)
        {
            if (dynamite.player.colour == PlayerScript.activePlayer.colour)
            {
                // Check for Knight
                foreach (GameObject knight in ObjectOnBoardLists.knightsOnBoard)
                {
                    if (knight.transform.position == dynamite.gameObject.transform.position)
                    {
                        theDynamiteThatCould = dynamite;
                        ObjectOnBoardLists.RemoveDynamiteFromBoard(dynamite.gameObject);

                        Destroy(knight);
                        ObjectOnBoardLists.knightsOnBoard.Remove(knight);

                        goto LoopStartOver;
                    }
                } 

                //Rest of buildings
                foreach (ObjectOnBoardLists.House item in ObjectOnBoardLists.housesOnBoard)
                {
                    if (item.gameObject.transform.position == dynamite.gameObject.transform.position)
                    {
                        theDynamiteThatCould = dynamite;
                        ObjectOnBoardLists.RemoveHouseFromBoard(item.gameObject);
                        ObjectOnBoardLists.RemoveDynamiteFromBoard(dynamite.gameObject);
                        goto LoopStartOver;
                    }
                }
                foreach (ObjectOnBoardLists.City item in ObjectOnBoardLists.citiesOnBoard)
                {
                    if (item.gameObject.transform.position == dynamite.gameObject.transform.position)
                    {
                        theDynamiteThatCould = dynamite;
                        ObjectOnBoardLists.RemoveCityFromBoard(item.gameObject);
                        ObjectOnBoardLists.RemoveDynamiteFromBoard(dynamite.gameObject);
                        goto LoopStartOver;
                    }
                }
                foreach (ObjectOnBoardLists.Road item in ObjectOnBoardLists.roadsOnBoard)
                {
                    if (item.gameObject.transform.position == dynamite.gameObject.transform.position)
                    {
                        theDynamiteThatCould = dynamite;
                        ObjectOnBoardLists.RemoveRoadFromBoard(item.gameObject);
                        ObjectOnBoardLists.RemoveDynamiteFromBoard(dynamite.gameObject);
                        goto LoopStartOver;
                    }
                }
                foreach (ObjectOnBoardLists.Candle item in ObjectOnBoardLists.candlesOnBoard)
                {
                    if (item.gameObject.transform.position == dynamite.gameObject.transform.position)
                    {
                        theDynamiteThatCould = dynamite;
                        ObjectOnBoardLists.RemoveCandleFromBoard(item.gameObject);
                        ObjectOnBoardLists.RemoveDynamiteFromBoard(dynamite.gameObject);
                        goto LoopStartOver;

                    }
                }
                if (theDynamiteThatCould.player.colour == dynamite.player.colour)
                {
                    if (dynamite.gameObject.transform.position == theDynamiteThatCould.gameObject.transform.position)
                    {
                        ObjectOnBoardLists.RemoveDynamiteFromBoard(dynamite.gameObject);
                        goto LoopStartOver;
                    }
                }
                
            }
            else
            {
                num++;
                if (num >= ObjectOnBoardLists.dynamitesOnBoard.Count)
                {
                    break;
                }
            }
        }
    




        #endregion

        if (PlayerScript.activePlayer.isBot == true)
        {
            BotScript.botTurn = true;
            StartCoroutine("TakeBotTurn", gameObject.GetComponent<NextTurnScript>());
        }
        else if (PlayerScript.activePlayer.isBot == false)
        {
            BotScript.botTurn = false;
        }
    }

    public static Vector2 houseGoalBotOne = new Vector2();
    public static Vector2 houseGoalBotTwo = new Vector2();
    public static Vector2 houseGoalBotThree = new Vector2();
    public static Vector2 houseGoalBotFour = new Vector2();

    

    public IEnumerator TakeBotTurn(NextTurnScript nextTurnScript) 
    {

        #region Protect Buildings From Dynamite
        StartOver:
        int numBreak = 0;

        foreach (ObjectOnBoardLists.Dynamite dynamite in ObjectOnBoardLists.dynamitesOnBoard)
        {
            if (PlayerScript.activePlayer.sheepAmount >= 1 && PlayerScript.activePlayer.woodAmount >= 2)
            {
                foreach (ObjectOnBoardLists.Candle item in ObjectOnBoardLists.candlesOnBoard)
                {
                    if (item.gameObject.transform.position == dynamite.gameObject.transform.position && item.player.colour == PlayerScript.activePlayer.colour)
                    {
                        if (PlayerScript.activePlayer.woodAmount > 30)
                        {
                            ResourceScript.GiveWood(-6);
                            ResourceScript.GiveSheep(-1);
                        }
                        else
                        {
                            ResourceScript.GiveWood(-6);
                            ResourceScript.GiveSheep(-1);
                        }
                        
                        ObjectOnBoardLists.RemoveDynamiteFromBoard(dynamite.gameObject);
                        goto StartOver;
                    }
                }
                foreach (ObjectOnBoardLists.House item in ObjectOnBoardLists.housesOnBoard)
                {
                    if (item.gameObject.transform.position == dynamite.gameObject.transform.position && item.player.colour == PlayerScript.activePlayer.colour)
                    {
                        if (PlayerScript.activePlayer.woodAmount > 30)
                        {
                            ResourceScript.GiveWood(-6);
                            ResourceScript.GiveSheep(-1);
                        }
                        else
                        {
                            ResourceScript.GiveWood(-6);
                            ResourceScript.GiveSheep(-1);
                        }
                        ObjectOnBoardLists.RemoveDynamiteFromBoard(dynamite.gameObject);
                        goto StartOver;
                    }
                }
                foreach (ObjectOnBoardLists.City item in ObjectOnBoardLists.citiesOnBoard)
                {
                    if (item.gameObject.transform.position == dynamite.gameObject.transform.position && item.player.colour == PlayerScript.activePlayer.colour)
                    {
                        if (PlayerScript.activePlayer.woodAmount > 30)
                        {
                            ResourceScript.GiveWood(-6);
                            ResourceScript.GiveSheep(-1);
                        }
                        else
                        {
                            ResourceScript.GiveWood(-6);
                            ResourceScript.GiveSheep(-1);
                        }
                        ObjectOnBoardLists.RemoveDynamiteFromBoard(dynamite.gameObject);
                        goto StartOver;
                    }
                }
                foreach (ObjectOnBoardLists.Road item in ObjectOnBoardLists.roadsOnBoard)
                {
                    if (item.gameObject.transform.position == dynamite.gameObject.transform.position && item.player.colour == PlayerScript.activePlayer.colour)
                    {
                        if (PlayerScript.activePlayer.woodAmount > 30)
                        {
                            ResourceScript.GiveWood(-6);
                            ResourceScript.GiveSheep(-1);
                        }
                        else
                        {
                            ResourceScript.GiveWood(-6);
                            ResourceScript.GiveSheep(-1);
                        }
                        ObjectOnBoardLists.RemoveDynamiteFromBoard(dynamite.gameObject);
                        goto StartOver;
                    }
                }
                
            }
            else
            {
                numBreak++;
                if (numBreak >= ObjectOnBoardLists.dynamitesOnBoard.Count)
                {
                    break;
                }
            }

        }

        #endregion

        if (PlayerScript.activePlayer.inTheEndgame) // ALRIGHT LISTEN HERE FUCKO, BIG PROBLEM - THE AI IS STUPID AND PUTS CANDLES WHERE IT CANT BUILD ROADS, RIGHT? EASY FIX! JUST CHECK TO SE IF THE FIVE RELATIVE HEXAGONS TO CANDLEPOG EXIST!
        {
            int candleNum = 0;
            foreach (ObjectOnBoardLists.Candle item in ObjectOnBoardLists.candlesOnBoard)
            {
                if (item.player.colour == PlayerScript.activePlayer.colour)
                {
                    candleNum++;
                }
            }

            #region Find Winning Position (Once)
            if (PlayerScript.activePlayer.winningPosition.Count == 0)
            {

                foreach (ObjectOnBoardLists.House house in ObjectOnBoardLists.housesOnBoard)
                {
                    if (house.player.colour == PlayerScript.activePlayer.colour)
                    {
                        int num = 0;
                        foreach (Hexagons.Tile tile in Hexagons.hexagons)
                        {
                            if (new Vector3(tile.gameObject.transform.position.x + 0.5f, tile.gameObject.transform.position.y + 0.35f, 0) == house.gameObject.transform.position || new Vector3(tile.gameObject.transform.position.x - 0.5f, tile.gameObject.transform.position.y + 0.35f, 0) == house.gameObject.transform.position)
                            {
                                num++;
                            }
                        }

                        if (num == 2)
                        {
                            foreach (Hexagons.Tile tile in Hexagons.hexagons)
                            {
                                if (new Vector3(tile.gameObject.transform.position.x + 0.5f, tile.gameObject.transform.position.y + 0.35f, 0) == house.gameObject.transform.position || new Vector3(tile.gameObject.transform.position.x + 1f, tile.gameObject.transform.position.y + 1.2f, 0) == house.gameObject.transform.position || new Vector3(tile.gameObject.transform.position.x + 0f, tile.gameObject.transform.position.y + 1.2f, 0) == house.gameObject.transform.position || new Vector3(tile.gameObject.transform.position.x - 1f, tile.gameObject.transform.position.y + 1.2f, 0) == house.gameObject.transform.position || new Vector3(tile.gameObject.transform.position.x - 0.5f, tile.gameObject.transform.position.y + 0.35f, 0) == house.gameObject.transform.position || new Vector3(tile.gameObject.transform.position.x + 0.5f, tile.gameObject.transform.position.y + 2.05f, 0) == house.gameObject.transform.position || new Vector3(tile.gameObject.transform.position.x - 0.5f, tile.gameObject.transform.position.y + 2.05f, 0) == house.gameObject.transform.position)
                                {
                                    num++;
                                }
                            }
                            if (num >= 9)
                            {
                                PlayerScript.activePlayer.winningPosition.Add(house.gameObject.transform.position);
                                goto LoopEnd;
                            }
                            
                        }
                    }

                }


                foreach (ObjectOnBoardLists.City city in ObjectOnBoardLists.citiesOnBoard)
                {
                    if (city.player.colour == PlayerScript.activePlayer.colour)
                    {
                        int num2 = 0;
                        foreach (Hexagons.Tile tile in Hexagons.hexagons)
                        {
                            if (new Vector3(tile.gameObject.transform.position.x + 0.5f, tile.gameObject.transform.position.y + 0.35f, 0) == city.gameObject.transform.position || new Vector3(tile.gameObject.transform.position.x - 0.5f, tile.gameObject.transform.position.y + 0.35f, 0) == city.gameObject.transform.position)
                            {
                                num2++;

                            }
                        }
                        if (num2 == 2)
                        {
                            foreach (Hexagons.Tile tile in Hexagons.hexagons)
                            {
                                if (new Vector3(tile.gameObject.transform.position.x + 0.5f, tile.gameObject.transform.position.y + 0.35f, 0) == city.gameObject.transform.position || new Vector3(tile.gameObject.transform.position.x + 1f, tile.gameObject.transform.position.y + 1.2f, 0) == city.gameObject.transform.position || new Vector3(tile.gameObject.transform.position.x + 0f, tile.gameObject.transform.position.y + 1.2f, 0) == city.gameObject.transform.position || new Vector3(tile.gameObject.transform.position.x - 1f, tile.gameObject.transform.position.y + 1.2f, 0) == city.gameObject.transform.position || new Vector3(tile.gameObject.transform.position.x - 0.5f, tile.gameObject.transform.position.y + 0.35f, 0) == city.gameObject.transform.position || new Vector3(tile.gameObject.transform.position.x + 0.5f, tile.gameObject.transform.position.y + 2.05f, 0) == city.gameObject.transform.position || new Vector3(tile.gameObject.transform.position.x - 0.5f, tile.gameObject.transform.position.y + 2.05f, 0) == city.gameObject.transform.position)
                                {
                                    num2++;
                                }
                            }
                            if (num2 >= 9)
                            {
                                PlayerScript.activePlayer.winningPosition.Add(city.gameObject.transform.position);
                                goto LoopEnd;
                            }
                        }
                        else
                        {
                            print("We are no longer in the endgame");
                            if (PlayerScript.activePlayer.colour == PlayerScript.player1.colour)
                            {
                                PlayerScript.player1.inTheEndgame = false;
                            }
                            else if (PlayerScript.activePlayer.colour == PlayerScript.player2.colour)
                            {
                                PlayerScript.player2.inTheEndgame = false;
                            }
                            else if (PlayerScript.activePlayer.colour == PlayerScript.player3.colour)
                            {
                                PlayerScript.player3.inTheEndgame = false;
                            }
                            else if (PlayerScript.activePlayer.colour == PlayerScript.player4.colour)
                            {
                                PlayerScript.player4.inTheEndgame = false;
                            }
                            goto DoneForToday;
                        }
                    }
                }




            LoopEnd:;
                #region Add Winning Position

                //Candles, First 5
                PlayerScript.activePlayer.winningPosition.Add(new Vector2(PlayerScript.activePlayer.winningPosition[0].x - 1.5f, PlayerScript.activePlayer.winningPosition[0].y - 0.85f));
                PlayerScript.activePlayer.winningPosition.Add(new Vector2(PlayerScript.activePlayer.winningPosition[0].x - 1f, PlayerScript.activePlayer.winningPosition[0].y - 2.4f));
                PlayerScript.activePlayer.winningPosition.Add(new Vector2(PlayerScript.activePlayer.winningPosition[0].x + 1f, PlayerScript.activePlayer.winningPosition[0].y - 2.4f));
                PlayerScript.activePlayer.winningPosition.Add(new Vector2(PlayerScript.activePlayer.winningPosition[0].x + 1.5f, PlayerScript.activePlayer.winningPosition[0].y - 0.85f));

                //Roads, The rest
                PlayerScript.activePlayer.winningPosition.Add(new Vector2(PlayerScript.activePlayer.winningPosition[0].x - 0.25f, PlayerScript.activePlayer.winningPosition[0].y + 0.075f));
                PlayerScript.activePlayer.winningPosition.Add(new Vector2(PlayerScript.activePlayer.winningPosition[0].x - 0.75f, PlayerScript.activePlayer.winningPosition[0].y + 0.075f));
                PlayerScript.activePlayer.winningPosition.Add(new Vector2(PlayerScript.activePlayer.winningPosition[0].x - 1f, PlayerScript.activePlayer.winningPosition[0].y - 0.35f));
                PlayerScript.activePlayer.winningPosition.Add(new Vector2(PlayerScript.activePlayer.winningPosition[0].x - 1.25f, PlayerScript.activePlayer.winningPosition[0].y - 0.775f));
                PlayerScript.activePlayer.winningPosition.Add(new Vector2(PlayerScript.activePlayer.winningPosition[0].x - 1.5f, PlayerScript.activePlayer.winningPosition[0].y - 1.2f));
                PlayerScript.activePlayer.winningPosition.Add(new Vector2(PlayerScript.activePlayer.winningPosition[0].x - 1.25f, PlayerScript.activePlayer.winningPosition[0].y - 1.625f));
                PlayerScript.activePlayer.winningPosition.Add(new Vector2(PlayerScript.activePlayer.winningPosition[0].x - 1f, PlayerScript.activePlayer.winningPosition[0].y - 2.05f));
                PlayerScript.activePlayer.winningPosition.Add(new Vector2(PlayerScript.activePlayer.winningPosition[0].x - 0.75f, PlayerScript.activePlayer.winningPosition[0].y - 2.475f));
                PlayerScript.activePlayer.winningPosition.Add(new Vector2(PlayerScript.activePlayer.winningPosition[0].x - 0.25f, PlayerScript.activePlayer.winningPosition[0].y - 2.475f));
                PlayerScript.activePlayer.winningPosition.Add(new Vector2(PlayerScript.activePlayer.winningPosition[0].x + 0.25f, PlayerScript.activePlayer.winningPosition[0].y - 2.475f));
                PlayerScript.activePlayer.winningPosition.Add(new Vector2(PlayerScript.activePlayer.winningPosition[0].x + 0.75f, PlayerScript.activePlayer.winningPosition[0].y - 2.475f));
                PlayerScript.activePlayer.winningPosition.Add(new Vector2(PlayerScript.activePlayer.winningPosition[0].x + 1f, PlayerScript.activePlayer.winningPosition[0].y - 2.05f));
                PlayerScript.activePlayer.winningPosition.Add(new Vector2(PlayerScript.activePlayer.winningPosition[0].x + 1.25f, PlayerScript.activePlayer.winningPosition[0].y - 1.625f));
                PlayerScript.activePlayer.winningPosition.Add(new Vector2(PlayerScript.activePlayer.winningPosition[0].x + 1.5f, PlayerScript.activePlayer.winningPosition[0].y - 1.2f));
                PlayerScript.activePlayer.winningPosition.Add(new Vector2(PlayerScript.activePlayer.winningPosition[0].x + 1.25f, PlayerScript.activePlayer.winningPosition[0].y - 0.775f));
                PlayerScript.activePlayer.winningPosition.Add(new Vector2(PlayerScript.activePlayer.winningPosition[0].x + 1f, PlayerScript.activePlayer.winningPosition[0].y - 0.35f));
                PlayerScript.activePlayer.winningPosition.Add(new Vector2(PlayerScript.activePlayer.winningPosition[0].x + 0.75f, PlayerScript.activePlayer.winningPosition[0].y + 0.075f));
                PlayerScript.activePlayer.winningPosition.Add(new Vector2(PlayerScript.activePlayer.winningPosition[0].x + 0.25f, PlayerScript.activePlayer.winningPosition[0].y + 0.075f));

                if (PlayerScript.activePlayer.colour == PlayerScript.player1.colour)
                {
                    PlayerScript.player1.winningPosition = PlayerScript.activePlayer.winningPosition;
                }
                else if (PlayerScript.activePlayer.colour == PlayerScript.player2.colour)
                {
                    PlayerScript.player2.winningPosition = PlayerScript.activePlayer.winningPosition;
                }
                else if (PlayerScript.activePlayer.colour == PlayerScript.player3.colour)
                {
                    PlayerScript.player3.winningPosition = PlayerScript.activePlayer.winningPosition;
                }
                else if (PlayerScript.activePlayer.colour == PlayerScript.player4.colour)
                {
                    PlayerScript.player4.winningPosition = PlayerScript.activePlayer.winningPosition;
                }

                #endregion

               
            }

            #endregion

            #region Roll Die

            diePanel.GetComponent<DieRoll>().RollDice();
            yield return new WaitForSeconds(0.1f);
            diePanel.GetComponent<DieRoll>().RollDice();

            #endregion

            #region Exchange To Sheep/Roads

            int evaq = 0;
            if (candleNum >= 5)
            {
                while (PlayerScript.activePlayer.wheatAmount >= 6 && evaq < 30)
                {
                    ResourceScript.GiveClay(2);
                    ResourceScript.GiveStone(1);
                    ResourceScript.GiveWheat(-6);

                    evaq++;
                } 
                while (PlayerScript.activePlayer.woodAmount >= 20 && evaq < 60)
                {
                    ResourceScript.GiveClay(2);
                    ResourceScript.GiveStone(1);
                    ResourceScript.GiveWood(-6);

                    evaq++;
                } 
                while (PlayerScript.activePlayer.sheepAmount >= 6 && evaq < 60)
                {
                    ResourceScript.GiveClay(2);
                    ResourceScript.GiveStone(1);
                    ResourceScript.GiveSheep(-6);

                    evaq++;
                }
            }
            else
            {
                while (PlayerScript.activePlayer.wheatAmount >= 2 && evaq < 30)
                {
                    ResourceScript.GiveSheep(1);
                    ResourceScript.GiveWheat(-2);

                    evaq++;
                }
            }
            
            #endregion

            #region Build Candles And Roads
            Vector3 candlePos = new Vector3();
            
            if (candleNum >= 5)
            {
            restart:;
                for (int i = 5; i < 23; i++) 
                {
                    Vector3 roadPlacement = new Vector3();

                    foreach (Vector3 rPlace in PlacementLists.roadPlacementList)
                    {
                        if (new Vector2(rPlace.x, rPlace.y) == PlayerScript.activePlayer.winningPosition[i])
                        {
                            BotScript.BotPlaceRoad(rPlace);
                            yield return new WaitForSeconds(0.1f);
                            goto restart;
                        }
                    }
                    
                    foreach (ObjectOnBoardLists.Road road in ObjectOnBoardLists.roadsOnBoard)
                    {
                        if (road.gameObject.transform.position == new Vector3(PlayerScript.activePlayer.winningPosition[i].x, PlayerScript.activePlayer.winningPosition[i].y, 0)) 
                        {
                            if (road.player.colour != PlayerScript.activePlayer.colour) // We NUKE!
                            {
                                int evaqAgain = 0;
                                while (PlayerScript.activePlayer.clayAmount >= 2 && PlayerScript.activePlayer.stoneAmount >= 1 && evaqAgain < 50)
                                {
                                    evaqAgain++;
                                    ResourceScript.GiveClay(-2);
                                    ResourceScript.GiveStone(-1);

                                    GameObject dynamite = (GameObject)Instantiate(Resources.Load("Building/BlowBuilding/Dynamite"), road.gameObject.transform.position, Quaternion.identity);
                                    ObjectOnBoardLists.Dynamite bigDynamite = new ObjectOnBoardLists.Dynamite();
                                    bigDynamite.gameObject = dynamite;

                                    if (PlayerScript.activePlayer.colour == PlayerScript.player1.colour)
                                    {
                                        bigDynamite.player = PlayerScript.player1;
                                    }
                                    else if (PlayerScript.activePlayer.colour == PlayerScript.player2.colour)
                                    {
                                        bigDynamite.player = PlayerScript.player2;
                                    }
                                    else if (PlayerScript.activePlayer.colour == PlayerScript.player3.colour)
                                    {
                                        bigDynamite.player = PlayerScript.player3;
                                    }
                                    else if (PlayerScript.activePlayer.colour == PlayerScript.player4.colour)
                                    {
                                        bigDynamite.player = PlayerScript.player4;
                                    }
                                    ObjectOnBoardLists.dynamitesOnBoard.Add(bigDynamite);
                                }
                                print("placed " + evaqAgain + " bombs on a road");
                                goto reiterate;
                            }
                            
                        }
                        
                    }

                reiterate:;
                }
            }
            else
            {
                for (int i = 0; i < 5; i++)
                {
                    bool nothingThere = true;
                    candlePos = PlayerScript.activePlayer.winningPosition[i];

                    foreach (ObjectOnBoardLists.Candle item in ObjectOnBoardLists.candlesOnBoard)
                    {
                        if (item.gameObject.transform.position == candlePos)
                        {
                            nothingThere = false;
                            goto reiterate;
                        }
                    }

                    foreach (ObjectOnBoardLists.House item in ObjectOnBoardLists.housesOnBoard)
                    {
                        if (item.gameObject.transform.position == candlePos)
                        {
                            if (item.player.colour == PlayerScript.activePlayer.colour)
                            {
                                ObjectOnBoardLists.RemoveHouseFromBoard(item.gameObject);
                                BotScript.BotPlaceCandle(candlePos);
                                goto reiterate;
                            }
                            else
                            {
                                int evaqAgain = 0;
                                while (PlayerScript.activePlayer.clayAmount >= 2 && PlayerScript.activePlayer.stoneAmount >= 1 && evaqAgain < 50)
                                {
                                    evaqAgain++;
                                    ResourceScript.GiveClay(-2);
                                    ResourceScript.GiveStone(-1);

                                    GameObject dynamite = (GameObject)Instantiate(Resources.Load("Building/BlowBuilding/Dynamite"), candlePos, Quaternion.identity);
                                    ObjectOnBoardLists.Dynamite bigDynamite = new ObjectOnBoardLists.Dynamite();
                                    bigDynamite.gameObject = dynamite;

                                    if (PlayerScript.activePlayer.colour == PlayerScript.player1.colour)
                                    {
                                        bigDynamite.player = PlayerScript.player1;
                                    }
                                    else if (PlayerScript.activePlayer.colour == PlayerScript.player2.colour)
                                    {
                                        bigDynamite.player = PlayerScript.player2;
                                    }
                                    else if (PlayerScript.activePlayer.colour == PlayerScript.player3.colour)
                                    {
                                        bigDynamite.player = PlayerScript.player3;
                                    }
                                    else if (PlayerScript.activePlayer.colour == PlayerScript.player4.colour)
                                    {
                                        bigDynamite.player = PlayerScript.player4;
                                    }
                                    ObjectOnBoardLists.dynamitesOnBoard.Add(bigDynamite);

                                }
                                // If there's a house there now we place as many dynamites we can and call it a day hoping for it to be gone next turn
                                goto DoneForToday;
                            }

                        }
                    }
                    foreach (ObjectOnBoardLists.City item in ObjectOnBoardLists.citiesOnBoard)
                    {
                        if (item.gameObject.transform.position == candlePos)
                        {
                            if (item.player.colour == PlayerScript.activePlayer.colour)
                            {
                                ObjectOnBoardLists.RemoveCityFromBoard(item.gameObject);
                                BotScript.BotPlaceCandle(candlePos);
                                goto reiterate;
                            }
                            else
                            {
                                int evaqAgain = 0;
                                while (PlayerScript.activePlayer.clayAmount >= 2 && PlayerScript.activePlayer.stoneAmount >= 1 && evaqAgain < 50)
                                {
                                    evaqAgain++;
                                    ResourceScript.GiveClay(-2);
                                    ResourceScript.GiveStone(-1);

                                    GameObject dynamite = (GameObject)Instantiate(Resources.Load("Building/BlowBuilding/Dynamite"), candlePos, Quaternion.identity);
                                    ObjectOnBoardLists.Dynamite bigDynamite = new ObjectOnBoardLists.Dynamite();
                                    bigDynamite.gameObject = dynamite;

                                    if (PlayerScript.activePlayer.colour == PlayerScript.player1.colour)
                                    {
                                        bigDynamite.player = PlayerScript.player1;
                                    }
                                    else if (PlayerScript.activePlayer.colour == PlayerScript.player2.colour)
                                    {
                                        bigDynamite.player = PlayerScript.player2;
                                    }
                                    else if (PlayerScript.activePlayer.colour == PlayerScript.player3.colour)
                                    {
                                        bigDynamite.player = PlayerScript.player3;
                                    }
                                    else if (PlayerScript.activePlayer.colour == PlayerScript.player4.colour)
                                    {
                                        bigDynamite.player = PlayerScript.player4;
                                    }
                                    ObjectOnBoardLists.dynamitesOnBoard.Add(bigDynamite);
                                }
                            }
                            print("Placed Dynamite On City");
                            goto DoneForToday;

                        }
                    }

                    foreach (ObjectOnBoardLists.Candle item in ObjectOnBoardLists.candlesOnBoard)
                    {
                        if (item.gameObject.transform.position == candlePos)
                        {
                            int evaqAgain = 0;
                            while (PlayerScript.activePlayer.clayAmount >= 2 && PlayerScript.activePlayer.stoneAmount >= 1 && evaqAgain < 50)
                            {
                                nothingThere = false;
                                evaqAgain++;
                                ResourceScript.GiveClay(-2);
                                ResourceScript.GiveStone(-1);

                                GameObject dynamite = (GameObject)Instantiate(Resources.Load("Building/BlowBuilding/Dynamite"), candlePos, Quaternion.identity);
                                ObjectOnBoardLists.Dynamite bigDynamite = new ObjectOnBoardLists.Dynamite();
                                bigDynamite.gameObject = dynamite;

                                if (PlayerScript.activePlayer.colour == PlayerScript.player1.colour)
                                {
                                    bigDynamite.player = PlayerScript.player1;
                                }
                                else if (PlayerScript.activePlayer.colour == PlayerScript.player2.colour)
                                {
                                    bigDynamite.player = PlayerScript.player2;
                                }
                                else if (PlayerScript.activePlayer.colour == PlayerScript.player3.colour)
                                {
                                    bigDynamite.player = PlayerScript.player3;
                                }
                                else if (PlayerScript.activePlayer.colour == PlayerScript.player4.colour)
                                {
                                    bigDynamite.player = PlayerScript.player4;
                                }
                                ObjectOnBoardLists.dynamitesOnBoard.Add(bigDynamite);
                            }
                            print("Bombed a candle " + evaqAgain + " times");
                        }
                    }

                    if (nothingThere)
                    {
                        BotScript.BotPlaceCandle(candlePos);
                        goto DoneForToday;
                    }

                reiterate:;
                }
            }
            

            #endregion



        DoneForToday:;
            yield return new WaitForSeconds(0.1f);
            nextTurnScript.NextTurn(); // DONE
        }
        else
        {

            #region Free House Placement

            if (PlayerScript.activePlayer.twoFreeHouses < 2)
            {
                for (int i = 0; i < 2; i++)
                {
                    Vector2 housePos = BotScript.FindBestHousePlacement();
                    #region Place House

                    PlayerScript.activePlayer.twoFreeHouses++;

                    if (PlayerScript.activePlayer.colour == PlayerScript.player1.colour)
                    {
                        PlayerScript.player1.twoFreeHouses++;
                    }
                    else if (PlayerScript.activePlayer.colour == PlayerScript.player2.colour)
                    {
                        PlayerScript.player2.twoFreeHouses++;
                    }
                    else if (PlayerScript.activePlayer.colour == PlayerScript.player3.colour)
                    {
                        PlayerScript.player3.twoFreeHouses++;
                    }
                    else if (PlayerScript.activePlayer.colour == PlayerScript.player4.colour)
                    {
                        PlayerScript.player4.twoFreeHouses++;
                    }


                    GameObject house = (GameObject)Instantiate(Resources.Load("House/Hus"), new Vector3(housePos.x, housePos.y, 0), Quaternion.identity);
                    ObjectOnBoardLists.AddHouseOnBoard(house);

                    if (PlayerScript.activePlayer.colour == PlayerScript.player1.colour)
                    {
                        house.GetComponent<SpriteRenderer>().color = PlayerScript.player1.colour;
                    }
                    else if (PlayerScript.activePlayer.colour == PlayerScript.player2.colour)
                    {
                        house.GetComponent<SpriteRenderer>().color = PlayerScript.player2.colour;
                    }
                    else if (PlayerScript.activePlayer.colour == PlayerScript.player3.colour)
                    {
                        house.GetComponent<SpriteRenderer>().color = PlayerScript.player3.colour;
                    }
                    else if (PlayerScript.activePlayer.colour == PlayerScript.player4.colour)
                    {
                        house.GetComponent<SpriteRenderer>().color = PlayerScript.player4.colour;
                    }


                    for (int g = 0; g < PlacementLists.housePlacementList.Count; g++) // Tar bort från listan
                    {
                        if (PlacementLists.housePlacementList[g] == housePos)
                        {
                            PlacementLists.housePlacementList.Remove(PlacementLists.housePlacementList[g]);
                        }
                    }

                    PlacementLists.UpdateAvailableRoads();
                    PlacementLists.UpdateAvailableCities();
                    PlacementLists.UpdateAvailableCandles();


                    if (PlayerScript.activePlayer.twoFreeHouses == 2)
                    {
                        PlacementLists.UpdateAvailableHouses();
                    }

                    yield return new WaitForSeconds(0.1f);

                    #endregion
                }
            }

            #endregion


            #region Place Roads 

            #region Free Roads


            if (PlayerScript.activePlayer.twoFreeRoads < 2)
            {

                
                for (int i = 0; i < 2; i++)
                {
                    int randNum = UnityEngine.Random.Range(0, PlacementLists.roadPlacementList.Count);
                    Vector3 roadToPlace = PlacementLists.roadPlacementList[randNum];

                    PlayerScript.activePlayer.twoFreeRoads++;

                    if (PlayerScript.activePlayer.colour == PlayerScript.player1.colour)
                    {
                        PlayerScript.player1.twoFreeRoads++;
                    }
                    else if (PlayerScript.activePlayer.colour == PlayerScript.player2.colour)
                    {
                        PlayerScript.player2.twoFreeRoads++;
                    }
                    else if (PlayerScript.activePlayer.colour == PlayerScript.player3.colour)
                    {
                        PlayerScript.player3.twoFreeRoads++;
                    }
                    else if (PlayerScript.activePlayer.colour == PlayerScript.player4.colour)
                    {
                        PlayerScript.player4.twoFreeRoads++;
                    }
                    GameObject road = new GameObject();
                    if (roadToPlace.z == 1)
                    {
                        road = (GameObject)Instantiate(Resources.Load("Roads/StraightRoad"), new Vector2(roadToPlace.x, roadToPlace.y), Quaternion.Euler(Resources.Load<GameObject>("Roads/StraightRoad").transform.eulerAngles));

                    }
                    else if (roadToPlace.z == 2)
                    {
                        road = (GameObject)Instantiate(Resources.Load("Roads/TiltedRoadLeft"), new Vector2(roadToPlace.x, roadToPlace.y), Quaternion.Euler(Resources.Load<GameObject>("Roads/TiltedRoadLeft").transform.eulerAngles));
                    }
                    else if (roadToPlace.z == 3)
                    {
                        road = (GameObject)Instantiate(Resources.Load("Roads/TiltedRoadRight"), new Vector2(roadToPlace.x, roadToPlace.y), Quaternion.Euler(Resources.Load<GameObject>("Roads/TiltedRoadRight").transform.eulerAngles));
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

                    yield return new WaitForSeconds(0.05f);

                    PlacementLists.UpdateAvailableRoads();

                    
                    if (PlayerScript.activePlayer.twoFreeRoads == 2)
                    {
                        PlacementLists.UpdateAvailableHouses();
                    }
                }
            }

            #endregion

            #region Normal Roads

            int evaq = 0;
            while (evaq < 50 && PlacementLists.roadPlacementList.Count != 0 && PlayerScript.activePlayer.woodAmount >= 1 && PlayerScript.activePlayer.clayAmount >= 1)
            {
                evaq++;

                int randNum = UnityEngine.Random.Range(0, PlacementLists.roadPlacementList.Count);
                Vector3 roadToPlace = PlacementLists.roadPlacementList[randNum];

                ResourceScript.GiveClay(-1);
                ResourceScript.GiveWood(-1);

                GameObject road = new GameObject();
                if (roadToPlace.z == 1)
                {
                    road = (GameObject)Instantiate(Resources.Load("Roads/StraightRoad"), new Vector2(roadToPlace.x, roadToPlace.y), Quaternion.Euler(Resources.Load<GameObject>("Roads/StraightRoad").transform.eulerAngles));

                }
                else if (roadToPlace.z == 2)
                {
                    road = (GameObject)Instantiate(Resources.Load("Roads/TiltedRoadLeft"), new Vector2(roadToPlace.x, roadToPlace.y), Quaternion.Euler(Resources.Load<GameObject>("Roads/TiltedRoadLeft").transform.eulerAngles));
                }
                else if (roadToPlace.z == 3)
                {
                    road = (GameObject)Instantiate(Resources.Load("Roads/TiltedRoadRight"), new Vector2(roadToPlace.x, roadToPlace.y), Quaternion.Euler(Resources.Load<GameObject>("Roads/TiltedRoadRight").transform.eulerAngles));
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

                yield return new WaitForSeconds(0.05f);


            }

            #endregion

            #endregion
            #region Place House Everywhere
            // The houseplacement does probably not have time to update and therefore the bot can place two houses too close
            while (PlacementLists.housePlacementList.Count != 0 && PlayerScript.activePlayer.woodAmount >= 1 &&  PlayerScript.activePlayer.wheatAmount >= 1)
            {
                foreach (Vector2 housePos in PlacementLists.housePlacementList)
                {

                    ResourceScript.GiveWood(-1);
                    ResourceScript.GiveWheat(-1);

                    GameObject house = (GameObject)Instantiate(Resources.Load("House/Hus"), housePos, Quaternion.identity);
                    ObjectOnBoardLists.AddHouseOnBoard(house);

                    if (PlayerScript.activePlayer.colour == PlayerScript.player1.colour)
                    {
                        house.GetComponent<SpriteRenderer>().color = PlayerScript.player1.colour;
                    }
                    else if (PlayerScript.activePlayer.colour == PlayerScript.player2.colour)
                    {
                        house.GetComponent<SpriteRenderer>().color = PlayerScript.player2.colour;
                    }
                    else if (PlayerScript.activePlayer.colour == PlayerScript.player3.colour)
                    {
                        house.GetComponent<SpriteRenderer>().color = PlayerScript.player3.colour;
                    }
                    else if (PlayerScript.activePlayer.colour == PlayerScript.player4.colour)
                    {
                        house.GetComponent<SpriteRenderer>().color = PlayerScript.player4.colour;
                    }

                    PlacementLists.UpdateAvailableRoads();
                    PlacementLists.UpdateAvailableCities();
                    PlacementLists.UpdateAvailableHouses();
                    PlacementLists.UpdateAvailableCandles();

                    yield return new WaitForSeconds(0.1f);

                    break;

                }
            }



            #endregion



            #region Roll Die

            diePanel.GetComponent<DieRoll>().RollDice();
            yield return new WaitForSeconds(0.1f);
            diePanel.GetComponent<DieRoll>().RollDice();

            #endregion

            #region Exchange

            PlayerScript playerScript = new PlayerScript();
            PlayerScript.Player player = (PlayerScript.Player)playerScript.GetType().GetTypeInfo().GetField("activePlayer").GetValue(this);

            string resourceNeeded = "";

            foreach (string resource in ResourceScript.resourceStringsCap)
            {

                if ((int)player.GetType().GetTypeInfo().GetProperty(resource.ToLower() + "Amount").GetValue(player) == 0)
                {
                    resourceNeeded = resource;
                }
            }

            foreach (string resource in ResourceScript.resourceStringsCap)
            {
                if ((int)player.GetType().GetTypeInfo().GetProperty(resource.ToLower() + "Amount").GetValue(player) >= 3 && resourceNeeded != "")
                {
                    ResourceScript script = new ResourceScript();

                    MethodInfo method = script.GetType().GetTypeInfo().GetMethod("Give" + resourceNeeded);

                    object[] parameter = new object[] { 1 };
                    method.Invoke(script.GetType(), parameter);

                    MethodInfo method2 = script.GetType().GetTypeInfo().GetMethod("Give" + resource);

                    object[] parameter2 = new object[] { -3 };
                    method2.Invoke(script.GetType(), parameter2);
                }
            }
            #endregion
            #region Upgrade To City

            // KOM IHÅG ATT FIXA SÅ ATT DE UPRADERAR DE BRA STÄDERNA, INTE DE DÅLIGA, TACK. BRA JOBBAT FÖRRESTEN :D
            List<ObjectOnBoardLists.House> myHouseList = new List<ObjectOnBoardLists.House>();
            foreach (ObjectOnBoardLists.House house in ObjectOnBoardLists.housesOnBoard)
            {
                if (house.player.colour == PlayerScript.activePlayer.colour)
                {
                    myHouseList.Add(house);
                }
            }
            int EMERGENCYEVAQAAAAAA = 0;
            while (PlayerScript.activePlayer.wheatAmount >= 1 && PlayerScript.activePlayer.stoneAmount >= 2 && myHouseList.Count != 0 && EMERGENCYEVAQAAAAAA < 5)
            {
                EMERGENCYEVAQAAAAAA++;
                foreach (Vector2 housePos in PlacementLists.housePlacementList)
                {
                    foreach (ObjectOnBoardLists.House item in myHouseList)
                    {
                        if (new Vector2(item.gameObject.transform.position.x, item.gameObject.transform.position.y) == housePos)
                        {
                            myHouseList.Remove(item);
                            break;
                        }
                    }

                    ResourceScript.GiveWheat(-1);
                    ResourceScript.GiveStone(-2);

                    GameObject city = (GameObject)Instantiate(Resources.Load("City/Stad"), housePos, Quaternion.identity);
                    ObjectOnBoardLists.City bigCity = new ObjectOnBoardLists.City();
                    bigCity.gameObject = city;

                    if (PlayerScript.activePlayer.colour == PlayerScript.player1.colour)
                    {
                        city.GetComponent<SpriteRenderer>().color = PlayerScript.player1.colour;
                        bigCity.player = PlayerScript.player1;
                    }
                    else if (PlayerScript.activePlayer.colour == PlayerScript.player2.colour)
                    {
                        city.GetComponent<SpriteRenderer>().color = PlayerScript.player2.colour;
                        bigCity.player = PlayerScript.player2;
                    }
                    else if (PlayerScript.activePlayer.colour == PlayerScript.player3.colour)
                    {
                        city.GetComponent<SpriteRenderer>().color = PlayerScript.player3.colour;
                        bigCity.player = PlayerScript.player3;
                    }
                    else if (PlayerScript.activePlayer.colour == PlayerScript.player4.colour)
                    {
                        city.GetComponent<SpriteRenderer>().color = PlayerScript.player4.colour;
                        bigCity.player = PlayerScript.player4;
                    }
                    ObjectOnBoardLists.citiesOnBoard.Add(bigCity);


                    for (int g = 0; g < PlacementLists.cityPlacementList.Count; g++) // Tar bort placeringen från listan
                    {
                        if (PlacementLists.cityPlacementList[g] == housePos)
                        {
                            PlacementLists.cityPlacementList.Remove(PlacementLists.cityPlacementList[g]);
                        }
                    }

                    List<ObjectOnBoardLists.House> killList = new List<ObjectOnBoardLists.House>(); // Tar bort huset från brädan och listan + lägger till cityMultipliern
                    foreach (ObjectOnBoardLists.House house in ObjectOnBoardLists.housesOnBoard)
                    {
                        GameObject item = house.gameObject;
                        if (item.transform.position == city.transform.position)
                        {
                            foreach (Hexagons.Tile tile in Hexagons.hexagons)
                            {
                                GameObject gTile = tile.gameObject;

                                if (gTile.transform.position == new Vector3(item.transform.position.x, item.transform.position.y + gTile.transform.localScale.y / 2, 0) || gTile.transform.position == new Vector3(item.transform.position.x, item.transform.position.y - gTile.transform.localScale.y / 2, 0) || gTile.transform.position == new Vector3(item.transform.position.x + gTile.transform.localScale.x / 2, item.transform.position.y + 0.35f) || gTile.transform.position == new Vector3(item.transform.position.x - gTile.transform.localScale.x / 2, item.transform.position.y + 0.35f) || gTile.transform.position == new Vector3(item.transform.position.x + gTile.transform.localScale.x / 2, item.transform.position.y - 0.35f) || gTile.transform.position == new Vector3(item.transform.position.x - gTile.transform.localScale.x / 2, item.transform.position.y - 0.35f))
                                {
                                    tile.cityMultiplier = 1;
                                }
                            }
                            killList.Add(house);
                        }
                    }
                    foreach (ObjectOnBoardLists.House item in killList)
                    {
                        ObjectOnBoardLists.housesOnBoard.Remove(item);
                        Destroy(item.gameObject);
                    }
                    killList.Clear();

                    PlacementLists.UpdateAvailableRoads();
                    PlacementLists.UpdateAvailableCities();

                    yield return new WaitForSeconds(0.1f);

                    break;
                }
            }

            if (EMERGENCYEVAQAAAAAA >= 50)
            {
                print("EMERGENCY EVAQ!");
            }


            #endregion
            #region Check If We're In The Endgame Now

            int buildingsNum = 0;

            foreach (ObjectOnBoardLists.House house in ObjectOnBoardLists.housesOnBoard)
            {
                if (house.player.colour == PlayerScript.activePlayer.colour)
                {
                    buildingsNum++;
                }
            }
            foreach (ObjectOnBoardLists.City city in ObjectOnBoardLists.citiesOnBoard)
            {
                if (city.player.colour == PlayerScript.activePlayer.colour)
                {
                    buildingsNum += 2;
                }
            }

            if (buildingsNum >= Mathf.RoundToInt(4 + int.Parse(EnterMapSizeScript.mapSizeString)))
            {
                print("We are now in the endgame");
                if (PlayerScript.activePlayer.colour == PlayerScript.player1.colour)
                {
                    PlayerScript.player1.inTheEndgame = true;
                }
                else if (PlayerScript.activePlayer.colour == PlayerScript.player2.colour)
                {
                    PlayerScript.player2.inTheEndgame = true;
                }
                else if (PlayerScript.activePlayer.colour == PlayerScript.player3.colour)
                {
                    PlayerScript.player3.inTheEndgame = true;
                }
                else if (PlayerScript.activePlayer.colour == PlayerScript.player4.colour)
                {
                    PlayerScript.player4.inTheEndgame = true;
                }
            }

            #endregion


            yield return new WaitForSeconds(0.1f);
            nextTurnScript.NextTurn(); // DONE

            
        }

    }
}
