using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class FreeRoadsCard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        CostPanelScript.CreateCostPanel(new List<Vector2>(), "2 Free Roads");
    }

    public void GiveMeRoads()
    {
        PlayerScript.activePlayer.twoFreeRoads -= 2;

        if (PlayerScript.activePlayer.colour == PlayerScript.player1.colour)
        {
            PlayerScript.player1.twoFreeRoads -= 2;
        }
        else if (PlayerScript.activePlayer.colour == PlayerScript.player2.colour)
        {
            PlayerScript.player2.twoFreeRoads -= 2;
        }
        else if (PlayerScript.activePlayer.colour == PlayerScript.player3.colour)
        {
            PlayerScript.player3.twoFreeRoads -= 2;
        }
        else if (PlayerScript.activePlayer.colour == PlayerScript.player4.colour)
        {
            PlayerScript.player4.twoFreeRoads -= 2;
        }

        BuyDevCard.RemoveCard(gameObject);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        CostPanelScript.DeleteCostPanel();

    }
}

