﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveHouse : MonoBehaviour
{

    private void OnMouseDown()
    {
        if (!ChillaMedLjusen.showing && gameObject.GetComponent<SpriteRenderer>().color == PlayerScript.activePlayer.color)
        {
            GameObject cross = (GameObject)Instantiate(Resources.Load("Building/RemoveCross"), transform);
            cross.transform.position = new Vector3(cross.transform.position.x, cross.transform.position.y + transform.localScale.y / 1.6f, 0);

        }
    }
}
