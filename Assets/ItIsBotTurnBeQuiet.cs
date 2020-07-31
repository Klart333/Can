using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItIsBotTurnBeQuiet : MonoBehaviour
{
    bool panelThere = false;

    [SerializeField]
    Canvas canvas;

 

    GameObject panel; 
    void Update()
    {
        if (BotScript.botTurn && !panelThere)
        {
            panel = (GameObject)Instantiate(Resources.Load("UI/FuckYouPanel/GoodLuckBuddyPanel"), canvas.transform);
            panelThere = true;
        }
        else if (!BotScript.botTurn && panelThere)
        {
            Destroy(panel);
            panelThere = false;
        }
    }
}
