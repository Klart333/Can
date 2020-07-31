using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceDividense : MonoBehaviour
{
    public static void Distribution(int dieNum)
    {
        foreach (Hexagons.Tile tile in PlayerScript.player1.tileList)
        {
            if (tile.diceNumber == dieNum)
            {
                if (PlaceThief.thiefOnBoard == null || !(PlaceThief.thiefOnBoard.transform.position == tile.gameObject.transform.position))
                {
                    if (tile.resource == "Wood")
                    {
                        ResourceScript.GiveWoodP(1 + (1 * tile.cityMultiplier), PlayerScript.player1);
                    }
                    else if (tile.resource == "Clay")
                    {
                        ResourceScript.GiveClayP(1 + (1 * tile.cityMultiplier), PlayerScript.player1);
                    }
                    else if (tile.resource == "Sheep")
                    {
                        ResourceScript.GiveSheepP(1 + (1 * tile.cityMultiplier), PlayerScript.player1);

                    }
                    else if (tile.resource == "Wheat")
                    {
                        ResourceScript.GiveWheatP(1 + (1 * tile.cityMultiplier), PlayerScript.player1);

                    }
                    else if (tile.resource == "Stone")
                    {
                        ResourceScript.GiveStoneP(1 + (1 * tile.cityMultiplier), PlayerScript.player1);

                    }
                }
                

            }
        }

        foreach (Hexagons.Tile tile in PlayerScript.player2.tileList)
        {
            if (tile.diceNumber == dieNum)
            {
                if (PlaceThief.thiefOnBoard == null || !(PlaceThief.thiefOnBoard.transform.position == tile.gameObject.transform.position))
                {
                    if (tile.resource == "Wood")
                    {
                        ResourceScript.GiveWoodP(1 + (1 * tile.cityMultiplier), PlayerScript.player2);
                    }
                    else if (tile.resource == "Clay")
                    {
                        ResourceScript.GiveClayP(1 + (1 * tile.cityMultiplier), PlayerScript.player2);
                    }
                    else if (tile.resource == "Sheep")
                    {
                        ResourceScript.GiveSheepP(1 + (1 * tile.cityMultiplier), PlayerScript.player2);

                    }
                    else if (tile.resource == "Wheat")
                    {
                        ResourceScript.GiveWheatP(1 + (1 * tile.cityMultiplier), PlayerScript.player2);

                    }
                    else if (tile.resource == "Stone")
                    {
                        ResourceScript.GiveStoneP(1 + (1 * tile.cityMultiplier), PlayerScript.player2);

                    }
                }


            }
        }

        foreach (Hexagons.Tile tile in PlayerScript.player3.tileList)
        {
            if (tile.diceNumber == dieNum)
            {
                if (PlaceThief.thiefOnBoard == null || !(PlaceThief.thiefOnBoard.transform.position == tile.gameObject.transform.position))
                {
                    if (tile.resource == "Wood")
                    {
                        ResourceScript.GiveWoodP(1 + (1 * tile.cityMultiplier), PlayerScript.player3);
                    }
                    else if (tile.resource == "Clay")
                    {
                        ResourceScript.GiveClayP(1 + (1 * tile.cityMultiplier), PlayerScript.player3);
                    }
                    else if (tile.resource == "Sheep")
                    {
                        ResourceScript.GiveSheepP(1 + (1 * tile.cityMultiplier), PlayerScript.player3);

                    }
                    else if (tile.resource == "Wheat")
                    {
                        ResourceScript.GiveWheatP(1 + (1 * tile.cityMultiplier), PlayerScript.player3);

                    }
                    else if (tile.resource == "Stone")
                    {
                        ResourceScript.GiveStoneP(1 + (1 * tile.cityMultiplier), PlayerScript.player3);

                    }
                }


            }
        }

        foreach (Hexagons.Tile tile in PlayerScript.player4.tileList)
        {
            if (tile.diceNumber == dieNum)
            {
                if (PlaceThief.thiefOnBoard == null || !(PlaceThief.thiefOnBoard.transform.position == tile.gameObject.transform.position))
                {
                    if (tile.resource == "Wood")
                    {
                        ResourceScript.GiveWoodP(1 + (1 * tile.cityMultiplier), PlayerScript.player4);
                    }
                    else if (tile.resource == "Clay")
                    {
                        ResourceScript.GiveClayP(1 + (1 * tile.cityMultiplier), PlayerScript.player4);
                    }
                    else if (tile.resource == "Sheep")
                    {
                        ResourceScript.GiveSheepP(1 + (1 * tile.cityMultiplier), PlayerScript.player4);
                    }
                    else if (tile.resource == "Wheat")
                    {
                        ResourceScript.GiveWheatP(1 + (1 * tile.cityMultiplier), PlayerScript.player4);

                    }
                    else if (tile.resource == "Stone")
                    {
                        ResourceScript.GiveStoneP(1 + (1 * tile.cityMultiplier), PlayerScript.player4);
                    }
                }


            }
        }

    }
}
