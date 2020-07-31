using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowDynamitePurchase : MonoBehaviour
{
    [SerializeField]
    GameObject dynamite;

    [SerializeField]
    GameObject otherArrow;

    public void OnButtonPressed()
    {
        if (dynamite.activeSelf)
        {
            dynamite.SetActive(false);
        }
        else if (!dynamite.activeSelf)
        {
            dynamite.SetActive(true);
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
