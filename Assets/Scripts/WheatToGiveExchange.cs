using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheatToGiveExchange : MonoBehaviour
{
    public void IPickedATerriblePositionPleaseGiveMeBailOutMoney()
    {

        BankManager.resourceToGet = "Wheat";

        if (BankManager.pushedPanelGive != null)
        {
            BankManager.pushedPanelGive.GetComponent<RectTransform>().anchoredPosition = new Vector2(BankManager.pushedPanelGive.GetComponent<RectTransform>().anchoredPosition.x, BankManager.pushedPanelGive.GetComponent<RectTransform>().anchoredPosition.y - 20);
        }
        gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(gameObject.GetComponent<RectTransform>().anchoredPosition.x, gameObject.GetComponent<RectTransform>().anchoredPosition.y + 20);

        BankManager.pushedPanelGive = gameObject;
    }
}
