using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowBank : MonoBehaviour
{
    static bool shown = false;

    [SerializeField]
    GameObject otherArrow;

    [SerializeField]
    GameObject bank;
    public void BankManager()
    {
        if (!shown)
        {
            shown = true;

            bank.SetActive(true);

            otherArrow.SetActive(true);
            gameObject.SetActive(false);
        }
        else if (shown)
        {
            shown = false;

            bank.SetActive(false);

            otherArrow.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
