using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisarmDynamite : MonoBehaviour
{

    private void OnMouseDown()
    {
        
        GameObject cross = (GameObject)Instantiate(Resources.Load("Building/BlowBuilding/DisarmDynamite"), transform);
        cross.transform.position = new Vector3(cross.transform.position.x + transform.localScale.x / 8, cross.transform.position.y + transform.localScale.y / 1.6f, 0);

    }

}
