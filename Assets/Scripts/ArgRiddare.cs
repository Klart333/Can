using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ArgRiddare : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        CostPanelScript.CreateCostPanel(new List<Vector2>(), "Protects a building");
    }
    public static List<GameObject> knightLights = new List<GameObject>();
    public void UseProtecKnight()
    {
        if (!ChillaMedLjusen.showing)
        {
            CancelBuyScript.cancelPanel.SetActive(true);
            PlacementLists.UpdateDynamitePlacement();

            foreach (Vector2 item in PlacementLists.dynamitePlacementList)
            {
                GameObject psys = Instantiate(Resources.Load<GameObject>("BuildLights/PlaceKnightLight"), new Vector3(item.x, item.y, 0), Quaternion.identity);
                knightLights.Add(psys);
            }

            ChillaMedLjusen.showing = true;

            BuyDevCard.RemoveCard(gameObject);

        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        CostPanelScript.DeleteCostPanel();

    }
}
