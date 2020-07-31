using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSimpScript : MonoBehaviour
{
    void PlacingChildren()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            child.transform.position = Camera.main.transform.position;
            if (child.name == "Top")
            {
                child.transform.position += new Vector3(0, Camera.main.orthographicSize, 0);
                child.GetComponent<BoxCollider2D>().size = new Vector2(Camera.main.orthographicSize * 5, 1);
            }
        }
    }
}
