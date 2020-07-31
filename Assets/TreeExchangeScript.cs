using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeExchangeScript : MonoBehaviour
{
    public void IPickedATerriblePositionPleaseGiveMeBailOutMoney()
    {

        BankManager.resourceToGive = "Wood";

        if (BankManager.pushedPanelGet != null)
        {
            BankManager.pushedPanelGet.GetComponent<RectTransform>().anchoredPosition = new Vector2(BankManager.pushedPanelGet.GetComponent<RectTransform>().anchoredPosition.x, BankManager.pushedPanelGet.GetComponent<RectTransform>().anchoredPosition.y + 20);
        }
        gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(gameObject.GetComponent<RectTransform>().anchoredPosition.x, gameObject.GetComponent<RectTransform>().anchoredPosition.y - 20);

        BankManager.pushedPanelGet = gameObject;
    }
}
