using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class BuyRoad : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public static List<ParticleSystem> roadPlacementLight = new List<ParticleSystem>();

    void BuyARoad()
    {
        if (!ChillaMedLjusen.showing)
        {
            ChillaMedLjusen.showing = true;
            CancelBuyScript.cancelPanel.SetActive(true);


            #region LightAvailableSpaces


            foreach (Vector3 item in PlacementLists.roadPlacementList)
            {
                ParticleSystem psys = Instantiate(Resources.Load<ParticleSystem>("BuildLights/RoadLight"), new Vector3(item.x, item.y, 0), Quaternion.identity);
                if (item.z == 1)
                {
                    psys.name = "StraightRoad";
                }
                else if (item.z == 2)
                {
                    psys.name = "TiltedRoadLeft";
                }
                else if (item.z == 3)
                {
                    psys.name = "TiltedRoadRight";
                }
                roadPlacementLight.Add(psys);
            }

            #endregion

        }

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (PlayerScript.activePlayer.twoFreeRoads < 2)
        {
            CostPanelScript.CreateCostPanel(new List<Vector2>() { new Vector2(1, 1), new Vector2(2, 1) }, (2 - PlayerScript.activePlayer.twoFreeRoads).ToString() + " Free!");
        }
        else
        {
            CostPanelScript.CreateCostPanel( new List<Vector2>() { new Vector2(1, 1), new Vector2(2, 1) }, "");
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        CostPanelScript.DeleteCostPanel();
    }

}
