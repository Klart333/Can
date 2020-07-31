using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
public class PlaceCity : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (PlayerScript.activePlayer.wheatAmount >= 2 && PlayerScript.activePlayer.stoneAmount >= 3)
        {
            ResourceScript.GiveWheat(-2);
            ResourceScript.GiveStone(-3);

            PlayerPrefs.SetInt("citiesPlaced", PlayerPrefs.GetInt("citiesPlaced") + 1);

            CancelBuyScript.cancelPanel.SetActive(false);
            ChillaMedLjusen.showing = false;

            GameObject city = (GameObject)Instantiate(Resources.Load("City/Stad"), transform.position, Quaternion.identity);
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
                if (PlacementLists.cityPlacementList[g] == new Vector2(gameObject.transform.position.x, gameObject.transform.position.y))
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

            foreach (ParticleSystem item in BuyCity.cityLights)
            {
                Destroy(item.gameObject);
            }
            BuyCity.cityLights.Clear();

            PlacementLists.UpdateAvailableRoads();
            PlacementLists.UpdateAvailableCities();

        }
        
    }

}
