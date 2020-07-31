using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class BuyCandle : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public static List<GameObject> candleLights = new List<GameObject>();
    public void BuyACandle()
    {
        if (!ChillaMedLjusen.showing)
        {
            CancelBuyScript.cancelPanel.SetActive(true);


            #region Available Light

            foreach (Vector2 item in PlacementLists.candlePlacementList)
            {
                GameObject psys = Instantiate(Resources.Load<GameObject>("BuildLights/BuildCandleLight"), new Vector3(item.x, item.y, 0), Quaternion.identity);
                candleLights.Add(psys);
            }

            ChillaMedLjusen.showing = true;
            #endregion
        }

    }
    public void OnPointerEnter(PointerEventData eventData)
    {

        CostPanelScript.CreateCostPanel(new List<Vector2>() { new Vector2(3, 20) }, "");

        
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        CostPanelScript.DeleteCostPanel();
    }
}
