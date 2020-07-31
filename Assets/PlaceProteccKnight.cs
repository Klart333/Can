using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceProteccKnight : MonoBehaviour
{
    private void OnMouseDown()
    {
        print("hello, placed");
        CancelBuyScript.cancelPanel.SetActive(false);
        ChillaMedLjusen.showing = false;

        GameObject knight = (GameObject)Instantiate(Resources.Load("DevCards/KnightOnBoard"), transform.position, Quaternion.identity);
        ObjectOnBoardLists.knightsOnBoard.Add(knight);

        foreach (GameObject item in ArgRiddare.knightLights)
        {
            Destroy(item.gameObject);
        }
        BuyDynamite.dynamiteLights.Clear();
    }
}
