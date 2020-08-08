using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceDynamite : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (PlayerScript.activePlayer.clayAmount >= 4 && PlayerScript.activePlayer.stoneAmount >= 2)
        {
            ResourceScript.GiveClay(-4);
            ResourceScript.GiveStone(-2);

            PlayerPrefs.SetInt("dynamitesPlaced", PlayerPrefs.GetInt("dynamitesPlaced") + 1);

            CancelBuyScript.cancelPanel.SetActive(false);
            ChillaMedLjusen.showing = false;

            GameObject dynamite = (GameObject)Instantiate(Resources.Load("Building/BlowBuilding/Dynamite"), transform.position, Quaternion.identity);
            ObjectOnBoardLists.Dynamite bigDynamite = new ObjectOnBoardLists.Dynamite();
            bigDynamite.gameObject = dynamite;

            if (PlayerScript.activePlayer.color == PlayerScript.player1.color)
            {
                bigDynamite.player = PlayerScript.player1;
            }
            else if (PlayerScript.activePlayer.color == PlayerScript.player2.color)
            {
                bigDynamite.player = PlayerScript.player2;
            }
            else if (PlayerScript.activePlayer.color == PlayerScript.player3.color)
            {
                bigDynamite.player = PlayerScript.player3;
            }
            else if (PlayerScript.activePlayer.color == PlayerScript.player4.color)
            {
                bigDynamite.player = PlayerScript.player4;
            }
            ObjectOnBoardLists.dynamitesOnBoard.Add(bigDynamite);

            foreach (GameObject item in BuyDynamite.dynamiteLights)
            {
                Destroy(item.gameObject);
            }
            BuyDynamite.dynamiteLights.Clear();

        }

    }
}
