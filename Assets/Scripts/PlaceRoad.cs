using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceRoad : MonoBehaviour
{
    

    private void OnMouseDown()
    {
        if (PlayerScript.activePlayer.twoFreeRoads < 2)
        {
            PlayerScript.activePlayer.twoFreeRoads++;

            if (PlayerScript.activePlayer.colour == PlayerScript.player1.colour)
            {
                PlayerScript.player1.twoFreeRoads++;
            }
            else if(PlayerScript.activePlayer.colour == PlayerScript.player2.colour)
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

            PlayerPrefs.SetInt("roadsPlaced", PlayerPrefs.GetInt("roadsPlaced") + 1);

            ChillaMedLjusen.showing = false;
            CancelBuyScript.cancelPanel.SetActive(false);

            GameObject road = (GameObject)Instantiate(Resources.Load("Roads/" + gameObject.name), transform.position, Quaternion.Euler(Resources.Load<GameObject>("Roads/" + gameObject.name).transform.eulerAngles));
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
            if (PlayerScript.activePlayer.twoFreeRoads == 2)
            {
                PlacementLists.UpdateAvailableHouses();
            }


            for (int i = 0; i < BuyRoad.roadPlacementLight.Count; i++) // Tar bort ljusen
            {
                Destroy(BuyRoad.roadPlacementLight[i].gameObject);
            }
            BuyRoad.roadPlacementLight.Clear();

        }
        else if (PlayerScript.activePlayer.woodAmount >= 1 && PlayerScript.activePlayer.clayAmount >= 1)
        {
            #region Cost

            ResourceScript.GiveClay(-1);
            ResourceScript.GiveWood(-1);

            #endregion

            PlayerPrefs.SetInt("roadsPlaced", PlayerPrefs.GetInt("roadsPlaced") + 1);

            ChillaMedLjusen.showing = false;
            CancelBuyScript.cancelPanel.SetActive(false);

            GameObject road = (GameObject)Instantiate(Resources.Load("Roads/" + gameObject.name), transform.position, Quaternion.Euler(Resources.Load<GameObject>("Roads/" + gameObject.name).transform.eulerAngles));
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

            for (int i = 0; i < BuyRoad.roadPlacementLight.Count; i++) // Tar bort ljusen
            {
                Destroy(BuyRoad.roadPlacementLight[i].gameObject);
            }
            BuyRoad.roadPlacementLight.Clear();
        }

        #region Win
        int num = 0;
        foreach (ObjectOnBoardLists.Candle candle in ObjectOnBoardLists.candlesOnBoard)
        {
            if (candle.player.colour == PlayerScript.activePlayer.colour)
            {
                num++;
            }
        }
        float highestY = -9999;
        GameObject candlePog = new GameObject();
        if (num >= 5)
        {
            int winNum = 0;
            foreach (ObjectOnBoardLists.Candle candle in ObjectOnBoardLists.candlesOnBoard)
            {
                if (candle.player.colour == PlayerScript.activePlayer.colour)
                {
                    if (candle.gameObject.transform.position.y > highestY)
                    {
                        highestY = candle.gameObject.transform.position.y;
                        candlePog = candle.gameObject;
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
    }

}
