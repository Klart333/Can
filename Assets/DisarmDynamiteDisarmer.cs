using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisarmDynamiteDisarmer : MonoBehaviour
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
                    if (PlayerScript.activePlayer.woodAmount >= 2 && PlayerScript.activePlayer.sheepAmount >= 2)
                    {
                        ResourceScript.GiveWood(-2);
                        ResourceScript.GiveSheep(-1);

                        ObjectOnBoardLists.RemoveDynamiteFromBoard(transform.parent.gameObject);
                        Destroy(gameObject);
                    }
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    private void OnMouseEnter()
    {
        mouseOver = true;

        CostPanelScript.CreateCostPanel(new List<Vector2>() { new Vector2(1, 2), new Vector2(3, 1) }, "");
    }
    private void OnMouseExit()
    {
        mouseOver = false;

        CostPanelScript.DeleteCostPanel();
    }

}
