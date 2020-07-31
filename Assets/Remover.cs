using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Remover : MonoBehaviour
{
    bool mouseOver = false;
    float timer = 0;
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 0.2f)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (mouseOver)
                {
                    if (gameObject.transform.parent.gameObject.name[0] == 'H')
                    {
                        ObjectOnBoardLists.RemoveHouseFromBoard(transform.parent.gameObject);

                    }
                    else if (gameObject.transform.parent.gameObject.name[0] == 'S')
                    {
                        ObjectOnBoardLists.RemoveCityFromBoard(transform.parent.gameObject);
                    }

                    Destroy(gameObject);
                }
                else if (!mouseOver)
                {
                    Destroy(gameObject);
                }
            }
        }
        
    }

    private void OnMouseEnter()
    {
        mouseOver = true;
    }
    private void OnMouseExit()
    {
        mouseOver = false;
    }

}
