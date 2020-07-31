using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class BuyDynamite : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public static List<GameObject> dynamiteLights = new List<GameObject>();
    public void BuyADynamite()
    {

        if (!ChillaMedLjusen.showing)
        {
            PlacementLists.UpdateDynamitePlacement();
            CancelBuyScript.cancelPanel.SetActive(true);


            foreach (Vector2 item in PlacementLists.dynamitePlacementList)
            {
                GameObject psys = Instantiate(Resources.Load<GameObject>("BuildLights/BuildDynamiteLight"), new Vector3(item.x, item.y, 0), Quaternion.identity);
                dynamiteLights.Add(psys);
            }

            ChillaMedLjusen.showing = true;
            
        }

    }

    public void OnPointerEnter(PointerEventData eventData)
    {

        CostPanelScript.CreateCostPanel(new List<Vector2>() { new Vector2(2, 4), new Vector2(5, 2) }, "");


    }
    public void OnPointerExit(PointerEventData eventData)
    {
        CostPanelScript.DeleteCostPanel();
    }
}
