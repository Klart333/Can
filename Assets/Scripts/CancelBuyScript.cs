using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelBuyScript : MonoBehaviour
{
    public static GameObject cancelPanel;
    void Start()
    {
        cancelPanel = gameObject;
        cancelPanel.SetActive(false);
    }

    public void CancelBuy()
    {
        ChillaMedLjusen.showing = false;

        foreach (GameObject house in BuyHouse.houseLights)
        {
            Destroy(house.gameObject);
        }
        BuyHouse.houseLights.Clear();

        foreach (GameObject candle in BuyCandle.candleLights)
        {
            Destroy(candle.gameObject);
        }
        BuyCandle.candleLights.Clear();

        foreach (ParticleSystem psys in BuyRoad.roadPlacementLight)
        {
            Destroy(psys.gameObject);
        }
        BuyRoad.roadPlacementLight.Clear();

        foreach (ParticleSystem psys in BuyCity.cityLights)
        {
            Destroy(psys.gameObject);
        }
        BuyCity.cityLights.Clear();

        foreach (GameObject item in BuyDynamite.dynamiteLights)
        {
            Destroy(item.gameObject);
        }
        BuyDynamite.dynamiteLights.Clear();

        foreach (GameObject item in ArgRiddare.knightLights)
        {
            Destroy(item.gameObject);
        }
        ArgRiddare.knightLights.Clear();

        cancelPanel.SetActive(false);
    }
}
