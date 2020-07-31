using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CostPanelScript : MonoBehaviour
{
    static GameObject canvas;
    static List<GameObject> costPanel = new List<GameObject>();
    private void Start()
    {
        canvas = gameObject;
    }
    public static void CreateCostPanel(List<Vector2> resourceNCostList, string text)
    {
        GameObject panel = (GameObject)Instantiate(Resources.Load("Supplies/CostPanel"), canvas.transform);
        costPanel.Add(panel);
        if (text != "")
        {
            panel.transform.GetChild(4).GetComponent<Text>().text = text;
        }
        else 
        {
            for (int i = 0; i < resourceNCostList.Count; i++)
            {
                panel.transform.GetChild(i).GetComponent<Image>().sprite = Resources.Load<Sprite>("Supplies/" + resourceNCostList[i].x.ToString());
                panel.transform.GetChild(i).GetChild(0).GetComponent<Text>().text = resourceNCostList[i].y.ToString();
            }
        }
    }

    public static void DeleteCostPanel()
    {
        for (int i = 0; i < costPanel.Count; i++)
        {
            Destroy(costPanel[i]);
        }
        costPanel.Clear();
    }
}
