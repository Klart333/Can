using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCandlePurchase : MonoBehaviour
{
    [SerializeField]
    GameObject candle;

    [SerializeField]
    GameObject otherArrow;

    [SerializeField]
    GameObject DynamitePanel;

    public void OnButtonPressed()
    {
        if (candle.activeSelf)
        {
            candle.SetActive(false);
            DynamitePanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(DynamitePanel.GetComponent<RectTransform>().anchoredPosition.x + 100, DynamitePanel.GetComponent<RectTransform>().anchoredPosition.y);
        }
        else if (!candle.activeSelf)
        {
            candle.SetActive(true);
            DynamitePanel.GetComponent<RectTransform>().anchoredPosition = new Vector2(DynamitePanel.GetComponent<RectTransform>().anchoredPosition.x - 100, DynamitePanel.GetComponent<RectTransform>().anchoredPosition.y);
        }

        if (otherArrow.activeSelf)
        {
            otherArrow.SetActive(false);
        }
        else if (!otherArrow.activeSelf)
        {
            otherArrow.SetActive(true);
        }

        gameObject.SetActive(false);
    }
}
