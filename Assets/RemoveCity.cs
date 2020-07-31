using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveCity : MonoBehaviour
{
    private void OnMouseDown()
    {
        if (!ChillaMedLjusen.showing && gameObject.GetComponent<SpriteRenderer>().color == PlayerScript.activePlayer.colour)
        {
            GameObject cross = (GameObject)Instantiate(Resources.Load("Building/RemoveCross"), transform);
            cross.transform.position = new Vector3(cross.transform.position.x, cross.transform.position.y + transform.localScale.y / 1.6f, 0);

        }
    }
}
