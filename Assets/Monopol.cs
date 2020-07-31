using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Monopol : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        CostPanelScript.CreateCostPanel(new List<Vector2>(), "Jag hatar staten");
    }

    public void PleaseHelpMeImPoor()
    {
        Instantiate(Resources.Load("DevCards/MonopolyPrefab"), transform.parent.parent);

        CostPanelScript.DeleteCostPanel();

        BuyDevCard.RemoveCard(gameObject);

        Destroy(gameObject);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        CostPanelScript.DeleteCostPanel();

    }
}
