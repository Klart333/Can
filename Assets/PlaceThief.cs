using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlaceThief : MonoBehaviour
{
    public static GameObject thiefOnBoard;

    private void OnMouseDown()
    {
        TheifPlacement();
    }

    public void TheifPlacement()
    {
        if (thiefOnBoard != null)
        {
            Destroy(thiefOnBoard);
        }
        GameObject thief = (GameObject)Instantiate(Resources.Load("Thief/Thief"), transform.position, Quaternion.identity);
        thiefOnBoard = thief;

        foreach (GameObject light in ThiefScript.thiefLights)
        {
            Destroy(light);
        }
        ThiefScript.thiefLights.Clear();

        CostPanelScript.DeleteCostPanel();
        Destroy(ThiefScript.gun);
    }
}
