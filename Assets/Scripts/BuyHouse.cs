using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class BuyHouse : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public static List<GameObject> houseLights = new List<GameObject>();
    public void BuyAHouse()
    {
        if (!ChillaMedLjusen.showing)
        {
            CancelBuyScript.cancelPanel.SetActive(true);


            #region Available Light

            foreach (Vector2 item in PlacementLists.housePlacementList)
            {
                GameObject psys = Instantiate(Resources.Load<GameObject>("BuildLights/BuildHouseLight"), new Vector3(item.x, item.y, 0), Quaternion.identity);
                houseLights.Add(psys);
            }

            ChillaMedLjusen.showing = true;
            #endregion
        }

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (PlayerScript.activePlayer.twoFreeHouses < 2)
        {
            CostPanelScript.CreateCostPanel(new List<Vector2>() { new Vector2(1, 1), new Vector2(2, 1), new Vector2(3, 1), new Vector2(4, 1) }, "Free!");

        }
        else
        {
            CostPanelScript.CreateCostPanel(new List<Vector2>() { new Vector2(1, 1), new Vector2(2, 1), new Vector2(3, 1), new Vector2(4, 1) }, "");

        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        CostPanelScript.DeleteCostPanel();
    }
}
