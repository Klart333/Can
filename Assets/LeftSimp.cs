using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftSimp : MonoBehaviour
{

    void Update()
    {
        transform.position = Camera.main.transform.position;
        transform.position -= new Vector3(Camera.main.orthographicSize * 2, 0, 0);

        GetComponent<BoxCollider2D>().size = new Vector2(5, Camera.main.orthographicSize * 5);
    }
    private void OnMouseOver()
    {
        StartCoroutine("MoveCam");
    }

    IEnumerator MoveCam()
    {
        Camera.main.transform.position -= new Vector3(0.1f, 0, 0);
        yield return new WaitForSeconds(0.5f);
    }
}
