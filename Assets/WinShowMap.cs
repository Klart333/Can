using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinShowMap : MonoBehaviour
{
    
    public void ShowMap()
    {
        if (transform.parent.GetChild(0).gameObject.activeSelf)
        {
            transform.parent.GetChild(0).gameObject.SetActive(false);
        }
        else
        {
            transform.parent.GetChild(0).gameObject.SetActive(true);
        }
    }
}
