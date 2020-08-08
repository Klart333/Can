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

        if (PlayerScript.activePlayer.color == PlayerScript.player1.color)
        {
            PlayerScript.player1.twoFreeRoads -= 2;
        }
        else if (PlayerScript.activePlayer.color == PlayerScript.player2.color)
        {
            PlayerScript.player2.twoFreeRoads -= 2;
        }
        else if (PlayerScript.activePlayer.color == PlayerScript.player3.color)
        {
            PlayerScript.player3.twoFreeRoads -= 2;
        }
        else if (PlayerScript.activePlayer.color == PlayerScript.player4.color)
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

