using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
public class MonopolyGet : MonoBehaviour
{
    MonopolyManager script = new MonopolyManager();

    public void GiveMeMyMoney()
    {
        string resourceMeGet = "";
        foreach (char item in gameObject.name)
        {
            if (item == 'E')
            {
                break;
            }
            resourceMeGet += item;
        }

        if (MonopolyManager.resourceToGet1 == "")
        {
            MonopolyManager.resourceToGet1 = resourceMeGet;

            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(gameObject.GetComponent<RectTransform>().anchoredPosition.x, gameObject.GetComponent<RectTransform>().anchoredPosition.y - 30);

            MonopolyManager.pushedPanelGet1 = gameObject;
            MonopolyManager.resourceToSwitch = 2;
}
        else
        {
            GameObject pushedPanelGet = (GameObject)script.GetType().GetTypeInfo().GetField("pushedPanelGet" + MonopolyManager.resourceToSwitch).GetValue(script);

            script.GetType().GetTypeInfo().GetField("resourceToGet" + MonopolyManager.resourceToSwitch).SetValue(script, resourceMeGet);
            script.GetType().GetTypeInfo().GetField("pushedPanelGet" + MonopolyManager.resourceToSwitch).SetValue(script, gameObject);

            if (pushedPanelGet != null)
            {
                 pushedPanelGet.GetComponent<RectTransform>().anchoredPosition = new Vector2(pushedPanelGet.GetComponent<RectTransform>().anchoredPosition.x, pushedPanelGet.GetComponent<RectTransform>().anchoredPosition.y + 30);
            }
            gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(gameObject.GetComponent<RectTransform>().anchoredPosition.x, gameObject.GetComponent<RectTransform>().anchoredPosition.y - 30);

            if (MonopolyManager.resourceToSwitch == 1)
            {
                MonopolyManager.resourceToSwitch = 2;
            }
            else if (MonopolyManager.resourceToSwitch == 2)
            {
                MonopolyManager.resourceToSwitch = 1;
            }
            
        }

    }

}
