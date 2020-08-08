using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceHouse : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (PlayerScript.activePlayer.twoFreeHouses < 2)
        {
            PlayerScript.activePlayer.twoFreeHouses++;

            if (PlayerScript.activePlayer.color == PlayerScript.player1.color)
            {
                PlayerScript.player1.twoFreeHouses++;
            }
            else if (PlayerScript.activePlayer.color == PlayerScript.player2.color)
            {
                PlayerScript.player2.twoFreeHouses++;
            }
            else if (PlayerScript.activePlayer.color == PlayerScript.player3.color)
            {
                PlayerScript.player3.twoFreeHouses++;
            }
            else if (PlayerScript.activePlayer.color == PlayerScript.player4.color)
            {
                PlayerScript.player4.twoFreeHouses++;
            }

            PlayerPrefs.SetInt("housesPlaced", PlayerPrefs.GetInt("housesPlaced") + 1);

            ChillaMedLjusen.showing = false;
            CancelBuyScript.cancelPanel.SetActive(false);

            GameObject house = (GameObject)Instantiate(Resources.Load("House/Hus"), transform.position, Quaternion.identity);
            ObjectOnBoardLists.AddHouseOnBoard(house);

            if (PlayerScript.activePlayer.color == PlayerScript.player1.color)
            {
                house.transform.GetChild(0).GetComponent<SpriteRenderer>().color = PlayerScript.player1.color;
            }
            else if (PlayerScript.activePlayer.color == PlayerScript.player2.color)
            {
                house.transform.GetChild(0).GetComponent<SpriteRenderer>().color = PlayerScript.player2.color;
            }
            else if (PlayerScript.activePlayer.color == PlayerScript.player3.color)
            {
                house.transform.GetChild(0).GetComponent<SpriteRenderer>().color = PlayerScript.player3.color;
            }
            else if (PlayerScript.activePlayer.color == PlayerScript.player4.color)
            {
                house.transform.GetChild(0).GetComponent<SpriteRenderer>().color = PlayerScript.player4.color;
            }


            for (int g = 0; g < PlacementLists.housePlacementList.Count; g++) // Tar bort från listan
            {
                if (PlacementLists.housePlacementList[g] == new Vector2(gameObject.transform.position.x, gameObject.transform.position.y))
                {
                    PlacementLists.housePlacementList.Remove(PlacementLists.housePlacementList[g]);
                }
            }

            foreach (GameObject item in BuyHouse.houseLights)
            {
                Destroy(item.gameObject);
            }
            BuyHouse.houseLights.Clear();

            PlacementLists.UpdateAvailableRoads();
            PlacementLists.UpdateAvailableCities();
            PlacementLists.UpdateAvailableCandles();


            if (PlayerScript.activePlayer.twoFreeHouses == 2)
            {
                PlacementLists.UpdateAvailableHouses();
            }
        }
        else if (PlayerScript.activePlayer.woodAmount >= 1 && PlayerScript.activePlayer.clayAmount >= 1 && PlayerScript.activePlayer.sheepAmount >= 1 && PlayerScript.activePlayer.wheatAmount >= 1)
        {
            #region Cost

            ResourceScript.GiveWood(-1);
            ResourceScript.GiveClay(-1);
            ResourceScript.GiveSheep(-1);
            ResourceScript.GiveWheat(-1);

            #endregion

            PlayerPrefs.SetInt("housesPlaced", PlayerPrefs.GetInt("housesPlaced") + 1);

            ChillaMedLjusen.showing = false;
            CancelBuyScript.cancelPanel.SetActive(false);

            GameObject house = (GameObject)Instantiate(Resources.Load("House/Hus"), transform.position, Quaternion.identity);
            ObjectOnBoardLists.AddHouseOnBoard(house);

            if (PlayerScript.activePlayer.color == PlayerScript.player1.color)
            {
                house.transform.GetChild(0).GetComponent<SpriteRenderer>().color = PlayerScript.player1.color;
            }
            else if (PlayerScript.activePlayer.color == PlayerScript.player2.color)
            {
                house.transform.GetChild(0).GetComponent<SpriteRenderer>().color = PlayerScript.player2.color;
            }
            else if (PlayerScript.activePlayer.color == PlayerScript.player3.color)
            {
                house.transform.GetChild(0).GetComponent<SpriteRenderer>().color = PlayerScript.player3.color;
            }
            else if (PlayerScript.activePlayer.color == PlayerScript.player4.color)
            {
                house.transform.GetChild(0).GetComponent<SpriteRenderer>().color = PlayerScript.player4.color;
            }

            foreach (GameObject item in BuyHouse.houseLights)
            {
                Destroy(item.gameObject);
            }
            BuyHouse.houseLights.Clear();

            PlacementLists.UpdateAvailableRoads();
            PlacementLists.UpdateAvailableCities();
            PlacementLists.UpdateAvailableHouses();
            PlacementLists.UpdateAvailableCandles();

        }

    }
}
