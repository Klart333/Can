using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceCandle : MonoBehaviour
{
    // Note : Maybe make the screen shake a bit when placing candles for effect
    // no :)
    private void OnMouseDown()
    {
        if (true/*PlayerScript.activePlayer.sheepAmount >= 20*/)
        {
            ResourceScript.GiveSheep(-20);

            PlayerPrefs.SetInt("candlesPlaced", PlayerPrefs.GetInt("candlesPlaced") + 1);

            ChillaMedLjusen.showing = false;
            CancelBuyScript.cancelPanel.SetActive(false);

            GameObject candle = (GameObject)Instantiate(Resources.Load("Candle/CandleFaded"), transform.position, Quaternion.identity);
            ObjectOnBoardLists.Candle bigCandle = new ObjectOnBoardLists.Candle();
            bigCandle.gameObject = candle;
            bigCandle.player = PlayerScript.activePlayer;
            ObjectOnBoardLists.candlesOnBoard.Add(bigCandle);

            PlayerScript.activePlayer.oneFreeCandle++;
            if (PlayerScript.activePlayer.color == PlayerScript.player1.color)
            {
                candle.GetComponent<SpriteRenderer>().color = PlayerScript.player1.color;
                PlayerScript.player1.oneFreeCandle++;
            }
            else if (PlayerScript.activePlayer.color == PlayerScript.player2.color)
            {
                candle.GetComponent<SpriteRenderer>().color = PlayerScript.player2.color;
                PlayerScript.player2.oneFreeCandle++;
            }
            else if (PlayerScript.activePlayer.color == PlayerScript.player3.color)
            {
                candle.GetComponent<SpriteRenderer>().color = PlayerScript.player3.color;
                PlayerScript.player3.oneFreeCandle++;
            }
            else if (PlayerScript.activePlayer.color == PlayerScript.player4.color)
            {
                candle.GetComponent<SpriteRenderer>().color = PlayerScript.player4.color;
                PlayerScript.player4.oneFreeCandle++;
            }

            foreach (GameObject item in BuyCandle.candleLights)
            {
                Destroy(item.gameObject);
            }
            BuyCandle.candleLights.Clear();

            #region Win
            int num = 0;
            foreach (ObjectOnBoardLists.Candle otherCandle in ObjectOnBoardLists.candlesOnBoard)
            {
                if (otherCandle.player.color == PlayerScript.activePlayer.color)
                {
                    num++;
                }
            }
            float highestY = -9999;
            GameObject candlePog = new GameObject();
            if (num >= 5)
            {
                int winNum = 0;
                foreach (ObjectOnBoardLists.Candle Anothercandle in ObjectOnBoardLists.candlesOnBoard)
                {
                    if (Anothercandle.player.color == PlayerScript.activePlayer.color)
                    {
                        if (Anothercandle.gameObject.transform.position.y > highestY)
                        {
                            highestY = Anothercandle.gameObject.transform.position.y;
                            candlePog = Anothercandle.gameObject;
                        }
                    }
                }

                foreach (ObjectOnBoardLists.Road road in ObjectOnBoardLists.roadsOnBoard)
                {
                    if (road.player.color == PlayerScript.activePlayer.color)
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
}
