using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroll : MonoBehaviour
{
    Camera cam;
    Vector3 ogMousePos = new Vector3();
    Vector3 mouseDelta = new Vector3();
    private void Start()
    {
        cam = GetComponent<Camera>();
    }
    void Update()
    {

        cam.orthographicSize += Input.mouseScrollDelta.x;
        cam.orthographicSize -= Input.mouseScrollDelta.y;


        if (Input.GetMouseButtonDown(1))
        {
            ogMousePos = Input.mousePosition;
        }
        else if (Input.GetMouseButton(1) && ogMousePos.x != 0)
        {
            mouseDelta = Input.mousePosition - ogMousePos;

            gameObject.transform.position += (mouseDelta / 300) * (cam.orthographicSize * -1);

            ogMousePos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(1))
        {
            ogMousePos = new Vector3();
        }
    }

}
