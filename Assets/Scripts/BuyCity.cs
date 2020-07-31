using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class BuyCity : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public static List<ParticleSystem> cityLights = new List<ParticleSystem>();

    public void BuyACity()
    {
        if (!ChillaMedLjusen.showing)
        {
            CancelBuyScript.cancelPanel.SetActive(true);

            #region Available Light

            foreach (Vector2 item in PlacementLists.cityPlacementList)
            {
                ParticleSystem psys = Instantiate(Resources.Load<ParticleSystem>("BuildLights/CityLight"), new Vector3(item.x, item.y, 0), Quaternion.identity);
                cityLights.Add(psys);
            }

            ChillaMedLjusen.showing = true;
            #endregion
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        CostPanelScript.CreateCostPanel(new List<Vector2>() { new Vector2(4, 2), new Vector2(5, 3) }, "");
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        CostPanelScript.DeleteCostPanel();
    }
}
