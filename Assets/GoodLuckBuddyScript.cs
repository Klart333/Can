using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodLuckBuddyScript : MonoBehaviour
{
    //BTW this panel is for obstructing player interupption when there are only bots
    void Start()
    {
        if (BotScript.botAmount != 4)
        {
            Destroy(gameObject);
        }
    }


}
