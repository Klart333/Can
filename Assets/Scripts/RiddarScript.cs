using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class RiddarScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        CostPanelScript.CreateCostPanel(new List<Vector2>(), "Chases away Scary Terrorists");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        CostPanelScript.DeleteCostPanel();

    }

    public void UseKnight()
    {
        CostPanelScript.DeleteCostPanel();

        ThiefScript.PlaceThief();

        BuyDevCard.RemoveCard(gameObject);

        Destroy(gameObject);

    }
}
